using CommentModels;
using CommentServices;
using Hand.Creational;

namespace CommentPersistences;

/// <summary>
/// 评论服务
/// </summary>
/// <param name="idService"></param>
/// <param name="comments"></param>
public class CommentService(ICreator<CommentId> idService, List<Comment> comments)
    : ICommentService
{
    private readonly ICreator<CommentId> _idService = idService;
    private readonly List<Comment> _comments = comments;

    /// <inheritdoc />
    public Comment Create(CommentContent content)
    {
        var id = _idService.Create();
        var time = DateTime.Now;
        var comment = new Comment(id, new(time))
        {
            Content = content,
            UpdateTime = new(time)
        };
        return comment;
    }
    /// <inheritdoc />
    public Comment AddComment(CommentContent content)
    {
        var comment = Create(content);
        _comments.Add(comment);
        return comment;
    }

    /// <inheritdoc />
    public bool DeleteComment(CommentId commentId)
    {
        var existed = _comments.FirstOrDefault(c => c.Id == commentId);
        if (existed == null)
            return false;

        return _comments.Remove(existed);
    }
    /// <inheritdoc />
    public Comment? GetComment(CommentId id)
        => _comments.FirstOrDefault(c => c.Id == id);
    /// <inheritdoc />
    public bool UpdateComment(CommentId commentId, CommentContent content)
    {
        var existed = _comments.FirstOrDefault(c => c.Id == commentId);
        if (existed == null)
            return false;
        existed.Content = content;
        existed.UpdateTime = new(DateTime.Now);
        return true;
    }
    /// <inheritdoc />
    public CountedResult<Comment> Count(int page, int size)
    {
        var skip = page > 1 ? (page - 1) * size : 0;
        var total = _comments.Count;
        if (total <= skip)
            return new CountedResult<Comment>(total, []);
        var items = _comments.Skip(skip).Take(size).ToArray();
        return new CountedResult<Comment>(total, items);
    }
}

using CommentModels;

namespace CommentServices;

/// <summary>
/// 评论服务
/// </summary>
public interface ICommentService
{
    /// <summary>
    /// 创建评论
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    Comment Create(CommentContent content);
    /// <summary>
    /// 获取评论
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Comment? GetComment(CommentId id);
    /// <summary>
    /// 添加评论
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    Comment AddComment(CommentContent content);
    /// <summary>
    /// 删除评论
    /// </summary>
    /// <param name="commentId"></param>
    /// <returns></returns>
    bool DeleteComment(CommentId commentId);
    /// <summary>
    /// 更新评论
    /// </summary>
    /// <param name="commentId"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    bool UpdateComment(CommentId commentId, CommentContent content);
    /// <summary>
    /// 获取评论列表
    /// </summary>
    /// <param name="page"></param>
    /// <param name="size"></param>
    /// <returns></returns>
    CountedResult<Comment> Count(int page, int size);
}

using FastEndpoints;

namespace NormalApp.List;

public sealed class ListRequest
{
    [QueryParam]
    public int Page { get; set; } = 1;
    [QueryParam]
    public int Size { get; set; } = 10;
}

public sealed class ListResponse : ResponseBase
{
    public int Total { get; set; }
    public CommentItem[] Items { get; set; }
}


public class CommentItem
{
    /// <summary>
    /// 评论标识
    /// </summary>
    public long Id { get; set; }
    /// <summary>
    /// 评论内容
    /// </summary>
    public string Content { get; set; }
    /// <summary>
    /// 评论创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 评论更新时间
    /// </summary>
    public DateTime UpdateTime { get; set; }
}
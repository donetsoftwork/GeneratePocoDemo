namespace NormalApp.Create;

public sealed class CreateRequest
{
    public string Content { get; set; }
}

public sealed class CreateResponse : ResponseBase
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

using FastEndpoints;
using FluentValidation;

namespace NormalApp.Detail;

public sealed class DetailRequest
{
    public long Id { get; set; }
    internal sealed class Validator : Validator<DetailRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
        }
    }
}

public sealed class DetailResponse : ResponseBase
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



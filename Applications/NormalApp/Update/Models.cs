using FastEndpoints;
using FluentValidation;

namespace NormalApp.Update;

public sealed class UpdateRequest
{
    public long Id { get; set; }
    /// <summary>
    /// 评论内容
    /// </summary>
    public string Content { get; set; }
    internal sealed class Validator : Validator<UpdateRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
            RuleFor(x => x.Content)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}

public sealed class UpdateResponse : ResponseBase
{
    /// <summary>
    /// 评论标识
    /// </summary>
    public long Id { get; set; }
}

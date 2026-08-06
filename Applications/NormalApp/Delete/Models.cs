using FastEndpoints;
using FluentValidation;

namespace NormalApp.Delete;

public sealed class DeleteRequest
{
    public long Id { get; set; }
    internal sealed class Validator : Validator<DeleteRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
        }
    }
}

public sealed class DeleteResponse : ResponseBase
{
    /// <summary>
    /// 评论标识
    /// </summary>
    public long Id { get; set; }
}
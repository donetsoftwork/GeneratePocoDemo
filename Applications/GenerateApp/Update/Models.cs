using CommentModels;
using FastEndpoints;
using FluentValidation;
using Hand.Entities;

namespace GenerateApp.Update;

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
[GeneratePoco<Comment>(Rules = [$"Include: {nameof(Comment.Id)}"], ConvertFrom = false, ConvertTo = false)]
public partial class UpdateResponse : ResponseBase;

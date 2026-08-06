using CommentModels;
using FastEndpoints;
using GenerateApp.Update;
using Hand.Entities;
using FluentValidation;

namespace GenerateApp.Create;

public sealed class CreateRequest
{
    /// <summary>
    /// 评论内容
    /// </summary>
    public string Content { get; set; }
    internal sealed class Validator : Validator<UpdateRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}

[GeneratePoco<Comment>(ConvertFrom = true, ConvertTo = false)]
public partial class CreateResponse : ResponseBase;
using CommentModels;
using FastEndpoints;
using FluentValidation;
using Hand.Entities;

namespace GenerateApp.Delete;

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
[GeneratePoco<Comment>(Rules = [$"Include: {nameof(Comment.Id)}"], ConvertFrom = false, ConvertTo = false)]
public partial class DeleteResponse : ResponseBase;
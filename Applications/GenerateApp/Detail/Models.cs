using CommentModels;
using FastEndpoints;
using FluentValidation;
using Hand.Entities;

namespace GenerateApp.Detail;

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
[GeneratePoco<Comment>(ConvertFrom = true, ConvertTo = false)]
public partial class DetailResponse : ResponseBase;

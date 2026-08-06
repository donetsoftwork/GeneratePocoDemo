using CommentModels;
using CommentServices;
using FastEndpoints;
using System.Text.Json.Serialization;

namespace NormalApp.Detail;

public sealed class Endpoint(ICommentService service)
    : Endpoint<DetailRequest, DetailResponse>
{
    private readonly ICommentService _service = service;

    public override void Configure()
    {
        AllowAnonymous();
        Get("comments/{id}");
        RequestBinder(new RequestBinder<DetailRequest>(BindingSource.RouteValues));
        SerializerContext(CommentDetailResponseJson.Default);
    }

    public override Task<DetailResponse> ExecuteAsync(DetailRequest req, CancellationToken ct)
    {
        var commentId = new CommentId(req.Id);
        var comment = _service.GetComment(commentId);
        if (comment == null)
        {
            return Task.FromResult(new DetailResponse
            {
                Message = "Comment not found"
            });
        }
        return Task.FromResult(new DetailResponse
        {
            Id = comment.Id.Original,
            Content = comment.Content.Original,
            CreateTime = comment.CreateTime.Original,
            UpdateTime = comment.UpdateTime.Original
        });
    }
}

[JsonSerializable(typeof(DetailResponse))]
[JsonSerializable(typeof(ErrorResponse))]
internal partial class CommentDetailResponseJson : JsonSerializerContext { }
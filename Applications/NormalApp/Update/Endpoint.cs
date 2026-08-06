using CommentModels;
using CommentServices;
using FastEndpoints;
using System.Text.Json.Serialization;

namespace NormalApp.Update;

public sealed class Endpoint(ICommentService service)
    : Endpoint<UpdateRequest, UpdateResponse>
{
    private readonly ICommentService _service = service;
    public override void Configure()
    {
        AllowAnonymous();
        Post("comments/{id}");
        RequestBinder(new RequestBinder<UpdateRequest>(BindingSource.JsonBody | BindingSource.RouteValues));
        SerializerContext(CommentUpdateResponseContext.Default);
    }

    public override Task<UpdateResponse> ExecuteAsync(UpdateRequest req, CancellationToken ct)
    {
        var id = req.Id;
        if (_service.UpdateComment(new CommentId(id), new CommentContent(req.Content)))
        {
            var res = new UpdateResponse
            {
                Id = id
            };
            return Task.FromResult(res);
        }
        return Task.FromResult(new UpdateResponse
        {
            Message = "Comment not found"
        });
    }
}
[JsonSerializable(typeof(UpdateRequest))]
[JsonSerializable(typeof(UpdateResponse))]
[JsonSerializable(typeof(ErrorResponse))]
internal partial class CommentUpdateResponseContext : JsonSerializerContext { }
using CommentModels;
using CommentServices;
using FastEndpoints;

namespace GenerateApp.Delete;

public sealed class Endpoint(ICommentService service)
    : Endpoint<DeleteRequest, DeleteResponse>
{
    private readonly ICommentService _service = service;

    public override void Configure()
    {
        AllowAnonymous();
        Delete("comments/{id}");
        RequestBinder(new RequestBinder<DeleteRequest>(BindingSource.RouteValues));
        //SerializerContext(CommentDeleteResponseJson.Default);
    }

    public override Task<DeleteResponse> ExecuteAsync(DeleteRequest req, CancellationToken ct)
    {
        var id = req.Id;
        var commentId = new CommentId(id);
        if (_service.DeleteComment(commentId))
            return Task.FromResult(new DeleteResponse { Id = id });
        return Task.FromResult(new DeleteResponse { Message = "Comment not found" });
    }
}

//[JsonSerializable(typeof(CreateResponse))]
//[JsonSerializable(typeof(ErrorResponse))]
//internal partial class CommentDeleteResponseJson : JsonSerializerContext { }
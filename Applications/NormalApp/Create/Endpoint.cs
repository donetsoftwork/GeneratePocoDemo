using CommentModels;
using CommentServices;
using FastEndpoints;
using System.Text.Json.Serialization;

namespace NormalApp.Create;

public sealed class Endpoint(ICommentService service)
    : Endpoint<CreateRequest, CreateResponse>
{
    private readonly ICommentService _service = service;

    public override void Configure()
    {
        AllowAnonymous();
        Put("comments");        
        RequestBinder(new RequestBinder<CreateRequest>(BindingSource.JsonBody));
        SerializerContext(CommentCreateContex.Default);
    }
    /// <inheritdoc />
    public override Task<CreateResponse> ExecuteAsync(CreateRequest req, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var content = new CommentContent(req.Content);
        var comment = _service.AddComment(content);
        var res = new CreateResponse()
        {
            Id = comment.Id.Original,
            Content = comment.Content.Original,
            CreateTime = comment.CreateTime.Original,
            UpdateTime = comment.UpdateTime.Original,
        };
        return Task.FromResult(res);
    }
}
#region JsonSerializable
[JsonSerializable(typeof(CreateRequest))]
[JsonSerializable(typeof(CreateResponse))]
[JsonSerializable(typeof(ErrorResponse))]
internal partial class CommentCreateContex : JsonSerializerContext { }
#endregion
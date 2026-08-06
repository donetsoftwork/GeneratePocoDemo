using CommentModels;
using CommentServices;
using FastEndpoints;

namespace GenerateApp.Create;

public sealed class Endpoint(ICommentService service)
    : Endpoint<CreateRequest, CreateResponse>
{
    private readonly ICommentService _service = service;

    public override void Configure()
    {
        AllowAnonymous();
        Put("comments");
        RequestBinder(new RequestBinder<CreateRequest>(BindingSource.JsonBody));
        //SerializerContext(CommentCreateContex.Default);
    }
    /// <inheritdoc />
    public override Task<CreateResponse> ExecuteAsync(CreateRequest req, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var content = new CommentContent(req.Content);
        var comment = _service.AddComment(content);
        return Task.FromResult(comment.ToCreateResponse("Success"));
    }
}
//#region JsonSerializable
//[JsonSerializable(typeof(CreateRequest), GenerationMode = JsonSourceGenerationMode.Metadata)]
//[JsonSerializable(typeof(CreateResponse), GenerationMode = JsonSourceGenerationMode.Metadata)]
//[JsonSerializable(typeof(ErrorResponse), GenerationMode = JsonSourceGenerationMode.Metadata)]
//internal partial class CommentCreateContex : JsonSerializerContext { }
//#endregion
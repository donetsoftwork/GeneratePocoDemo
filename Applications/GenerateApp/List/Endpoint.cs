using CommentModels;
using CommentServices;
using FastEndpoints;

namespace GenerateApp.List;

public sealed class Endpoint(ICommentService service)
    : Endpoint<Request, Response>
{
    private readonly ICommentService _service = service;

    public override void Configure()
    {
        AllowAnonymous();
        Get("comments");
        //SerializerContext(CommentListJson.Default);
    }

    public override Task<Response> ExecuteAsync(Request req, CancellationToken ct)
    {
        var entity = _service.Count(req.Page, req.Size);
        var res = new Response()
        {
            Total = entity.Total,
            Items = [.. entity.Items.Select(c => c.ToItem())]
        };
        return Task.FromResult(res);
    }
}

//[JsonSerializable(typeof(Response))]
//[JsonSerializable(typeof(ErrorResponse))]
//internal partial class CommentListJson : JsonSerializerContext { }
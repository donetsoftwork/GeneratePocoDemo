using CommentServices;
using FastEndpoints;
using System.Text.Json.Serialization;

namespace NormalApp.List;

public sealed class Endpoint(ICommentService service)
    : Endpoint<ListRequest, ListResponse>
{
    private readonly ICommentService _service = service;

    public override void Configure()
    {
        AllowAnonymous();
        Get("comments");
        SerializerContext(CommentListJson.Default);
    }

    public override Task<ListResponse> ExecuteAsync(ListRequest req, CancellationToken ct)
    {
        var entity = _service.Count(req.Page, req.Size);
        var res = new ListResponse()
        {
            Total = entity.Total,
            Items = [.. entity.Items.Select(c => new CommentItem
            {
                Id = c.Id.Original,
                Content = c.Content.Original,
                CreateTime = c.CreateTime.Original,
                UpdateTime = c.UpdateTime.Original
            })]
        };
        return Task.FromResult(res);
    }
}

[JsonSerializable(typeof(ListResponse))]
[JsonSerializable(typeof(ErrorResponse))]
internal partial class CommentListJson : JsonSerializerContext { }
using CommentModels;
using FastEndpoints;
using Hand.Entities;

namespace GenerateApp.List;

public sealed class Request
{
    [QueryParam]
    public int Page { get; set; } = 1;
    [QueryParam]
    public int Size { get; set; } = 10;
}

public sealed class Response : ResponseBase
{
    public int Total { get; set; }
    public CommentItem[] Items { get; set; }
}

[GeneratePoco<Comment>(ConvertFrom = true, ConvertTo = false)]
public partial class CommentItem;
using CommentPersistences;
using CommentServices;
using FastEndpoints;
using System.Reflection;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var idService = new CommentIdCreateService();
ICommentService commentService = new CommentService(idService, []);
builder.Services
    .AddSingleton(commentService)
    //.RegisterServicesFromNormalApp()
    .AddFastEndpoints(options => {
        options.Assemblies = [Assembly.GetExecutingAssembly()];
    });
var app = builder.Build();

app.UseFastEndpoints(cfg => {
    cfg.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    cfg.Endpoints.RoutePrefix = "api";
});
app.Run();

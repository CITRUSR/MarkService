using MarkService.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args).ConfigureBuilder();

var app = builder.Build().ConfigureApp();

app.Run();

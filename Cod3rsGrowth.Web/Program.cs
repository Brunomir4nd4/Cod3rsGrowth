using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Web.Controllers;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureProblemDetailsModelState();

string _chaveDeConexaoContextoPadrao = "contextoPadrao";
string _chaveDeConexaoTestes = "testes";
var comando = args.FirstOrDefault();

var conectionString = comando is "--teste"
    ? builder.Configuration.GetConnectionString(_chaveDeConexaoTestes)
    : builder.Configuration.GetConnectionString(_chaveDeConexaoContextoPadrao);

var controllerBase = new ControllerBase();
controllerBase.DefinirColesaoDeServico(conectionString);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions()
{
    ServeUnknownFileTypes = true
});

app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/i18n"))
    {
        var filePath = Path.Combine(builder.Environment.ContentRootPath, "wwwroot/webapp/i18n", context.Request.Path.Value.Substring(6));
        if (File.Exists(filePath))
        {
            await context.Response.SendFileAsync(filePath);
            return;
        }
    }

    await next();
});

app.UseFileServer(new FileServerOptions
{
     FileProvider = new PhysicalFileProvider(
            Path.Combine(builder.Environment.ContentRootPath, "wwwroot/webapp"))
});

app.UseDefaultFiles();

app.UseProblemDetailsExceptionHandler(app.Services.GetRequiredService<ILoggerFactory>());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

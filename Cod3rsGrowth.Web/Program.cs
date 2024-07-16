
using Cod3rsGrowth.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureProblemDetailsModelState();

ModuloInjetorInfra.BindServices(builder.Services);
var serviceProvider = builder.Services.BuildServiceProvider();
ModuloInjetorInfra.AtualizarTabelas(serviceProvider);

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions()
{
    ServeUnknownFileTypes = true
});


app.UseDefaultFiles();

app.UseProblemDetailsExceptionHandler(app.Services.GetRequiredService<ILoggerFactory>());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

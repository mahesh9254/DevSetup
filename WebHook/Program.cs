
using System.Management.Automation;

using System.Text.Json;

using WebHook.Payloods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.ClearProviders();
builder.Logging.AddApplicationInsights(
        configureTelemetryConfiguration: (config) =>
            config.ConnectionString = builder.Configuration.GetSection("ApplicationInsights").GetValue<string>("APPLICATIONINSIGHTS_CONNECTION_STRING"),
            configureApplicationInsightsLoggerOptions: (options) => { }
    );
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.MapPost("/apiCICD", (ILogger<Program> logger, BitbucketPayload bitbucketPayload) =>
{
    logger.LogInformation(JsonSerializer.Serialize(bitbucketPayload));
    PowerShell ps = PowerShell.Create();
    ps.AddScript(Directory.GetCurrentDirectory() + @"\GariboCICD.ps1").Invoke();

}).WithOpenApi();
app.Run();




using System.Management.Automation;
using System.Management.Automation.Runspaces;
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
app.MapPost("/apiCICD", (ILogger<Program> logger , BitbucketPayload bitbucketPayload) =>
{
       

    using(var ps = PowerShell.Create())
    {
        InitialSessionState initialSessionState = InitialSessionState.CreateDefault();
        Runspace rs = RunspaceFactory.CreateRunspace(initialSessionState);
        logger.LogInformation("Power shell script start");

    ps.AddScript(File.ReadAllText("./GariboCICD.ps1"));
        logger.LogInformation("RepositoryURL: https://Mahesh92549254@bitbucket.org/maheshtest9254/test1.git");
        ps.AddParameter("RepositoryURL", "https://Mahesh92549254@bitbucket.org/maheshtest9254/test1.git");
        logger.LogInformation(string.Format("ProjectName: {0}", bitbucketPayload?.repository?.name));
        ps.AddParameter("ProjectName", bitbucketPayload?.repository?.name);
        logger.LogInformation(string.Format("BranchName: {0}", bitbucketPayload?.commit_status?.refname));
        ps.AddParameter("BranchName", bitbucketPayload?.commit_status?.refname);
        logger.LogInformation(string.Format("ServerFolder: {0}", bitbucketPayload?.repository?.name));
        ps.AddParameter("ServerFolder", bitbucketPayload?.repository?.name);
        rs.Open();
        ps.Runspace = rs;
        var results = ps.Invoke<string>();
        var error = ps.Streams.Error;
        logger.LogInformation(string.Format(JsonSerializer.Serialize(error)));

        logger.LogInformation(results.FirstOrDefault());
    logger.LogInformation("Power shell script end");
    }
}).WithOpenApi();
app.Run();



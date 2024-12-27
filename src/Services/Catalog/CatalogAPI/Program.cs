
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

#region Add Service to the Container
var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();

#endregion

// Exception Handler 
builder.Services.AddExceptionHandler<CustomerExceptionHandler>();

#region Health Checks Configuration

builder.Services.AddHealthChecks().AddNpgSql(builder.Configuration.GetConnectionString("Database")!);

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline
app.MapCarter();
app.UseExceptionHandler(options => { });
#endregion

#region Health Checks HTTP 

app.UseHealthChecks("/health",new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
});

#endregion

app.Run();

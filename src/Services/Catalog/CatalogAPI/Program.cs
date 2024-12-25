using BuildingBlocks.Behavior;

var builder = WebApplication.CreateBuilder(args);

#region Add Service to the Container
var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline
app.MapCarter();
#endregion

app.Run();

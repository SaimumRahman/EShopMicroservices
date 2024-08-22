 var builder = WebApplication.CreateBuilder(args);

#region Add Service to the Container
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
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

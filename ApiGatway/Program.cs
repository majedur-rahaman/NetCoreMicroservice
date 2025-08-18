using JWTConfiguration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddJwtAuthentication();
builder.Services.AddEndpointsApiExplorer();
builder.Configuration.AddJsonFile("ocelot.json", optional:false,reloadOnChange:true);
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
await app.UseOcelot();

//app.MapGet("/", () => "Hello World!");

app.Run();

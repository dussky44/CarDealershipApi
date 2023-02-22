using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Ocelot.json");
builder.Services.AddOcelot();
builder.Services.AddCors(options => {
    options.AddPolicy(name: "DefaultCorsPolicy",
        policy => {
            policy.WithOrigins("http://localhost:32770", "http://localhost:4200", "http://host.docker.internal:32770", "*")
            .AllowAnyHeader()
            .AllowAnyMethod();
        }
        );
});

//builder => {
//    builder.WithOrigins("http://localhost:32770", "http://localhost:4200", "http://host.docker.internal:32770", "*")
//                        .AllowAnyHeader()
//                        .AllowAnyMethod();
//}
var app = builder.Build();
app.UseOcelot().Wait();
app.UseCors("DefaultCorsPolicy");

app.MapControllers();

app.Run();

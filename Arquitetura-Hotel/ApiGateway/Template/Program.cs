using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona Ocelot e configura o arquivo ocelot.json
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot();

// Configura o Swagger no Gateway
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Gateway",
        Version = "v1",
        Description = "Documentação do Gateway que gerencia rotas para os microserviços.",
    });
});

var app = builder.Build();

// Adiciona o Swagger e o UI ao pipeline
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gateway v1");
    options.RoutePrefix = ""; // Deixa o Swagger na raiz (http://localhost:5000/)
});

// Usa o middleware do Ocelot
app.UseOcelot().Wait();

app.Run();

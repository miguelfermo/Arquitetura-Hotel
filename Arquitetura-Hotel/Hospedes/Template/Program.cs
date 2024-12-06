using Microsoft.EntityFrameworkCore;
using MicroserviceHospedes.Infra.Contexto;
using MicroserviceHospedes.Servicos;
using MicroserviceHospedes.Infra;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao container
builder.Services.AddControllers();

// Configura o Swagger
builder.Services.AddEndpointsApiExplorer(); // Explora os endpoints da API
builder.Services.AddSwaggerGen(); // Gera a documentação da API

// Configura o contexto do banco de dados SQLite
builder.Services.AddDbContext<HospedesContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Adiciona o serviço de hóspedes ao container de dependências
builder.Services.AddScoped<HospedesService>();

// Configuração do GeradorDeServicos, se necessário
GeradorDeServicos.ServiceProvider = builder.Services.BuildServiceProvider();

// Configura CORS para permitir requisições de outras origens
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin() // Permite qualquer origem (bom para desenvolvimento)
              .AllowAnyMethod() // Permite qualquer método (GET, POST, etc.)
              .AllowAnyHeader(); // Permite qualquer cabeçalho
    });
});

var app = builder.Build();

// Configura o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Gera a documentação do Swagger
    app.UseSwaggerUI(); // Interface visual do Swagger
}

// Adiciona o middleware de CORS
app.UseCors(); // Certifique-se de que isso vem antes de app.UseAuthorization()

app.UseHttpsRedirection(); // Redireciona para HTTPS (caso necessário)

app.UseAuthorization(); // Habilita a autorização para os endpoints (se necessário)

app.MapControllers(); // Mapeia os controladores da API

app.Run(); // Inicia a aplicação

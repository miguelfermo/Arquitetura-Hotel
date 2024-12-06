using Microsoft.EntityFrameworkCore;
using MicroserviceReservas.Infra.Contexto;
using MicroserviceReservas.Services;
using MicroserviceReservas.Infra;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao container
builder.Services.AddControllers();

// Configura o Swagger
builder.Services.AddEndpointsApiExplorer(); // Explora os endpoints da API
builder.Services.AddSwaggerGen(); // Gera a documentação da API

// Configura o contexto do banco de dados SQLite para o serviço de reservas
builder.Services.AddDbContext<ReservasContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Adiciona o serviço de Reservas ao container de dependências
builder.Services.AddScoped<ReservaService>();

// Configura CORS para permitir requisições de outras origens
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin() // Permite qualquer origem (ideal para desenvolvimento)
              .AllowAnyMethod() // Permite qualquer método (GET, POST, etc.)
              .AllowAnyHeader(); // Permite qualquer cabeçalho
    });
});

// Configuração do GeradorDeServicos, se necessário
GeradorDeServicos.ServiceProvider = builder.Services.BuildServiceProvider();

var app = builder.Build();

// Configura o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Gera a documentação do Swagger
    app.UseSwaggerUI(); // Interface visual do Swagger
}

// Adiciona o middleware do CORS com o nome da política definida
app.UseCors("AllowAllOrigins"); // Usando a política "AllowAllOrigins"

app.UseHttpsRedirection(); // Redireciona para HTTPS (caso necessário)

app.UseAuthorization(); // Habilita a autorização para os endpoints (se necessário)

app.MapControllers(); // Mapeia os controladores da API

app.Run(); // Inicia a aplicação

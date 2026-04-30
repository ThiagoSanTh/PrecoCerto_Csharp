using Microsoft.EntityFrameworkCore;
using Pc.Infraestrutura;
using Pc.Repositorio.Implementacoes;
using Pc.Repositorio.Interfaces;
using Pc.Servico.Implementacoes;
using Pc.Servico.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// 🔥 FORÇA A API A FICAR ACESSÍVEL NA REDE
builder.WebHost.UseUrls("http://0.0.0.0:5132");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 🔥 CORS LIBERADO PRA MOBILE / FRONT
builder.Services.AddCors(options =>
{
    options.AddPolicy("MobilePolicy", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// 🔥 DI
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<ILojaRepositorio, LojaRepositorio>();
builder.Services.AddScoped<IOfertaRepositorio, OfertaRepositorio>();

builder.Services.AddScoped<IProdutoServico, ProdutoService>();
builder.Services.AddScoped<ILojaServico, LojaService>();
builder.Services.AddScoped<IOfertaServico, OfertaService>();

// 🔥 DB
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔥 MUITO IMPORTANTE: CORS antes de tudo
app.UseCors("MobilePolicy");

// ❌ REMOVE ISSO PRA MOBILE (HTTPS QUEBRA)
//// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
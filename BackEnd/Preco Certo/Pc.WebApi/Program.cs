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

// 🔥 DI - Repositorios (Catalogo e Estabelecimentos)
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<ILojaRepositorio, LojaRepositorio>();
builder.Services.AddScoped<IOfertaRepositorio, OfertaRepositorio>();

// 🔥 DI - Repositorios (Usuarios) - Consolidado (sem Usuario intermediário)
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<ILojistaRepositorio, LojistaRepositorio>();
builder.Services.AddScoped<IAdminRepositorio, AdminRepositorio>();

// 🔥 DI - Repositorios (Interacoes)
builder.Services.AddScoped<IFavoritoRepositorio, FavoritoRepositorio>();
builder.Services.AddScoped<IHistoricoPesquisaRepositorio, HistoricoPesquisaRepositorio>();
builder.Services.AddScoped<IAvaliacaoRepositorio, AvaliacaoRepositorio>();
builder.Services.AddScoped<IPreferenciaClienteRepositorio, PreferenciaClienteRepositorio>();

// 🔥 DI - Servicos (Catalogo e Estabelecimentos)
builder.Services.AddScoped<IProdutoServico, ProdutoService>();
builder.Services.AddScoped<ILojaServico, LojaService>();
builder.Services.AddScoped<IOfertaServico, OfertaService>();

// 🔥 DI - Servicos (Usuarios) - Consolidado (sem Usuario intermediário)
builder.Services.AddScoped<IClienteServico, ClienteServico>();
builder.Services.AddScoped<ILojistaServico, LojistaServico>();
builder.Services.AddScoped<IAdminServico, AdminServico>();

// 🔥 DI - Servicos (Interacoes)
builder.Services.AddScoped<IFavoritoServico, FavoritoServico>();
builder.Services.AddScoped<IHistoricoPesquisaServico, HistoricoPesquisaServico>();
builder.Services.AddScoped<IAvaliacaoServico, AvaliacaoServico>();
builder.Services.AddScoped<IPreferenciaClienteServico, PreferenciaClienteServico>();

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
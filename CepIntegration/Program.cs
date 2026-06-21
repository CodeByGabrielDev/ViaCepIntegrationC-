using CepIntegration.Clients;
using CepIntegration.Config;
using CepIntegration.Data;
using CepIntegration.Repository;
using CepIntegration.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<ViaCepSettings>(
    builder.Configuration.GetSection(ViaCepSettings.SectionName));

builder.Services.AddHttpClient<IViaCepClient, ViaCepClient>(ConfigurarViaCepClient);

void ConfigurarViaCepClient(IServiceProvider serviceProvider, HttpClient client)
{
    var settings = serviceProvider.GetRequiredService<IOptions<ViaCepSettings>>().Value;
    client.BaseAddress = new Uri(settings.BaseUrl);
}

// Injeção de Dependência das camadas
builder.Services.AddScoped<ICepService, CepService>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IPessoaService, PessoaService>();

// Controllers
builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
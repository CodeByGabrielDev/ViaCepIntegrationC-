using CepIntegration.Entities;
using Microsoft.EntityFrameworkCore;

namespace CepIntegration.Data;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<CepEntity> Ceps{get;set;}
    public DbSet<Pessoa>Pessoas{get;set;}
}
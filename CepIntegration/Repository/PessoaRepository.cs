using CepIntegration.Data;
using CepIntegration.Entities;

namespace CepIntegration.Repository;


public class PessoaRepository : IPessoaRepository
{
    private readonly AppDbContext appDbContext;

    public PessoaRepository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    public async Task<Pessoa> SaveAsync(Pessoa pessoa)
    {
        this.appDbContext.Pessoas.Add(pessoa);
        await appDbContext.SaveChangesAsync();
        return pessoa;
    }
    public async Task<Pessoa?> FindByIdAsync(int id)
    {
        return await this.appDbContext.Pessoas.FindAsync(id);
    }

    public async Task DeleteAsyncById(int id)
    {
        var pessoa = await this.appDbContext.Pessoas.FindAsync(id);

        if (pessoa != null)
        {
            this.appDbContext.Pessoas.Remove(pessoa);
            await this.appDbContext.SaveChangesAsync();
        }

    }


}
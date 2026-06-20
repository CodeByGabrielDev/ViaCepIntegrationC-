using CepIntegration.Entities;

namespace CepIntegration.Repository;

public interface IPessoaRepository
{
    Task<Pessoa> SaveAsync(Pessoa pessoa);

    Task<Pessoa?> FindByIdAsync(int id);

    Task DeleteAsyncById(int id);
}
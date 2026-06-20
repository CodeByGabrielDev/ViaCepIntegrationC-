using CepIntegration.Entities;

namespace CepIntegration.Service;

public interface IPessoaService
{
    Task<Pessoa> SaveAsync(Pessoa pessoa);

}
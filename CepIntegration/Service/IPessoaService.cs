using CepIntegration.Dto.Request;
using CepIntegration.Dto.Response;
using CepIntegration.Entities;

namespace CepIntegration.Service;

public interface IPessoaService
{
    Task<PessoaDTO> SaveAsync(PessoaDTORequest pessoa);

    Task<PessoaDTO?> FindByIdAsync(int id);

    Task DeleteAsyncById(int id);
    
}
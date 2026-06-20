using CepIntegration.Dto.Response;

namespace CepIntegration.Clients;

public interface IViaCepClient
{
    Task<CepDto>BuscarCepAsync(string cep);
}
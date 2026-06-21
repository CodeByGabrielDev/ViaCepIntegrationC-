using CepIntegration.Entities;

namespace CepIntegration.Service;

public interface ICepService
{
    Task<CepEntity>BuscarCep(string cep);
}
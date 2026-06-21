using CepIntegration.Clients;
using CepIntegration.Entities;

namespace CepIntegration.Service;


public class CepService : ICepService
{
    private readonly IViaCepClient viaCepClient;

    public CepService(IViaCepClient viaCepClient)
    {
        this.viaCepClient = viaCepClient;
    }
    public async Task<CepEntity> BuscarCep(string cep)
    {
        if (string.IsNullOrWhiteSpace(cep))
        {
            throw new Exception("Cep nao pode ser um campo vazio");
        }
        var cepBuscaAPI = await this.viaCepClient.BuscarCepAsync(cep);
        var cepEntity = new CepEntity
        {
            Cep = cepBuscaAPI.Cep,
            Logradouro = cepBuscaAPI.Logradouro,
            Complemento = cepBuscaAPI.Complemento,
            Bairro = cepBuscaAPI.Bairro
        };
        return cepEntity;
    }
}
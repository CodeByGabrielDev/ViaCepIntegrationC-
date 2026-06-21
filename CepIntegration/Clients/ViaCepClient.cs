using CepIntegration.Dto.Response;

namespace CepIntegration.Clients;

public class ViaCepClient : IViaCepClient
{
    private readonly HttpClient httpClient;

    public ViaCepClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<CepDto> BuscarCepAsync(string cep)
    {
        var resultado = await this.httpClient.GetFromJsonAsync<CepDto>($"{cep}/json");

        if (resultado == null)
        {
            throw new Exception("CEP nao encontrado");
        }
        return resultado;
    }
}
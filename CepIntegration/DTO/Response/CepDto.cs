namespace CepIntegration.Dto.Response;
/*
    utilizie a memsa estrutura de camadas que uso em java para integrar e receber informacoes de API externa.
*/
public record CepDto(string Cep, string Logradouro,string Complemento , string Bairro, string Uf);
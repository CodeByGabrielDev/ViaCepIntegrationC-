using CepIntegration.Dto.Request;
using CepIntegration.Dto.Response;
using CepIntegration.Entities;
using CepIntegration.Repository;

namespace CepIntegration.Service;

public class PessoaService : IPessoaService
{
    private readonly ICepService cepService;
    private readonly IPessoaRepository pessoaRepository;

    public PessoaService(ICepService cepService, IPessoaRepository pessoaRepository)
    {
        this.cepService = cepService;
        this.pessoaRepository = pessoaRepository;
    }
    /*

    Task<PessoaDTO?> FindByIdAsync(int id);
    Task DeleteAsyncById(int id);
    */
    public async Task DeleteAsyncById(int id)
    {
        var pessoa = await this.pessoaRepository.FindByIdAsync(id);

        if (pessoa == null)
        {
            throw new Exception("Pessoa nao encontrada");
        }
        await this.pessoaRepository.DeleteAsyncById(id);
    }


    public async Task<PessoaDTO> FindByIdAsync(int id)
    {
        var pessoa = await this.pessoaRepository.FindByIdAsync(id);

        if (pessoa == null)
        {
            throw new Exception("objeto pessoa nao enocntrado via banco");
        }
        return MontaDto(pessoa);
    }

    public async Task<PessoaDTO> SaveAsync(PessoaDTORequest pessoa)
    {
        ValidatorAttributes(pessoa);
        CepEntity cepEntity = await this.cepService.BuscarCep(pessoa.Cep);
        int idade = CalculaIdadeCliente(pessoa.Aniversario);

        var PessoaEntity = new Pessoa
        {
            Age = idade,
            BornDate = pessoa.Aniversario,
            Cpf = pessoa.Cpf,
            Name = pessoa.Nome,
            CepEntity = cepEntity
        };
        var pessoaPersistida = await this.pessoaRepository.SaveAsync(PessoaEntity);
        return MontaDto(pessoaPersistida);
    }
    /*string Nome,DateTime Aniversario,int Age,EnderecoDto EnderecoDto

    string Cep, string Logradouro, string Bairro, string Uf
    */
    public PessoaDTO MontaDto(Pessoa pessoa)
    {
        return new PessoaDTO(pessoa.Name, pessoa.BornDate, pessoa.Age, new EnderecoDto(pessoa.CepEntity.Cep, pessoa.CepEntity.Logradouro, pessoa.CepEntity.Bairro, pessoa.CepEntity.Uf));
    }
    public void ValidatorAttributes(PessoaDTORequest pessoa)
    {
        if (pessoa == null)
        {
            throw new Exception("objeto null");
        }
        if (string.IsNullOrWhiteSpace(pessoa.Cpf))
        {
            throw new Exception("Cpf não deve ser enviado nulo");
        }
        if (string.IsNullOrWhiteSpace(pessoa.Cep))
        {
            throw new Exception("Cep não deve ser enviado nulo");
        }
        if (string.IsNullOrWhiteSpace(pessoa.Nome))
        {
            throw new Exception("Nome não deve ser enviado nulo");
        }
    }

    public int CalculaIdadeCliente(DateTime aniversario)
    {
        var idade = DateTime.Today.Year - aniversario.Year;

        if (DateTime.Today.Month < aniversario.Month)
        {
            idade--;
        }
        else if (DateTime.Today.Month == aniversario.Month && DateTime.Today.Day < aniversario.Day)
        {
            idade--;
        }
        return idade;
    }

}
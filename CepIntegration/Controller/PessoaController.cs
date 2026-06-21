using CepIntegration.Dto.Request;
using CepIntegration.Dto.Response;
using CepIntegration.Entities;
using CepIntegration.Service;
using Microsoft.AspNetCore.Mvc;

namespace CepIntegration.Controller;
[ApiController]
[Route("api-test/[controller]")]
public class PessoaController : ControllerBase
{
    private readonly IPessoaService pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
        this.pessoaService = pessoaService;
    }
    [HttpPost]
    public async Task<IActionResult> SalvarPessoa([FromBody] PessoaDTORequest request)
    {
        
        var pessoa = await this.pessoaService.SaveAsync(request);

        return Ok(pessoa);
    }
    [HttpGet("{id}")]
    public async Task<PessoaDTO> BuscarPessoaPorId( int id)
    {
        return  await this.pessoaService.FindByIdAsync(id);
    }
    [HttpDelete]
    public async Task<IActionResult> DeletarPessoaPorId(int id)
    {
        await this.pessoaService.DeleteAsyncById(id);
        return NoContent();
    }


}

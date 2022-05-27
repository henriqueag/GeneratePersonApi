using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DocumentGenerator.Api.Entities;
using DocumentGenerator.Api.Interfaces;

namespace DocumentGenerator.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonGenerateController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonGenerateController(IPersonService service, IEnderecoService enderecoService)
        {
            _service = service;
        }

        [HttpGet("onePerson")]
        public async Task<IActionResult> GetPessoa([FromQuery] int? idade = null, [FromQuery] string estadoBR_sigla = null, [FromQuery] string cidade = null, [FromQuery] bool gerarComPonto = true)
        {
            try
            {
                var model = await _service.GerarPessoaAsync(idade, estadoBR_sigla, cidade, gerarComPonto);
                if (model is null)
                {
                    return NotFound();
                }
                return Ok(model.ToApi());
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("listPerson")]
        public async Task<IActionResult> GetListPessoas([FromQuery] int qtdPessoas, [FromQuery] int? idade = null, [FromQuery] string estadoBR_sigla = null, [FromQuery] string cidade = null, [FromQuery] bool gerarComPonto = true)
        {
            try
            {
                var model = await _service.GerarListPessoaAsync(qtdPessoas, idade, estadoBR_sigla, cidade, gerarComPonto);
                if (model is null)
                {
                    return NotFound();
                }
                return Ok(model.ToApi());
            }
            catch (System.Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

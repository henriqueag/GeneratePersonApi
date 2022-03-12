using System.Threading.Tasks;
using DocumentGenerator.Entities;
using Microsoft.AspNetCore.Mvc;
using DocumentGenerator.Interfaces;
using DocumentGenerator.Entities.Enum;

namespace DocumentGenerator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonGenerateController : ControllerBase
    {
        private readonly IPersonService _service;

        public PersonGenerateController(IPersonService service, IEnderecoService enderecoService)
        {
            _service = service;
        }

        [HttpGet("onePerson")]
        public async Task<IActionResult> GetPessoa([FromQuery] int? idade = null, [FromQuery] EstadosBR? estado = null, [FromQuery] string cidade = null, [FromQuery] bool gerarComPonto = true)
        {
            try
            {
                var model = await _service.GerarPessoaAsync(idade, estado, cidade, gerarComPonto);
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
        public async Task<IActionResult> GetListPessoas([FromQuery] int qtdPessoas, [FromQuery] int? idade = null, [FromQuery] EstadosBR? estado = null, [FromQuery] string cidade = null, [FromQuery] bool gerarComPonto = true)
        {
            try
            {
                var model = await _service.GerarListPessoaAsync(qtdPessoas, idade, estado, cidade, gerarComPonto);
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

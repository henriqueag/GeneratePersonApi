using Microsoft.AspNetCore.Mvc;
using DocumentGeneratorApp.Api.Interfaces;
using System.Threading.Tasks;

namespace DocumentGeneratorApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IAddressService _enderecoService;

        public EnderecoController(IAddressService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet("endereco")]
        public async Task<IActionResult> GetEnderecoString([FromQuery] string estadosBR_sigla, [FromQuery] string cidade)
        {            
            var endereco = await _enderecoService.GetEnderecoAsync(estadosBR_sigla, cidade);            
            return Ok(endereco);
        }

        [HttpGet("cidades")]
        public IActionResult GetCidades([FromQuery] string estadosBR_sigla)
        {
            var cidades = _enderecoService.GetCidades(estadosBR_sigla);
            return Ok(cidades);
        }

        [HttpGet("estados")]
        public IActionResult GetEstados()
        {
            var estados = _enderecoService.GetEstados();
            return Ok(estados);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using DocumentGenerator.Interfaces;
using DocumentGenerator.Entities.Enum;
using DocumentGenerator.Services;

namespace DocumentGenerator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocGenerateController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public DocGenerateController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet("cpf_generator")]
        public IActionResult GetCPFValido([FromQuery] EstadosBR estadosBR, [FromQuery] bool gerarComPonto = true)
        {
            var cpf = DocGeneratorService.GeraCPFValido(estadosBR, gerarComPonto);
            return Ok(cpf);
        }

        [HttpGet("cnpj_generator")]
        public IActionResult GetCNPJValido()
        {
            var cnpj = DocGeneratorService.GeraCNPJValido();
            return Ok(cnpj);
        }

        [HttpGet("rg_generator")]
        public IActionResult GetRGValido([FromQuery] bool gerarComPonto = true)
        {
            var rg = DocGeneratorService.GeraRGValido(gerarComPonto);
            return Ok(rg);
        }

        [HttpGet("cidades")]
        public IActionResult GetCidades([FromQuery] EstadosBR? estadosBR)
        {
            var cidades = _enderecoService.GetCidades(estadosBR);
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

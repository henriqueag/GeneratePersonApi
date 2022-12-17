using Microsoft.AspNetCore.Mvc;
using DocumentGeneratorApp.Api.Interfaces;

namespace DocumentGeneratorApp.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet("cpf_generator")]
        public IActionResult GetCPFValido([FromQuery] string estadoBR_sigla, [FromQuery] bool gerarComPonto = true)
        {
            var cpf = _documentService.GeraCPFValido(estadoBR_sigla, gerarComPonto);
            return Ok(cpf);
        }

        [HttpGet("cnpj_generator")]
        public IActionResult GetCNPJValido()
        {
            var cnpj = _documentService.GeraCNPJValido();
            return Ok(cnpj);
        }

        [HttpGet("rg_generator")]
        public IActionResult GetRGValido([FromQuery] bool gerarComPonto = true)
        {
            var rg = _documentService.GeraRGValido(gerarComPonto);
            return Ok(rg);
        }
    }
}

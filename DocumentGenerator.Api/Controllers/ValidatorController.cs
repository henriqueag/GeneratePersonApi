using Microsoft.AspNetCore.Mvc;
using DocumentGenerator.Lib.Services;

namespace DocumentGenerator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValidatorController : ControllerBase
    {
        [HttpGet("cpf_validator")]
        public IActionResult ValidarCPF(string cpf)
        {
            if (Validations.ValidaCPF(cpf))
            {
                return Ok("CPF válido");
            }
            return BadRequest("CPF inválido.");
        }

        [HttpGet("cnpj_validator")]
        public IActionResult ValidarCNPJ(string cnpj)
        {
            if (Validations.ValidaCNPJ(cnpj))
            {
                return Ok("CNPJ válido");
            }
            return BadRequest("CNPJ inválido.");
        }

        [HttpGet("rg_validator")]
        public IActionResult ValidarRG(string rg)
        {
            if (Validations.ValidaRG(rg))
            {
                return Ok("RG válido");
            }
            return BadRequest("RG inválido.");
        }
    }
}

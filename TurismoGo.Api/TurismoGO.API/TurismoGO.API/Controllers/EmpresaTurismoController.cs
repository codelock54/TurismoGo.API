using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurismoGo.Domain.CORE.Entity;
using TurismoGo.Domain.CORE.Interfaces;

namespace TurismoGO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaTurismoController : ControllerBase
    {
        private readonly IEmpresaTurismoRepository _empresaTurismoRepository;

        public EmpresaTurismoController(IEmpresaTurismoRepository empresaTurismoRepository)
        {
            _empresaTurismoRepository = empresaTurismoRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var empresas = await _empresaTurismoRepository.GetEmpresasTurismo();
            return Ok(empresas);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetEmpresaById([FromQuery] int id)
        {
            var empresa = await _empresaTurismoRepository.GetEmpresaTurismoById(id);
            if (empresa == null)
                return NotFound();
            return Ok(empresa);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateEmpresa([FromBody] EmpresaTurismo empresa)
        {
            await _empresaTurismoRepository.InsertEmpresaTurismo(empresa);
            return CreatedAtAction(nameof(GetEmpresaById), new { id = empresa.IdEmpresa }, empresa);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmpresa([FromBody] EmpresaTurismo empresa)
        {
            bool result = await _empresaTurismoRepository.UpdateEmpresaTurismo(empresa);
            if (!result)
                return BadRequest();
            return Ok(empresa);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            bool result = await _empresaTurismoRepository.DeleteEmpresaTurismo(id);
            if (!result)
                return BadRequest();
            return Ok(id);
        }
    }
}

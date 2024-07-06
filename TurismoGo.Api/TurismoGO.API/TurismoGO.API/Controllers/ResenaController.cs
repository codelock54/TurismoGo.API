using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurismoGo.Domain.CORE.Entity;
using TurismoGo.Domain.CORE.Interfaces;

namespace TurismoGO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResenaController : ControllerBase
    {
        private readonly IResenaRepository _resenaRepository;

        public ResenaController(IResenaRepository resenaRepository)
        {
            _resenaRepository = resenaRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var resenas = await _resenaRepository.GetResenas();
            return Ok(resenas);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetResenaById([FromQuery] int id)
        {
            var resena = await _resenaRepository.GetResenaById(id);
            if (resena == null)
                return NotFound();
            return Ok(resena);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateResena([FromBody] Reseña resena)
        {
            await _resenaRepository.InsertResena(resena);
            return CreatedAtAction(nameof(GetResenaById), new { id = resena.IdReseña }, resena);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateResena([FromBody] Reseña resena)
        {
            bool result = await _resenaRepository.UpdateResena(resena);
            if (!result)
                return BadRequest();
            return Ok(resena);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteResena(int id)
        {
            bool result = await _resenaRepository.DeleteResena(id);
            if (!result)
                return BadRequest();
            return Ok(id);
        }
    }
}

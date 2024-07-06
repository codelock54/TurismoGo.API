using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurismoGo.Domain.CORE.Entity;
using TurismoGo.Domain.CORE.Interfaces;

namespace TurismoGO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRolRepository _rolRepository;

        public RolController(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _rolRepository.GetRoles();
            return Ok(roles);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetRolById([FromQuery] int id)
        {
            var rol = await _rolRepository.GetRolById(id);
            if (rol == null)
                return NotFound();
            return Ok(rol);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateRol([FromBody] Rol rol)
        {
            await _rolRepository.InsertRol(rol);
            return CreatedAtAction(nameof(GetRolById), new { id = rol.IdRol }, rol);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateRol([FromBody] Rol rol)
        {
            bool result = await _rolRepository.UpdateRol(rol);
            if (!result)
                return BadRequest();
            return Ok(rol);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            bool result = await _rolRepository.DeleteRol(id);
            if (!result)
                return BadRequest();
            return Ok(id);
        }
    }
}

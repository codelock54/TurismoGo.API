using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurismoGo.Domain.CORE.Entity;
using TurismoGo.Domain.CORE.Interfaces;
using System.Threading.Tasks;
using TurismoGo.Domain.CORE.DTO;

namespace TurismoGO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private readonly IActividadRepository _actividadRepository;

        public ActividadController(IActividadRepository actividadRepository)
        {
            _actividadRepository = actividadRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ActividadSinEmpresaDTO>>> GetAllActividades()
        {
            var actividades = await _actividadRepository.GetActividades();

            var actividadesDTO = actividades.Select(a => new ActividadSinEmpresaDTO
            {
                IdActividad = a.IdActividad,
                NombreActividad = a.NombreActividad,
                Descripcion = a.Descripcion,
                Destino = a.Destino,
                FechaInicio = a.FechaInicio,
                FechaFin = a.FechaFin,
                Precio = a.Precio
            });

            return Ok(actividadesDTO);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetActividadById([FromQuery] int id)
        {
            var actividad = await _actividadRepository.GetActividadById(id);
            if (actividad == null)
                return NotFound(new { message = $"Actividad con id {id} no encontrada." });
            return Ok(actividad);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateActividad([FromBody] CrearActividadDTO actividadDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Mapeo del DTO a la entidad Actividad
            var actividad = new Actividad
            {
                NombreActividad = actividadDTO.NombreActividad,
                Descripcion = actividadDTO.Descripcion,
                Destino = actividadDTO.Destino,
                FechaInicio = actividadDTO.FechaInicio,
                FechaFin = actividadDTO.FechaFin,
                Precio = actividadDTO.Precio,
                IdEmpresa = actividadDTO.IdEmpresa // Asigna el IdEmpresa del DTO
            };

            await _actividadRepository.InsertActividad(actividad);

            // Opcional: puedes devolver el DTO en lugar de la entidad completa
            return CreatedAtAction(nameof(GetActividadById), new { id = actividad.IdActividad }, actividadDTO);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateActividad([FromBody] Actividad actividad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            bool result = await _actividadRepository.UpdateActividad(actividad);
            if (!result)
                return BadRequest(new { message = $"Error al actualizar la actividad con id {actividad.IdActividad}." });
            return Ok(actividad);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteActividad(int id)
        {
            bool result = await _actividadRepository.DeleteActividad(id);
            if (!result)
                return NotFound(new { message = $"Actividad con id {id} no encontrada." });
            return Ok(new { message = $"Actividad con id {id} eliminada exitosamente." });
        }
    }
}

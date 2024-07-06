using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurismoGo.Domain.CORE.Entity;
using TurismoGo.Domain.CORE.Interfaces;

namespace TurismoGO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaController(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var reservas = await _reservaRepository.GetReservas();
            return Ok(reservas);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetReservaById([FromQuery] int id)
        {
            var reserva = await _reservaRepository.GetReservaById(id);
            if (reserva == null)
                return NotFound();
            return Ok(reserva);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateReserva([FromBody] Reserva reserva)
        {
            await _reservaRepository.InsertReserva(reserva);
            return CreatedAtAction(nameof(GetReservaById), new { id = reserva.IdReserva }, reserva);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateReserva([FromBody] Reserva reserva)
        {
            bool result = await _reservaRepository.UpdateReserva(reserva);
            if (!result)
                return BadRequest();
            return Ok(reserva);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            bool result = await _reservaRepository.DeleteReserva(id);
            if (!result)
                return BadRequest();
            return Ok(id);
        }
    }
}

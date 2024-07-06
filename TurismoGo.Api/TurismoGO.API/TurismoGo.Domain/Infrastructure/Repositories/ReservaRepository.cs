using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurismoGo.Domain.CORE.Entity;
using TurismoGo.Domain.CORE.Interfaces;
using TurismoGo.Domain.Infrastructure.Data;

namespace TurismoGo.Domain.Infrastructure.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly TurismoDbContext _context;

        public ReservaRepository(TurismoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reserva>> GetReservas()
        {
            return await _context.Reserva.ToListAsync();
        }

        public async Task<Reserva> GetReservaById(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                throw new Exception("Reserva not found");
            }
            return reserva;
        }

        public async Task InsertReserva(Reserva reserva)
        {
            await _context.Reserva.AddAsync(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateReserva(Reserva reserva)
        {
            _context.Reserva.Update(reserva);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> DeleteReserva(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return false;
            }
            _context.Reserva.Remove(reserva);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }
    }

}

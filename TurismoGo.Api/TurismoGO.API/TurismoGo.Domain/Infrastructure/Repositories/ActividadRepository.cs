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
    public class ActividadRepository : IActividadRepository
    {
        private readonly TurismoDbContext _context;

        public ActividadRepository(TurismoDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Actividad>> GetActividades()
        {

            return await _context.Actividad.ToListAsync();
        }
        public async Task<Actividad> GetActividadById(int id)
        {
            var actividad = await _context.Actividad.FindAsync(id);
            if (actividad == null)
            {
                throw new Exception("Actividad not found");
            }
            return actividad;
        }

        public async Task InsertActividad(Actividad actividad)
        {
            await _context.Actividad.AddAsync(actividad);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateActividad(Actividad actividad)
        {
            _context.Actividad.Update(actividad);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> DeleteActividad(int id)
        {
            var actividad = await _context.Actividad.FindAsync(id);
            if (actividad == null)
            {
                return false;
            }
            _context.Actividad.Remove(actividad);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;

        }
    }
}

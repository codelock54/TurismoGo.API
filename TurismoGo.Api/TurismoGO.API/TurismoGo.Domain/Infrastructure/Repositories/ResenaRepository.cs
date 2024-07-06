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
    public class ResenaRepository : IResenaRepository
    {
        private readonly TurismoDbContext _context;

        public ResenaRepository(TurismoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reseña>> GetResenas()
        {
            return await _context.Reseña.ToListAsync();
        }

        public async Task<Reseña> GetResenaById(int id)
        {
            var resena = await _context.Reseña.FindAsync(id);
            if (resena == null)
            {
                throw new Exception("Resena not found");
            }
            return resena;
        }

        public async Task InsertResena(Reseña resena)
        {
            await _context.Reseña.AddAsync(resena);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateResena(Reseña resena)
        {
            _context.Reseña.Update(resena);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> DeleteResena(int id)
        {
            var resena = await _context.Reseña.FindAsync(id);
            if (resena == null)
            {
                return false;
            }
            _context.Reseña.Remove(resena);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }
    }

}

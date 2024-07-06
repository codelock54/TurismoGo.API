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
    public class RolRepository : IRolRepository
    {
        private readonly TurismoDbContext _context;

        public RolRepository(TurismoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rol>> GetRoles()
        {
            return await _context.Rol.ToListAsync();
        }

        public async Task<Rol> GetRolById(int id)
        {
            var rol = await _context.Rol.FindAsync(id);
            if (rol == null)
            {
                throw new Exception("Rol not found");
            }
            return rol;
        }

        public async Task InsertRol(Rol rol)
        {
            await _context.Rol.AddAsync(rol);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateRol(Rol rol)
        {
            _context.Rol.Update(rol);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> DeleteRol(int id)
        {
            var rol = await _context.Rol.FindAsync(id);
            if (rol == null)
            {
                return false;
            }
            _context.Rol.Remove(rol);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }
    }

}

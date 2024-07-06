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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TurismoDbContext _context;

        public UsuarioRepository(TurismoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                throw new Exception("Usuario not found");
            }
            return usuario;
        }

        public async Task InsertUsuario(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateUsuario(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return false;
            }
            _context.Usuario.Remove(usuario);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }
    }

}

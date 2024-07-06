using TurismoGo.Domain.CORE.Entity;

namespace TurismoGo.Domain.CORE.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<bool> DeleteUsuario(int id);
        Task<Usuario> GetUsuarioById(int id);
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task InsertUsuario(Usuario usuario);
        Task<bool> UpdateUsuario(Usuario usuario);
    }
}
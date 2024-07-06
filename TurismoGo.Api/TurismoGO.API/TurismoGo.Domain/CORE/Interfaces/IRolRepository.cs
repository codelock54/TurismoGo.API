using TurismoGo.Domain.CORE.Entity;

namespace TurismoGo.Domain.CORE.Interfaces
{
    public interface IRolRepository
    {
        Task<bool> DeleteRol(int id);
        Task<Rol> GetRolById(int id);
        Task<IEnumerable<Rol>> GetRoles();
        Task InsertRol(Rol rol);
        Task<bool> UpdateRol(Rol rol);
    }
}
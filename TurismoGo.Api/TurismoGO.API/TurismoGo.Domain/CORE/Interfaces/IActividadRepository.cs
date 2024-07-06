using TurismoGo.Domain.CORE.Entity;

namespace TurismoGo.Domain.CORE.Interfaces
{
    public interface IActividadRepository
    {
        Task<IEnumerable<Actividad>> GetActividades();
        Task<Actividad> GetActividadById(int id);
        Task InsertActividad(Actividad actividad);
        Task<bool> UpdateActividad(Actividad actividad);
        Task<bool> DeleteActividad(int id);
    }
}
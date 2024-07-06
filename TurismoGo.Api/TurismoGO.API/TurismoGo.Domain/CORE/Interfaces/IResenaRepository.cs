using TurismoGo.Domain.CORE.Entity;

namespace TurismoGo.Domain.CORE.Interfaces
{
    public interface IResenaRepository
    {
        Task<bool> DeleteResena(int id);
        Task<Reseña> GetResenaById(int id);
        Task<IEnumerable<Reseña>> GetResenas();
        Task InsertResena(Reseña resena);
        Task<bool> UpdateResena(Reseña resena);
    }
}
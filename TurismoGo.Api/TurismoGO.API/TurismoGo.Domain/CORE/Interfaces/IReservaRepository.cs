using TurismoGo.Domain.CORE.Entity;

namespace TurismoGo.Domain.CORE.Interfaces
{
    public interface IReservaRepository
    {
        Task<bool> DeleteReserva(int id);
        Task<Reserva> GetReservaById(int id);
        Task<IEnumerable<Reserva>> GetReservas();
        Task InsertReserva(Reserva reserva);
        Task<bool> UpdateReserva(Reserva reserva);
    }
}
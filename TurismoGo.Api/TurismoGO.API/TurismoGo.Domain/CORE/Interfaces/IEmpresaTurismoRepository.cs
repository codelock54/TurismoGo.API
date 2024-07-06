using TurismoGo.Domain.CORE.Entity;

namespace TurismoGo.Domain.CORE.Interfaces
{
    public interface IEmpresaTurismoRepository
    {
        Task<bool> DeleteEmpresaTurismo(int id);
        Task<IEnumerable<EmpresaTurismo>> GetEmpresasTurismo();
        Task<EmpresaTurismo> GetEmpresaTurismoById(int id);
        Task InsertEmpresaTurismo(EmpresaTurismo empresaTurismo);
        Task<bool> UpdateEmpresaTurismo(EmpresaTurismo empresaTurismo);
    }
}
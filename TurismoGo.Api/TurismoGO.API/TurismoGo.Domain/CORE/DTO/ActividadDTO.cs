using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoGo.Domain.CORE.DTO
{
    public class CrearActividadDTO
    {
       public string NombreActividad { get; set; } = null!;
       public string Descripcion { get; set; } = null!;
       public string Destino { get; set; } = null!;
       public DateOnly FechaInicio { get; set; }
       public DateOnly FechaFin { get; set; }
       public decimal Precio { get; set; }
       public int IdEmpresa { get; set; }
    }
    public class ActividadSinEmpresaDTO
    {
        public int IdActividad { get; set; }
        public string NombreActividad { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Destino { get; set; } = null!;
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public decimal Precio { get; set; }
    }
}

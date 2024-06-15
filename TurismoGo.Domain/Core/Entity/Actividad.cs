using System;
using System.Collections.Generic;

namespace TurismoGo.Domain.Core.Entity;

public partial class Actividad
{
    public int IdActividad { get; set; }

    public string NombreActividad { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Destino { get; set; }

    public string? FechaInicio { get; set; }

    public string? FechaFin { get; set; }

    public decimal? Precio { get; set; }

    public int IdEmpresa { get; set; }

    public virtual EmpresaTurismo IdEmpresaNavigation { get; set; } = null!;

    public virtual ICollection<Reserva> Reserva { get; set; } = new List<Reserva>();

    public virtual ICollection<Reseña> Reseña { get; set; } = new List<Reseña>();
}

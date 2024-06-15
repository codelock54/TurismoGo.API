using System;
using System.Collections.Generic;

namespace TurismoGo.Domain.Core.Entity;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public int IdUsuario { get; set; }

    public int IdActividad { get; set; }

    public DateTime? FechaReserva { get; set; }

    public int? CantidadPersonas { get; set; }

    public string? Estado { get; set; }

    public virtual Actividad IdActividadNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}

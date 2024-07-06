using System;
using System.Collections.Generic;

namespace TurismoGo.Domain.CORE.Entity;

public partial class Reserva
{
    public int IdReserva { get; set; }

    public int IdUsuario { get; set; }

    public int IdActividad { get; set; }

    public DateOnly FechaReserva { get; set; }

    public int CantidadPersonas { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Actividad IdActividadNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}

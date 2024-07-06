using System;
using System.Collections.Generic;

namespace TurismoGo.Domain.CORE.Entity;

public partial class Reseña
{
    public int IdReseña { get; set; }

    public int IdUsuario { get; set; }

    public int IdActividad { get; set; }

    public string Comentario { get; set; } = null!;

    public int Valoracion { get; set; }

    public DateOnly FechaReseña { get; set; }

    public virtual Actividad IdActividadNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}

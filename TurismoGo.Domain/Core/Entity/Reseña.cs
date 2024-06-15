using System;
using System.Collections.Generic;

namespace TurismoGo.Domain.Core.Entity;

public partial class Reseña
{
    public int IdReseña { get; set; }

    public int IdUsuario { get; set; }

    public int IdActividad { get; set; }

    public string? Comentario { get; set; }

    public int? Valoracion { get; set; }

    public DateTime? FechaReseña { get; set; }

    public virtual Actividad IdActividadNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}

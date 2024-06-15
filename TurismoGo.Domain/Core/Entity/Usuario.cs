using System;
using System.Collections.Generic;

namespace TurismoGo.Domain.Core.Entity;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int IdRol { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Reserva> Reserva { get; set; } = new List<Reserva>();

    public virtual ICollection<Reseña> Reseña { get; set; } = new List<Reseña>();
}

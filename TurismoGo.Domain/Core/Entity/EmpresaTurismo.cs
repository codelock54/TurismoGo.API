using System;
using System.Collections.Generic;

namespace TurismoGo.Domain.Core.Entity;

public partial class EmpresaTurismo
{
    public int IdEmpresa { get; set; }

    public string NombreEmpresa { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string CorreoElectronico { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Actividad> Actividad { get; set; } = new List<Actividad>();
}

using System;
using System.Collections.Generic;

namespace TurismoGo.Domain.CORE.Entity;

public partial class EmpresaTurismo
{
    public int IdEmpresa { get; set; }

    public string NombreEmpresa { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public DateOnly FechaRegistro { get; set; }

    public virtual ICollection<Actividad> Actividad { get; set; } = new List<Actividad>();
}

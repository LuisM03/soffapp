using System;
using System.Collections.Generic;

namespace soffapp.Models;

public partial class Proveedor
{
    public long IdProveedor { get; set; }

    public long IdInsumo { get; set; }

    public string Nombre { get; set; } = null!;

    public string Empresa { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string Correo { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual Insumo IdInsumoNavigation { get; set; } = null!;
}

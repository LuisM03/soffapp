using System;
using System.Collections.Generic;

namespace soffapp.Models;

public partial class Compra
{
    public long IdCompra { get; set; }

    public DateTime? FechaCompra { get; set; }

    public long? IdProveedor { get; set; }

    public decimal? Total { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<OrdenCompra> OrdenCompras { get; set; } = new List<OrdenCompra>();
}

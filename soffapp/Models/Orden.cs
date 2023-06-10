using System;
using System.Collections.Generic;

namespace soffapp.Models;

public partial class Orden
{
    public long IdOrden { get; set; }

    public long? IdVenta { get; set; }

    public long? IdProducto { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Total { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Ventum? IdVentaNavigation { get; set; }
}

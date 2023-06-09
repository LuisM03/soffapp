﻿using System;
using System.Collections.Generic;

namespace soffapp.Models;

public partial class OrdenCompra
{
    public long IdOrden { get; set; }

    public long? IdCompra { get; set; }

    public long? IdInsumo { get; set; }

    public string? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? Total { get; set; }

    public virtual Compra? IdCompraNavigation { get; set; }

    public virtual Insumo? IdInsumoNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace soffapp.Models;

public partial class Ventum
{
    public long IdVenta { get; set; }

    public DateTime? FechaVenta { get; set; }

    public long? Metodo { get; set; }

    public decimal? Total { get; set; }

    public string? TipoVenta { get; set; }
}

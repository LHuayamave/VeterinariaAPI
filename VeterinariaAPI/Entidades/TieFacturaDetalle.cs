using System;
using System.Collections.Generic;

namespace VeterinariaAPI.Entidades;

public partial class TieFacturaDetalle
{
    public int IdFacturaDetalle { get; set; }

    public int IdFacturaCabecera { get; set; }

    public string NombreProducto { get; set; }

    public double PrecioProducto { get; set; }

    public int CantidadProducto { get; set; }

    public double SubtotalProducto { get; set; }

    public virtual TieFacturaCabecera oIdFacturaCabecera{ get; set; }
}

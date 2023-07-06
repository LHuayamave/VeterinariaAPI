using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VeterinariaAPI.Entidades;

public partial class TieFacturaDetalle
{
    public int IdFacturaDetalle { get; set; }

    public int? IdFacturaCabecera { get; set; }

    public string NombreProducto { get; set; }

    public double PrecioProducto { get; set; }

    public int CantidadProducto { get; set; }

    public double SubtotalProducto { get; set; }
    [JsonIgnore]
    public virtual TieFacturaCabecera IdFacturaCabeceraNavigation { get; set; }
}

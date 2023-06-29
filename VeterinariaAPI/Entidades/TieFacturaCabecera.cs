using System;
using System.Collections.Generic;

namespace VeterinariaAPI.Entidades;

public partial class TieFacturaCabecera
{
    public int IdFacturaCabecera { get; set; }

    public int IdEmpresa { get; set; }

    public int IdUsuario { get; set; }

    public string NumeroFactura { get; set; }

    public DateTime FechaFacturaCreacion { get; set; }

    public int IdCliente { get; set; }

    public string NombreCliente { get; set; }

    public string NumDocumentoCliente { get; set; }

    public double SubtotalFactura { get; set; }

    public double Iva { get; set; }

    public double TotalFactura { get; set; }

    public string Observaciones { get; set; }

    public string EstadoFacturaCabecera { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; }

    public virtual TieEmpresa IdEmpresaNavigation { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; }

    public virtual ICollection<TieFacturaDetalle> TieFacturaDetalles { get; set; } = new List<TieFacturaDetalle>();

    public virtual ICollection<TieFacturaFormaPago> TieFacturaFormaPagos { get; set; } = new List<TieFacturaFormaPago>();
}

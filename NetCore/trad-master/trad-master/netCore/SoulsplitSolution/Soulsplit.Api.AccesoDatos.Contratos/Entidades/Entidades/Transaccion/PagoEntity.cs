using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("Pago")]
    public class PagoEntity : Auditoria, IBaseWithIdEntity
    {
        public Guid Id { get; set; }
        [StringLength(120)]
        public string Nombres { get; set; }
        [StringLength(13)]
        public string Identificacion { get; set; }
        [StringLength(20)]
        public string TipoIdentificacion { get; set; }
        [StringLength(80)]
        public string Email { get; set; }
        [StringLength(120)]

        public string UrlImagen { get; set; }
        [StringLength(120)]
        public string IdImagen { get; set; }
        public string RespuestaCDN { get; set; }

        [StringLength(80)]
        public string Comprobante { get; set; }
        [StringLength(40)]
        public string CuentaDeposito { get; set; }
        [StringLength(120)]
        public string IdTransaccional { get; set; }
        [StringLength(120)]
        public string NumeroTarjeta { get; set; }
        [StringLength(120)]
        public string RequestId { get; set; }
        [StringLength(120)]
        public string Referencia { get; set; }
        [StringLength(120)]
        public string NombreOperador { get; set; }
        [StringLength(120)]
        public string Autorizacion { get; set; }
        [StringLength(120)]
        public string Recibo { get; set; }
        [StringLength(120)]

        public string MetodoPago { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaAprobacion { get; set; }
        #region Relaciones
        public Guid PersonaId { get; set; }
        public virtual PersonaEntity Persona { get; set; }

        public Guid CuentaId { get; set; }
        public virtual CuentaEntity Cuenta { get; set; }

        public Guid FormaPagoId { get; set; }
        public virtual FormaPagoEntity FormaPago { get; set; }
        public Guid EstadoPagoId { get; set; }
        public virtual DetalleEstadoEntity EstadoPago { get; set; }

        public Guid? UsuarioConciliacionId { get; set; }
        public virtual UsuarioEntity UsuarioConciliacion { get; set; }
        public virtual ICollection<HistorialPagoEntity> HistorialPagos { get; set; }
        #endregion
    }
}

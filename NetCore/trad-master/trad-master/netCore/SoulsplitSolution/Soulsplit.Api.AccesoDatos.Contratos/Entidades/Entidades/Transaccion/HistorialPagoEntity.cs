using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("HistorialPago")]
    public class HistorialPagoEntity : Auditoria, IBaseWithIdEntity
    {
        public Guid Id { get; set; }

        [StringLength(120)]
        public string EstadoConciliacion { get; set; }
        [StringLength(80)]
        public string Comprobante { get; set; }
        [StringLength(120)]
        public string NombreOperador { get; set; }
        [StringLength(1024)]
        public string Observacion { get; set; }

        public DateTime FechaRespuesta { get; set; }
        #region Relaciones

        public Guid PagoId { get; set; }
        public virtual PagoEntity Pago { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual UsuarioEntity Usuario { get; set; }

        public Guid EstadoPagoId { get; set; }
        public virtual DetalleEstadoEntity EstadoPago { get; set; }
        #endregion
    }
}

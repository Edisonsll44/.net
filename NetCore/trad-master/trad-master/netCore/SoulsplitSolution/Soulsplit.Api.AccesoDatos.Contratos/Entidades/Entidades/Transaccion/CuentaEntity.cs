using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("Cuenta")]
    public class CuentaEntity : Auditoria, IBaseWithIdEntity
    {
        public Guid Id { get; set; }
        [StringLength(30)]
        public string NumeroCuenta { get; set; }
        [StringLength(120)]
        public string Nombres { get; set; }
        [StringLength(20)]
        public string Identificacion { get; set; }
        [StringLength(20)]
        public string TipoIdentificacion { get; set; }
        [StringLength(80)]
        public string Email { get; set; }
        #region Relaciones
        public Guid BancoId { get; set; }
        public virtual BancoEntity Banco { get; set; }
        public Guid TipoCuentaId { get; set; }
        public virtual TipoCuentaEntity TipoCuenta { get; set; }
        public virtual ICollection<PagoEntity> Pagos { get; set; }
        #endregion
    }
}

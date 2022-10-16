using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("TipoCuenta")]
    public class TipoCuentaEntity : Auditoria, IBaseWithIdEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(120)]
        public string Nombre { get; set; }

        [StringLength(30)]
        public string Codigo { get; set; }

        #region Relaciones
        public virtual ICollection<CuentaEntity> Cuentas { get; set; }
        #endregion
    }
}

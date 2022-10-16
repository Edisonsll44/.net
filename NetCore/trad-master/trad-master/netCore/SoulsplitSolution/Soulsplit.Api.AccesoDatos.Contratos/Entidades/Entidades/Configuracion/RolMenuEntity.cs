using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("RolMenu")]
    public class RolMenuEntity : Auditoria, IBaseWithIdEntity
    {
        public Guid Id { get; set; }
        #region Relaciones
        public Guid RolId { get; set; }
        public virtual RolEntity Rol { get; set; }
        public Guid MenuId { get; set; }
        public virtual MenuEntity Menu { get; set; }
        #endregion
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("RolUsuario")]
    public class RolUsuarioEntity : Auditoria, IBaseWithIdEntity
    {
        [Key]
        public Guid Id { get; set; }
        #region Relaciones
        public Guid RolId { get; set; }
        public virtual RolEntity Rol { get; set; }
        public Guid UsuarioId { get; set; }
        public virtual UsuarioEntity Usuario { get; set; }
        #endregion
    }
}
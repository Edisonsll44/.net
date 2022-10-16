using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("Rol")]
    public class RolEntity : Auditoria, IBaseWithIdEntity
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Rol requerido")]
        public string NombreRol { get; set; }
        public bool RolInstalacion { get; set; }
        #region Relaciones
        public virtual ICollection<RolMenuEntity> RolesMenu { get; set; }
        public virtual ICollection<RolUsuarioEntity> RolesUsuario { get; set; }
        #endregion
    }
}

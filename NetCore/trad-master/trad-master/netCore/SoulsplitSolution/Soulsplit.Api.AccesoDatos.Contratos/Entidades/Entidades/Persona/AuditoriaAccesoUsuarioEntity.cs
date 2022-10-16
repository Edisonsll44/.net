using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("AuditoriaAccesoUsuario")]
    public class AuditoriaAccesoUsuarioEntity : Auditoria, IBaseWithIdEntity
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "El código de acceso es requerido")]
        [StringLength(maximumLength: 40)]
        public string CodigoConfirmacion { get; set; }
        public DateTime? FechaIngreso { get; set; }

        #region Relaciones
        public Guid UsuarioId { get; set; }
        public virtual UsuarioEntity Usuario { get; set; }
        #endregion

    }
}

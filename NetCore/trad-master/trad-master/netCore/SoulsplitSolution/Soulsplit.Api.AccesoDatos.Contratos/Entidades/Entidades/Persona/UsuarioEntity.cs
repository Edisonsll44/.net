using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("Usuario")]
    public class UsuarioEntity : Auditoria, IBaseWithIdEntity
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(40)]
        [Required]
        public string NombreUsuario { get; set; }

        [StringLength(60)]
        [Required]
        public string Email { get; set; }

        [StringLength(100)]
        public string Clave { get; set; }
        [StringLength(100)]
        public string CodigoReferencia { get; set; }

        [StringLength(1024)]
        public string Token { get; set; }

        [StringLength(1024)]
        public string RefreshToken { get; set; }

        [StringLength(10)]
        public string CodigoOTP { get; set; }
        public DateTime? VencimientoToken { get; set; }
        public bool EmailConfirmado { get; set; }
        public bool Bloqueado { get; set; }
        public bool OlvidoClave { get; set; }
        public bool SesionActiva { get; set; }
        public bool EsAdministrador { get; set; }
        public bool VerificoCelular { get; set; }
        public short? NumeroIntentos { get; set; }
        public string FotoUsuario { get; set; }

        #region Relaciones
        public Guid PersonaId { get; set; }
        public virtual PersonaEntity Persona { get; set; }
        public virtual ICollection<AuditoriaAccesoUsuarioEntity> AuditoriaAccesoUsuarios { get; set; }
        public virtual ICollection<RolUsuarioEntity> RolesUsuario { get; set; }
        public virtual ICollection<PagoEntity> Pagos { get; set; }
        #endregion
    }
}

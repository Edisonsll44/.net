using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("Persona")]
    public class PersonaEntity : Auditoria, IBaseWithIdEntity
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Nombres { get; set; }

        [StringLength(50)]
        public string Apellidos { get; set; }
        [StringLength(20)]
        [Required]
        public string Identificacion { get; set; }

        [StringLength(200)]
        public string RazonSocial { get; set; }

        [StringLength(300)]
        public string Compuesto { get; set; }

        [StringLength(200)]
        public string NombreComercial { get; set; }

        [StringLength(80)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Telefono { get; set; }
        [StringLength(20)]
        public string Celular { get; set; }


        public DateTime? FechaNacimiento { get; set; }
        public decimal SaldoActual { get; set; }

        public string Direccion { get; set; }

        #region Relaciones
        public Guid? TelefonoPaisId { get; set; }
        public virtual PaisEntity TelefonoPais { get; set; }
        public Guid TipoIdentificacionId { get; set; }
        public virtual TipoIdentificacionEntity TipoIdentificacion { get; set; }
        public virtual UsuarioEntity Usuario { get; set; }
        public virtual ICollection<ReferidosPersonaEntity> ReferidosPersona { get; set; }
        public virtual ICollection<PagoEntity> Pagos { get; set; }
        #endregion

    }
}

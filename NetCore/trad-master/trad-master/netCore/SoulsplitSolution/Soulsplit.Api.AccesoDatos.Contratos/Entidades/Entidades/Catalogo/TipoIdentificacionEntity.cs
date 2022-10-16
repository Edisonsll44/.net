using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("TipoIdentificacion")]
    public class TipoIdentificacionEntity : Auditoria, IBaseWithIdEntity
    {
        public Guid Id { get; set; }

        [StringLength(60)]
        [Required]
        public string Nombre { get; set; }
        public short LongitudMaxima { get; set; }
        public short LongitudMinima { get; set; }

        [Display(Name = "Bandera que permite mostrar las nacionalidades, siempre y cuando este activada")]
        public bool AplicaNacionalidad { get; set; }
        public string AlgoritmoValidacion { get; set; }
        #region Relaciones
        public Guid PaisId { get; set; }
        public virtual PaisEntity Pais { get; set; }
        public Guid TipoPersonaId { get; set; }
        public virtual TipoPersonaEntiy TipoPersona { get; set; }
        public virtual ICollection<PersonaEntity> Personas { get; set; }
        #endregion
    }
}

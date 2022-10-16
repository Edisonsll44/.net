using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("TipoPersona")]
    public class TipoPersonaEntiy : Auditoria, IBaseWithIdEntity
    {
        public Guid Id { get; set; }

        [StringLength(20)]
        [Required]
        public string Nombre { get; set; }

        #region Relaciones
        public virtual ICollection<TipoIdentificacionEntity> TiposIdentificacion { get; set; }
        #endregion
    }
}

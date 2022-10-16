using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("ReferidosPersona")]
    public class ReferidosPersonaEntity : Auditoria, IBaseWithIdEntity
    {
        public Guid Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Guid ReferidoId { get; set; }

        #region Relaciones
        public Guid PersonaId { get; set; }
        public virtual PersonaEntity Persona { get; set; }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("EstadoEnumeracion")]
    public class EstadoEnumeracionEntity : Auditoria, IBaseWithIdEntity
    {
        public Guid Id { get; set; }
        [StringLength(maximumLength: 60)]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 20)]
        public string Codigo { get; set; }

        #region Relaciones
        public virtual ICollection<DetalleEstadoEntity> Detalles { get; set; }
        #endregion
    }
}

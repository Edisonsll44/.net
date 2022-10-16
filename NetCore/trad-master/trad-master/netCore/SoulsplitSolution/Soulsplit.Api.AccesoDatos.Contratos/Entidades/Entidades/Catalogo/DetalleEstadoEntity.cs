using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("DetalleEstado")]
    public class DetalleEstadoEntity : Auditoria, IBaseWithIdEntity
    {
        public Guid Id { get; set; }
        [StringLength(maximumLength: 60)]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 20)]
        public string Codigo { get; set; }


        #region Relaciones

        public Guid EstadoEnumeracionId { get; set; }
        public virtual EstadoEnumeracionEntity EstadoEnumeracion { get; set; }
        public virtual ICollection<RolMenuEntity> RolMenus { get; set; }
        #endregion
    }
}

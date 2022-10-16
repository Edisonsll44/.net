using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("Pais")]
    public class PaisEntity : Auditoria, IBaseWithIdEntity
    {
        public PaisEntity()
        {
            TipoIdentificaciones = new HashSet<TipoIdentificacionEntity>();
        }
        public Guid Id { get; set; }

        [StringLength(120)]
        [Required]
        public string NombrePais { get; set; }

        [StringLength(120)]
        public string Nacionalidad { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        [StringLength(7)]
        public string CodigoRegional { get; set; }
        [StringLength(7)]
        public string CodigoPais { get; set; }
        [StringLength(120)]
        public string Bandera { get; set; }

        #region Relaciones
        public virtual ICollection<TipoIdentificacionEntity> TipoIdentificaciones { get; set; }
        #endregion
    }
}

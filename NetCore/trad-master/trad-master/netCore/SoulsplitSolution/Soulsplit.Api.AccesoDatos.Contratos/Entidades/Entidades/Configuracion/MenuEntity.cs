using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    [Table("Menu")]
    public class MenuEntity : Auditoria, IBaseWithIdEntity
    {
        public Guid Id { get; set; }

        [StringLength(maximumLength: 80)]
        public string NombrePagina { get; set; }

        [StringLength(maximumLength: 120)]
        public string IconoMenu { get; set; }

        [StringLength(maximumLength: 120)]
        public string UrlMenu { get; set; }
        public int Orden { get; set; }
        public bool PorDefecto { get; set; }

        #region Relaciones
        public Guid? PadreId { get; set; }
        public virtual MenuEntity Padre { get; set; }
        public virtual ICollection<RolMenuEntity> RolesMenus { get; set; }
        #endregion
    }
}

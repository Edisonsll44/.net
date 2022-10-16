using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    public class FuncionalidadEntity : Auditoria, IBaseWithIdEntity
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "El nombre de la funcionalidad es requerido")]
        [StringLength(30)]
        public string NombreFuncionalidad { get; set; }

        #region Relaciones
        public virtual ICollection<FuncionalidadParametroSistemaEntity> FuncionalidadesParametroSistema { get; set; }
        #endregion
    }
}

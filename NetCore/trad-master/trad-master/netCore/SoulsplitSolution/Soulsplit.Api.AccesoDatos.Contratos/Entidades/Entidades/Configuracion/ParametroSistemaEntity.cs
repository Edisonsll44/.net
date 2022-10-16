using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Soulsplit.Api.AccesoDatos.Contratos
{
    public class ParametroSistemaEntity : Auditoria, IBaseWithIdEntity
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "El nombre del parametro es obligatorio")]
        [StringLength(50)]
        public string NombreParametro { get; set; }

        public string DescripcionParametro { get; set; }
        [StringLength(1024)]
        public string Valor1 { get; set; }
        [StringLength(100)]
        public string Valor2 { get; set; }
        [StringLength(100)]
        public string Valor3 { get; set; }

        #region Relaciones
        public virtual ICollection<FuncionalidadParametroSistemaEntity> FuncionalidadesParametroSiste { get; set; }
        #endregion
    }
}

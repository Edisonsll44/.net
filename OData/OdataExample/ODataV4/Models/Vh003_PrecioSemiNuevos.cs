using System;

namespace ODataV4.Models
{
    public class Vh003_PrecioSemiNuevos
    {
        public long Id { get; set; }
        public decimal PrecioVentaPublico { get; set; }
        public DateTime FechaVigencia { get; set; }
        #region Relaciones
        public long SemiNuevoId { get; set; }
        public virtual Vh002_SemiNuevos SemiNuevo { get; set; }
        #endregion
    }
}
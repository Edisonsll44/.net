using OdataExample.Models;
using System;
using System.Collections.Generic;

namespace ODataV4.Models
{
    public enum EstadoSemiNuevo
    {
        Migrado = 1,
        EnProceso = 2,
        Finalizado = 3,
        Facturado = 4,
        Reservado = 5,
    }
    public class Vh002_SemiNuevos
    {
        public long Id { get; set; }
        public int Kilometraje { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public string EstadoCertificacion { get; set; }
        public string Descripcion { get; set; }
        public EstadoSemiNuevo EstadoSemiNuevo { get; set; }
        public string Observacion { get; set; }
        #region Relaciones
        public long VehiculoId { get; set; }
        public virtual Vh001_Vehiculo Vehiculo { get; set; }
        public virtual ICollection<Vh003_PrecioSemiNuevos> PreciosSemiNuevos { get; set; }
        #endregion
    }
}
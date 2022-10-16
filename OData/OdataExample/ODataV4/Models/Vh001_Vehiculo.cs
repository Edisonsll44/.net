using ODataV4.Models;
using System;
using System.Collections.Generic;

namespace OdataExample.Models
{
    public class Vh001_Vehiculo
    {
        public long Id { get; set; }
        public string Vin { get; set; }
        public int AnioModelo { get; set; }
        public string Placa { get; set; }
        public long EmpresaId { get; set; }
        public string EstadoVehiculo { get; set; }
        public string CodigoFsc { get; set; }
        public string NumeroCae { get; set; }
        public string NumeroCpn { get; set; }
        public string Motor { get; set; }
        public string Transmision { get; set; }
        public string CodigoImportacion { get; set; }
        public DateTime FechaProduccion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaRetail { get; set; }
        public DateTime FechaGarantia { get; set; }
        public DateTime FechaWholesale { get; set; }
        public DateTime FechaImportacion { get; set; }
        public DateTime FechaEmbarque { get; set; }
        public bool TieneFsc { get; set; }
        public DateTime? FechaMigracion { get; set; }
        public bool AutorizadoApp { get; set; }
        public virtual ICollection<Vh002_SemiNuevos> SemiNuevos { get; set; }

    }
}
using OdataExample.Models;
using ODataV4.Models;
using System.Data.Entity;

namespace OdataExample.Context
{
    public class BissContext: DbContext
    {
        public BissContext(): base("name=BissContext")
        {
        }
        public DbSet<Vh001_Vehiculo> Vehiculos { get; set; }
        public DbSet<Vh002_SemiNuevos> SemiNuevos { get; set; }
        public DbSet<Vh003_PrecioSemiNuevos> PrecioSemiNuevos { get; set; }
    }
}
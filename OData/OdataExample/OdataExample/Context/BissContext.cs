using OdataExample.Models;
using System.Data.Entity;

namespace OdataExample.Context
{
    public class BissContext: DbContext
    {
        public BissContext(): base("name=BissContext")
        {
        }
        public DbSet<Vh001_Vehiculo> Vehiculos { get; set; }
    }
}
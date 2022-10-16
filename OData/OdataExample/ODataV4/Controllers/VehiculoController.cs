using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using OdataExample.Context;
using OdataExample.Models;
using ODataV4.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace ODataV4.Controllers
{
    public class VehiculoController : ODataController
    {
        BissContext db = new BissContext();
        
        public IQueryable<Vh001_Vehiculo> Get()
        {
            var data = db.Vehiculos.Include("SemiNuevos");
            return data;
        }
        [EnableQuery]
        public SingleResult<Vh001_Vehiculo> Get([FromODataUri] int key)
        {
            IQueryable<Vh001_Vehiculo> result = db.Vehiculos.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        //[ODataRoute("Seminuevos({key})/Vehiculo")]
        public Vh002_SemiNuevos GetSeminuevo(long key)
        {
            return db.SemiNuevos.FirstOrDefault(t => t.Id == key);
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}

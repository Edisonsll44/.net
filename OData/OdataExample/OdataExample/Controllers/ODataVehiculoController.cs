using Microsoft.AspNet.OData;
using OdataExample.Context;
using OdataExample.Models;
using System.Linq;
using System.Web.Http;

namespace OdataExample.Controllers
{
    public class VehiculoController : ODataController
    {
        BissContext db = new BissContext();

        [EnableQuery]
        [HttpGet]
        [Route("GetVh")]
        public IQueryable<Vh001_Vehiculo> GetVehiculos()
        {
            return db.Vehiculos;
        }

        //[EnableQuery]
        //public SingleResult<Vh001_Vehiculo> ObtenerVehiculos([FromODataUri] int key)
        //{
        //    IQueryable<Vh001_Vehiculo> result = db.Vehiculos.Where(p => p.Id == key);
        //    return SingleResult.Create(result);
        //}

        //private bool ExisteVehiculo(long id)
        //{
        //    return db.Vehiculos.Any(p => p.Id == id);
        //}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
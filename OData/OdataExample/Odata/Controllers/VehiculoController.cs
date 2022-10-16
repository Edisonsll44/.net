using OdataExample.Context;
using OdataExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace Odata.Controllers
{
    public class VehiculoController : ApiController
    {
        readonly BissContext db = new BissContext();

        [EnableQuery]
        public IQueryable<Vh001_Vehiculo> GetVehiculos()
        {
            try
            {
                return db.Vehiculos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           return null;
        }
    }
}


//($filter = Placa / any(s: endswith(s, '77')))
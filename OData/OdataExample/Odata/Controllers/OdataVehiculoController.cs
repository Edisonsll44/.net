using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using OdataExample.Models;
using Microsoft.Data.OData;

namespace Odata.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using OdataExample.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Vh001_Vehiculo>("OdataVehiculo");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class OdataVehiculoController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/OdataVehiculo
        public IHttpActionResult GetOdataVehiculo(ODataQueryOptions<Vh001_Vehiculo> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<IEnumerable<Vh001_Vehiculo>>(vh001_Vehiculo);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/OdataVehiculo(5)
        public IHttpActionResult GetVh001_Vehiculo([FromODataUri] long key, ODataQueryOptions<Vh001_Vehiculo> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Vh001_Vehiculo>(vh001_Vehiculo);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/OdataVehiculo(5)
        public IHttpActionResult Put([FromODataUri] long key, Delta<Vh001_Vehiculo> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(vh001_Vehiculo);

            // TODO: Save the patched entity.

            // return Updated(vh001_Vehiculo);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/OdataVehiculo
        public IHttpActionResult Post(Vh001_Vehiculo vh001_Vehiculo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(vh001_Vehiculo);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/OdataVehiculo(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] long key, Delta<Vh001_Vehiculo> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(vh001_Vehiculo);

            // TODO: Save the patched entity.

            // return Updated(vh001_Vehiculo);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/OdataVehiculo(5)
        public IHttpActionResult Delete([FromODataUri] long key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}

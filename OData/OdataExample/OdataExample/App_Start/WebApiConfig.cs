using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using OdataExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OdataExample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Vh001_Vehiculo>("Vehiculos");
            config.MapODataServiceRoute(
                routeName: "odata",
                routePrefix: "odata",
                model: builder.GetEdmModel());
        }
    }
}

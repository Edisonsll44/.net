using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.OData.Edm;
using OdataExample.Models;
using ODataV4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ODataV4
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null).Count();
            config.AddODataQueryFilter();
            config.MapODataServiceRoute("odata", "odata", GetEdmModel());
            //config.EnsureInitialized();
        }
        private static IEdmModel GetEdmModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder
            {
                Namespace = "Odata",
                ContainerName = "DefaultContainer",
            };
            builder.EntitySet<Vh001_Vehiculo>("Vehiculo");
            builder.EntitySet<Vh002_SemiNuevos>("SemiNuevos");
            builder.EntitySet<Vh003_PrecioSemiNuevos>("PrecioSeminuevo");
            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
    }
}

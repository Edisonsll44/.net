using Newtonsoft.Json;
using System;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class Pais
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("nacionalidad")]
        public string Nacionalidad { get; set; }
        [JsonProperty("latitud")]
        public decimal Latitud { get; set; }
        [JsonProperty("longitud")]
        public decimal Longitud { get; set; }
        [JsonProperty("codigoregional")]
        public string CodigoRegional { get; set; }
        [JsonProperty("codigoPais")]
        public string CodigoPais { get; set; }
        [JsonProperty("bandera")]
        public string Bandera { get; set; }
        [JsonProperty("accion")]
        public int Accion { get; set; }
    }


    public class DtoPais
    {
        public string name { get; set; }
        public string alpha2Code { get; set; }
        public string[] callingCodes { get; set; }
        public decimal?[] latlng { get; set; }
        public string capital { get; set; }
        public string demonym { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public string nativeName { get; set; }
        public string numericCode { get; set; }
        public string flag { get; set; }
        public string cioc { get; set; }
    }
}

using Newtonsoft.Json;
using System;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class TipoDocumentoDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("algoritmo")]
        public string Algorimo { get; set; }
        [JsonProperty("lmaxima")]
        public short LongitudMaxima { get; set; }
        [JsonProperty("lminima")]
        public short LongitudMinima { get; set; }
        [JsonProperty("aplicanacionalida")]
        public bool AplicaNacionalidad { get; set; }
        [JsonProperty("idpais")]
        public Guid PaisId { get; set; }
        [JsonProperty("tipopersona")]
        public Guid TipoPersonaId { get; set; }
    }
}
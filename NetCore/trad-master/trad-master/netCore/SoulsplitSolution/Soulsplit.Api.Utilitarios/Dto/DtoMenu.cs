using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class DtoMenu
    {
        [JsonProperty("title")]
        public string Titulo { get; set; }
        [JsonProperty("icon")]
        public string Icono { get; set; }
        [JsonProperty("href")]
        public string Url { get; set; }
    }

    public class DtoImagen
    {
        [JsonProperty("type")]
        public string type { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("base64")]
        public string base64 { get; set; }
    }


}

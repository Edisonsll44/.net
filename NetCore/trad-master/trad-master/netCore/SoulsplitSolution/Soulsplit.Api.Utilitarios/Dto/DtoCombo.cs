using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class DtoCombo
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("nombre")]
        public string nombre { get; set; }
        [JsonProperty("codigo")]
        public string codigo { get; set; }
        [JsonProperty("componente")]
        public string componente { get; set; }
    }
}

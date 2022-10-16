using Newtonsoft.Json;
using System;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class RolMenuDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("rolid")]
        public Guid RolId { get; set; }
        [JsonProperty("menuid")]
        public Guid MenuId { get; set; }
    }
}

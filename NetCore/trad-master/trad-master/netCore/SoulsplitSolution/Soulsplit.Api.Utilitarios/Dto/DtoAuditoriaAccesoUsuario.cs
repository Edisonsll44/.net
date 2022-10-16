using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class DtoAuditoriaAccesoUsuario
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("codigo")]
        public string CodigoConfirmacion { get; set; }
        [JsonProperty("fecha")]
        public DateTime FechaIngreso { get; set; }
        [JsonProperty("idUsuario")]
        public Guid UsuarioId { get; set; }
    }
}

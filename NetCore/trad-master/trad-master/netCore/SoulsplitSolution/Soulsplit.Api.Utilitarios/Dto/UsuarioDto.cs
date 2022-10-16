using Newtonsoft.Json;
using System;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class UsuarioDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("usuario")]
        public string NombreUsuario { get; set; }
        [JsonProperty("emailConfirmado")]
        public bool EmailConfirmado { get; set; }
        [JsonProperty("clave")]
        public string Clave { get; set; }
        [JsonProperty("sessionactiva")]
        public bool SesionActiva { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("referencia")]
        public string CodigoReferencia { get; set; }
        public int Accion { get; set; }
        public string Email { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string Rol { get; set; }
        [JsonProperty("rolId")]
        public Guid RolId { get; set; }
        [JsonProperty("rolUsuarioId")]
        public Guid RolUsuarioId { get; set; }
    }
}

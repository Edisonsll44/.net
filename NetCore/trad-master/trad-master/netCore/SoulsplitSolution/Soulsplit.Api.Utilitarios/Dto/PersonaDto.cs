using Newtonsoft.Json;
using System;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class PersonaDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("nombres")]
        public string Nombres { get; set; }
        [JsonProperty("apellidos")]
        public string Apellidos { get; set; }
        [JsonProperty("celular")]
        public string Telefono { get; set; }
        [JsonProperty("correo")]
        public string Email { get; set; }
        [JsonProperty("documento")]
        public string Identificacion { get; set; }
        [JsonProperty("TipoIdentificacionId")]
        public Guid TipoIdentificacionId { get; set; }
        [JsonProperty("usuario")]
        public UsuarioDto Usuario { get; set; }
        public int Accion { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("clave")]
        public string Clave { get; set; }
        [JsonProperty("referencia")]
        public string CodigoReferencia { get; set; }
        [JsonProperty("paisId")]
        public Guid Pais { get; set; }
        [JsonProperty("direccion")]
        public string Direccion { get; set; }
        [JsonProperty("imagenPerfil")]
        public string ImagenPerfil { get; set; }
    }
}

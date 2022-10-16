using Newtonsoft.Json;
using System;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class DtoCuenta : DtoPaginador
    {

        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("banco")]
        public string Banco { get; set; }
        [JsonProperty("TipoCuenta")]
        public string TipoCuenta { get; set; }
        [JsonProperty("nombres")]
        public string Nombres { get; set; }
        [JsonProperty("cuenta")]
        public string NumeroCuenta { get; set; }
        [JsonProperty("identificacion")]
        public string Identificacion { get; set; }
        [JsonProperty("tipoIdentificacion")]
        public string TipoIdentificacion { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("bancoId")]
        public Guid BancoId { get; set; }
        [JsonProperty("tipoCuentaId")]
        public Guid TipoCuentaId { get; set; }
    }
}

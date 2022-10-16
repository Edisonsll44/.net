using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class ParametroSistemaDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("nombreparametro")]
        public string NombreParametro { get; set; }
        [JsonProperty("v1")]
        public string Valor1 { get; set; }
        [JsonProperty("v2")]
        public string Valor2 { get; set; }
        [JsonProperty("v3")]
        public string Valor3 { get; set; }

    }
    public class FuncionalidadSistemaDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("nombrefuncionalidad")]
        public string NombreFuncionalidad { get; set; }
        [JsonProperty("codigo")]
        public string CodigoReferencia { get; set; }
        public IEnumerable<ParametroSistemaDto> ParametrosSistema { get; set; }
    }

    public class FuncionalidadesParametroSistemaDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("idFuncionalidad")]
        public Guid IdFuncionalidad { get; set; }
        [JsonProperty("parametros")]
        public IEnumerable<Guid> ParametrosSistemaIds { get; set; }
    }
}

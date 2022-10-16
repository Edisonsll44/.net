using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Utilitarios.Dto
{

    public class DtoPusher
    {

        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("transaccion")]
        public string transaccion { get; set; }
    }

    public class DtoPaginador
    {
        [JsonProperty("ndt10")]
        public decimal Pagina { get; set; }
        [JsonProperty("ndt11")]
        public decimal Registros { get; set; }
        [JsonProperty("ndt12")]
        public decimal Accion { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
    }
    public class DtoRespuesta
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("dt1")]
        public string Dt1 { get; set; }
        [JsonProperty("dt2")]
        public string Dt2 { get; set; }
        [JsonProperty("dt3")]
        public string Dt3 { get; set; }
        [JsonProperty("bdt1")]
        public bool Bdt1 { get; set; } = true;
        [JsonProperty("bdt2")]
        public bool Bdt2 { get; set; } = true;
        [JsonProperty("bdt3")]
        public bool Bdt3 { get; set; } = true;
        [JsonProperty("bdt4")]
        public bool Bdt4 { get; set; } = true;
        [JsonProperty("bdt5")]
        public bool Bdt5 { get; set; } = true;
    }

    public class DtoLoginRespuesta
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("dt1")]
        public string Dt1 { get; set; }
        [JsonProperty("dt2")]
        public string Dt2 { get; set; }
        [JsonProperty("dt3")]
        public string Dt3 { get; set; }
        [JsonProperty("dt4")]
        public string Dt4 { get; set; }
        [JsonProperty("bdt1")]
        public bool Bdt1 { get; set; } = true;
        [JsonProperty("bdt2")]
        public bool Bdt2 { get; set; } = true;
        [JsonProperty("bdt3")]
        public bool Bdt3 { get; set; } = true;
        [JsonProperty("bdt4")]
        public bool Bdt4 { get; set; } = true;

        [JsonProperty("ndt1")]
        public decimal Ndt1 { get; set; }
        [JsonProperty("ndt2")]
        public decimal Ndt2 { get; set; }
        [JsonProperty("menu")]

        public IEnumerable<DtoMenu> menu { get; set; }
    }

    public static class Respuesta
    {
        public static Task<DtoRespuesta> DevolverRespuesta(string entidad, string accion)
        => Task.FromResult(new DtoRespuesta { Dt1 = $"{entidad}, {accion} correctamente" });
        public static Task<DtoRespuesta> DevolverRespuesta(string entidad, string accion, Guid id)
        => Task.FromResult(new DtoRespuesta { Dt1 = $"{entidad}, {accion} correctamente", Id = id });
        public static Task<DtoRespuesta> DevolverRespuesta(string entidad, string accion, string parametro, bool datos = false)
       => Task.FromResult(new DtoRespuesta { Dt1 = $"{entidad}, {accion} correctamente", Dt2 = parametro, Bdt1 = datos });
    }
}

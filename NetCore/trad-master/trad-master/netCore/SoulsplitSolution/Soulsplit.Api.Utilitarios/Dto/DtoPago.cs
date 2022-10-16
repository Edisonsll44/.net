using Newtonsoft.Json;
using System;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class DtoPago
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("nombres")]
        public string Nombres { get; set; }

        [JsonProperty("valor")]
        public decimal Valor { get; set; }
        [JsonProperty("fechaPago")]
        public DateTime FechaPago { get; set; }

        [JsonProperty("referencia")]
        public string Referencia { get; set; }
        [JsonProperty("formaPagoId")]
        public Guid FormaPagoId { get; set; }
        [JsonProperty("cuentaDeposito")]
        public string CuentaDeposito { get; set; }
        [JsonProperty("imagenComprobante")]
        public string ImagenComprobante { get; set; }

        public string Identificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Email { get; set; }
        public string UrlImagen { get; set; }
        public string RespuestaCDN { get; set; }
        public string Comprobante { get; set; }
        public string IdTransaccional { get; set; }
        public string NumeroTarjeta { get; set; }
        public string RequestId { get; set; }
        public string NombreOperador { get; set; }
        public string Autorizacion { get; set; }
        public string Recibo { get; set; }
        public string MetodoPago { get; set; }
        public string Estado { get; set; }
        public Guid EstadoId { get; set; }
    }

    public class DtoPagoConciliacion
    {
        [JsonProperty("idPago")]
        public Guid Id { get; set; }
        [JsonProperty("idEstado")]
        public Guid EstadoId { get; set; }
        [JsonProperty("observacion")]
        public string Observacion { get; set; }
    }
    public class DtoConsultaPago : DtoPaginador
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
        [JsonProperty("nombres")]
        public string Nombres { get; set; }

        [JsonProperty("valor")]
        public decimal Valor { get; set; }
        [JsonProperty("saldo")]
        public decimal Saldo { get; set; }
        [JsonProperty("fechaPago")]
        public DateTime FechaPago { get; set; }

        [JsonProperty("referencia")]
        public string Referencia { get; set; }
        [JsonProperty("banco")]
        public string Banco { get; set; }
        [JsonProperty("tipoCuenta")]
        public string TipoCuenta { get; set; }
        [JsonProperty("formaPago")]
        public string FormaPago { get; set; }
        [JsonProperty("cuentaDeposito")]
        public string CuentaDeposito { get; set; }
        [JsonProperty("identificacion")]
        public string Identificacion { get; set; }
        [JsonProperty("tipoIdentificacion")]
        public string TipoIdentificacion { get; set; }
        [JsonProperty("correo")]
        public string Email { get; set; }
        [JsonProperty("imagen")]
        public string UrlImagen { get; set; }
        [JsonProperty("estado")]
        public string Estado { get; set; }
        [JsonProperty("estadoId")]
        public Guid EstadoId { get; set; }
    }
}

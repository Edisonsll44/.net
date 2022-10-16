using System;

namespace Soulsplit.Api.Utilitarios.Dto
{
    public class DtoHistorialPago
    {
        public string EstadoConciliacion { get; set; }
        public string Comprobante { get; set; }
        public string NombreOperador { get; set; }
        public string Observacion { get; set; }

        public DateTime FechaRespuesta { get; set; }

        public Guid PagoId { get; set; }
        public Guid UsuarioId { get; set; }

        public Guid EstadoPagoId { get; set; }
    }
}

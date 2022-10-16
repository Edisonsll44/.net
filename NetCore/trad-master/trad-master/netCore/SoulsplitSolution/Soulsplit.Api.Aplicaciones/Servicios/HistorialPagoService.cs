using Soulpslit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.ContratosServicios;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class HistorialPagoService : IHistorialPagoService
    {
        private readonly IHistorialPagoRepository _historialPagoRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        public HistorialPagoService(
            IHistorialPagoRepository historialPagoRepository,
            IAuditoriaEntidadesService auditoriaEntidadesService)
        {
            _historialPagoRepository = historialPagoRepository;
            _auditoriaEntidadesService = auditoriaEntidadesService;
        }

        public async Task<DtoRespuesta> CrearHistorialPago(DtoHistorialPago dto)
        {
            try
            {
                var nuevoRegistro = HistorialPagoMapper.Map(dto);
                _auditoriaEntidadesService.InsertarDatosAuditoria(nuevoRegistro, usuario: "adm");
                nuevoRegistro = await _historialPagoRepository.Add(nuevoRegistro);
                return await Respuesta.DevolverRespuesta("Pago", "creado");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<DtoHistorialPago>> ObtenerHistorialPago(Guid idPago)
        {
            try
            {
                IEnumerable<HistorialPagoEntity> pagos = _historialPagoRepository.GetAll<HistorialPagoEntity>(x => x.PagoId == idPago);
                return await HistorialPagoMapper.Map(pagos);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


    }
}

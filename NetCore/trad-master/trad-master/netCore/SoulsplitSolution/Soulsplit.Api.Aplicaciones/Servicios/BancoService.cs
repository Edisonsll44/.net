using Soulpslit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class BancoService : IBancoService
    {
        private readonly IBancoRepository _bancoRepository;
        private readonly IAuditoriaEntidadesService _auditoriaEntidadesService;
        public BancoService(IBancoRepository bancoRepository, IAppConfig appConfig, IAuditoriaEntidadesService auditoriaEntidadesService)
        {
            _auditoriaEntidadesService = auditoriaEntidadesService;
            _bancoRepository = bancoRepository;
        }

        public async Task<DtoRespuesta> CrearBanco(DtoCombo dto)
        {
            var nuevoBanco = BancoMapper.Map(dto);
            _auditoriaEntidadesService.InsertarDatosAuditoria(nuevoBanco, usuario: "adm");
            nuevoBanco = await _bancoRepository.Add(nuevoBanco);
            return await Respuesta.DevolverRespuesta("Banco", "creado");
        }

        public async Task<IEnumerable<DtoCombo>> ObtenerBancos()
        {
            var Banco = await _bancoRepository.GetAll();
            return await BancoMapper.Map(Banco);
        }
    }
}

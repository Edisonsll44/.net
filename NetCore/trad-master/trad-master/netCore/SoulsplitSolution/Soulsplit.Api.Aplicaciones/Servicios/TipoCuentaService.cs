using Soulpslit.Api.AccesoDatos.Mapeos;
using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Aplicaciones.Servicios
{
    public class TipoCuentaService : ITipoCuentaService
    {
        private readonly ITipoCuentaRepository _tipoCuentaRepository;
        public TipoCuentaService(ITipoCuentaRepository TipoCuentaRepository)
        {
            _tipoCuentaRepository = TipoCuentaRepository;
        }

        public async Task<IEnumerable<DtoCombo>> ObtenerTipoCuentas()
        {
            var TipoCuenta = await _tipoCuentaRepository.GetAll();
            return await TipoCuentaMapper.Map(TipoCuenta);
        }
    }
}

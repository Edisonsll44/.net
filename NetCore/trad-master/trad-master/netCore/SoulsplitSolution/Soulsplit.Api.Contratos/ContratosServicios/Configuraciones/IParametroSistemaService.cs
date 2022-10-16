using Soulsplit.Api.Utilitarios.Dto;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos
{
    public interface IParametroSistemaService
    {
        Task<DtoRespuesta> CrearParametroSistema(ParametroSistemaDto dto);
        Task<DtoRespuesta> ModificarParametroSistema();
        Task<DtoRespuesta> EliminarParametroSistema();
    }
}

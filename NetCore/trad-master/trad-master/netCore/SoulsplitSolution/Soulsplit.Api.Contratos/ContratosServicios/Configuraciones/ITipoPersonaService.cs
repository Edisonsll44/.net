using Soulsplit.Api.Utilitarios.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos.ContratosServicios.Configuraciones
{
    public interface ITipoPersonaService
    {
        Task<DtoRespuesta> CrearTipoPersona(TipoPersonaDto dto);
        Task<DtoRespuesta> ModificarTipoPersona(TipoPersonaDto dto);
        Task<List<TipoPersonaDto>> ListarTipoPersonas();
    }
}
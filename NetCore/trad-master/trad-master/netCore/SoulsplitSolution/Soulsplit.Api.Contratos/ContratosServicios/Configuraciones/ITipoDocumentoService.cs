using Soulsplit.Api.Utilitarios.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos
{
    public interface ITipoDocumentoService
    {
        Task<DtoRespuesta> CrearTipoDocumento(TipoDocumentoDto dto);
        Task<DtoRespuesta> ModificarTipoDocumento(TipoDocumentoDto tipoDocumento);
        Task<List<TipoDocumentoDto>> ListarTipoDocumentos();
    }
}
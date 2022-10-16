using Soulsplit.Api.Utilitarios.Dto;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos
{
    public interface IFuncionalidadSistemaService
    {
        Task<DtoRespuesta> CrearFuncionalidadSistema(FuncionalidadSistemaDto dto);
        Task<DtoRespuesta> ModificarFuncionalidadSistema();
        Task<DtoRespuesta> EliminarFuncionalidadSistema();

    }
}

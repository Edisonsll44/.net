using Soulsplit.Api.Utilitarios.Dto;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos
{
    public interface IAuditoriaAccesoUsuarioService
    {
        Task<DtoRespuesta> CrearAuditoriaAccesoUsuario(DtoAuditoriaAccesoUsuario nuevaAuditoria);
    }
}

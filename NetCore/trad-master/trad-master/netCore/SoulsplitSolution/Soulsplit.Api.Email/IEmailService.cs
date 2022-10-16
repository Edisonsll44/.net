using Soulsplit.Api.Utilitarios.Dto;
using System.Threading.Tasks;

namespace Soulsplit.Api.Email
{
    public interface IEmailService
    {
        Task<DtoRespuesta> UsuarioOlvidoClave(Mensaje message);
        Task<DtoRespuesta> ActivarUsuarioNuevo(Mensaje message);
        Task<DtoRespuesta> CambioClave(Mensaje message);
        Task<DtoRespuesta> MailContacto(Mensaje message);
        Task<DtoRespuesta> EnvioCuentas(Mensaje message);
    }
}

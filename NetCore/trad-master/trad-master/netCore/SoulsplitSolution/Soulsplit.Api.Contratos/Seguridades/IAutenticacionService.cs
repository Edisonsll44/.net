using Soulsplit.Api.Utilitarios.Dto;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos.Seguridades
{
    public interface IAutenticacionService
    {
        Task<DtoLoginRespuesta> AutenticarUsuario(string usuario, string clave, string codigo);
        Task<DtoRespuesta> ActivarUsuario(string token);
        Task<DtoRespuesta> EnviarOTP(string mail, string clave);
        Task<DtoRespuesta> CerrarSessionActiva(string token);
    }
}

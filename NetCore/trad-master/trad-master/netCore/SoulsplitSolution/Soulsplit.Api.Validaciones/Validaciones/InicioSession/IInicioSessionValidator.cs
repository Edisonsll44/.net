using Soulsplit.Api.Utilitarios.Dto;
using System.Threading.Tasks;

namespace Soulsplit.Api.Validaciones.Validaciones
{
    public interface IInicioSessionValidator
    {
        Task ValidarDatosInicioSesion(AuthRequest credenciales);
        Task ValidarDatosOTP(AuthRequest credenciales);
        Task ValidarToken(AuthRequest usuario);

    }
}

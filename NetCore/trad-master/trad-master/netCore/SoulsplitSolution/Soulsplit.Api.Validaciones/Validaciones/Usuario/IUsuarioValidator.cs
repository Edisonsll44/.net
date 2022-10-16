using Soulsplit.Api.Utilitarios.Dto;
using System.Threading.Tasks;


namespace Soulsplit.Api.Validaciones.Validaciones
{
    public interface IUsuarioValidator
    {
        Task ValidarUsuario(UsuarioDto dto);
    }
}

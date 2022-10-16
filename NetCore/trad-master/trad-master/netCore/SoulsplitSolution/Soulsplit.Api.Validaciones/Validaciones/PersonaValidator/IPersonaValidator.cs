using Soulsplit.Api.Utilitarios.Dto;
using System.Threading.Tasks;

namespace Soulsplit.Api.Validaciones.Validaciones
{
    public interface IPersonaValidator
    {
        Task ValidarPersona(PersonaDto dto);
    }
}

using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;
using System.Threading.Tasks;

namespace Soulsplit.Api.Contratos.ContratosServicios
{
    public interface IPersonaService
    {
        Task<DtoRespuesta> CrearPersona(PersonaDto nuevaPersona, string token = "");
        Task<DtoLoginRespuesta> ActualizarPersona(PersonaDto nuevaPersona, string token);
        Task<DtoRespuesta> EliminarPersona(long idPersona);
        Task<DtoRespuesta> ReactivarPersona(long idPersona);
        Task<DtoRespuesta> BuscarPersonas(string nombres = "", string identificacion = "");

        Task<PersonaEntity> ObtenerPersona(Guid idPersona);
        Task<PersonaDto> ObtenerDatosPersona(string token);
        Task<DtoRespuesta> MailBienvenida(string email);
    }
}

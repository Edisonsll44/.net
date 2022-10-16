using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using System;

namespace Soulsplit.Api.AccesoDatos.Mapeos
{
    public static class PersonaMapper
    {
        public static PersonaDto Map(PersonaEntity dto)
        {
            return new PersonaDto
            {
                Id = dto.Id,
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                Email = dto.Email,
                Identificacion = dto.Identificacion,
                Telefono = dto.Telefono,
                Pais = dto.TelefonoPaisId ?? Guid.Empty,
                Direccion = dto.Direccion,
                ImagenPerfil = dto.Usuario.FotoUsuario,
                TipoIdentificacionId = dto.TipoIdentificacionId,
                CodigoReferencia = dto.Usuario.CodigoReferencia,
                Clave = dto.Usuario.Clave,
            };
        }

        public static PersonaEntity Map(PersonaDto dto)
        {
            return new PersonaEntity
            {
                Id = dto.Id,
                Nombres = dto.Nombres.Trim().ToUpper(),
                Apellidos = dto.Apellidos.Trim().ToUpper(),
                Email = dto.Email.ToLower(),
                Identificacion = dto.Identificacion,
                Telefono = dto.Telefono,
                TipoIdentificacionId = dto.TipoIdentificacionId,
                TelefonoPaisId = dto.Pais,
                Direccion = dto.Direccion,
            };
        }
    }
}

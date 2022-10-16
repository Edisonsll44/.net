using Soulsplit.Api.AccesoDatos.Contratos;
using Soulsplit.Api.Utilitarios.Dto;
using Soulsplit.Api.Utilitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Soulsplit.Api.AccesoDatos.Mapeos
{
    public static class UsuarioMapper
    {
        public static UsuarioEntity Map(string nombre, string apellido, string token, Guid personaId, string email, string clave, string codigoReferencia = null)
        {
            return new UsuarioEntity
            {
                Clave = ConfiguracionUsuario.CreateMD5Hash(clave),
                CodigoReferencia = string.IsNullOrEmpty(codigoReferencia)  ?  ConfiguracionUsuario.CrearCodigoReferencia(nombre) : codigoReferencia ,
                NombreUsuario = ConfiguracionUsuario.CrearUsuario(nombre, apellido),
                Token = token,
                Email = email.ToLower(),
                Bloqueado = false,
                EmailConfirmado = false,
                SesionActiva = false,
                PersonaId = personaId,
                Id = personaId
            };
        }

        public static UsuarioDto Map(UsuarioEntity entidad)
        {
            return new UsuarioDto
            {
                Clave = entidad.Clave,
                CodigoReferencia = entidad.CodigoReferencia,
                NombreUsuario = entidad.NombreUsuario,
                Token = entidad.Token,
                EmailConfirmado = entidad.EmailConfirmado,
                SesionActiva = entidad.SesionActiva
            };
        }

        public static Task<List<UsuarioDto>> Map(IEnumerable<UsuarioEntity> entidades)
        {
            var usuarios = new List<UsuarioDto>();
            entidades.ToList().ForEach(entidad => usuarios.Add(new UsuarioDto
            {
                Id = entidad.Id,
                NombreUsuario = entidad.NombreUsuario,
                Email = entidad.Email,
                Nombres = entidad.Persona.Nombres,
                Apellidos = entidad.Persona.Apellidos,
                Identificacion = entidad.Persona.Identificacion,
                Rol = entidad.RolesUsuario.FirstOrDefault().Rol.NombreRol,
                RolId = entidad.RolesUsuario.FirstOrDefault().RolId,
                RolUsuarioId = entidad.RolesUsuario.FirstOrDefault().RolId,
            }));
            return Task.FromResult(usuarios);
        }

    }
}

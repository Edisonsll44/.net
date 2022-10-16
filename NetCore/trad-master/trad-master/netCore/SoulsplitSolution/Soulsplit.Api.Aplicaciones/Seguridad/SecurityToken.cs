using Microsoft.IdentityModel.Tokens;
using Soulsplit.Api.Contratos;
using Soulsplit.Api.Contratos.Seguridad;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Soulsplit.Api.Aplicaciones.Seguridad
{
    public class SecurityToken : ISecurityToken
    {
        private readonly IAppConfig _appConfig;

        public SecurityToken(IAppConfig appConfig)
        {
            _appConfig = appConfig;
        }
        public string CrearToken(string nombreUsuario, Guid usuarioId, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appConfig.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioId.ToString()),
                    new Claim(ClaimTypes.Name, nombreUsuario),
                    new Claim(ClaimTypes.Email, email)
                }),
                Expires = DateTime.Now.AddDays(_appConfig.TiempoCaducidad),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha512)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

//directiva para trabajar con tokens y su validación en JSON Web Tokens(JWT)
using Microsoft.IdentityModel.Tokens;
//para manejar la creacion y manipulación de tokens JWT
using System.IdentityModel.Tokens.Jwt;
//para definir y trbajar con reclamaciones de identidad del usuario
using System.Security.Claims;
//para trbaajr con codificación de texto y bytes
using System.Text;

namespace IJGZ20240903.Auth
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        private readonly string _key;
        public JwtAuthenticationService(string key)
        {
            _key = key;
        }

        //método para autenticar al usuario y generar un token JWT

        public string Authenticate(string userName)
        {
            //crear un manejador de tokens JWT
            var tokenHandler = new JwtSecurityTokenHandler();

            //convertir la clave en bytes utilizando codificacion ASCII
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            //configurar la información del token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //definir la identidad del token cone l nombredel usuairo
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name,userName)
                }),
                //se establece fecha de vencimiento(8 horas desde ahora)
                Expires = DateTime.UtcNow.AddHours(8),
                //configurar la clave de firma y el algoritmo   de firma
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };
            //crear el token JWT
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

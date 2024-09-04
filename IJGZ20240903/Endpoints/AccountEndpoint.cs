using IJGZ20240903.Auth;
using System.Runtime.CompilerServices;

namespace IJGZ20240903.Endpoints
{
    public static class AccountEndpoint
    {
        public static void AddAccountEndpoints(this WebApplication app) 
        {
            app.MapPost("/account/login", (string login, string password, IJwtAuthenticationService authService) =>
            {
                //comprueba si las credenciales de inicio de sesión son válidas
                if(login == "admin" && password == "12345")
                {
                    //si son válidas, autentica al usuairo
                    //utilizando el servico de autenticacion JWT y obtiene un token
                    var token = authService.Authenticate(login);

                    //devuelve una respuesta HTTP OK (200) con el token JWT como resultado
                    return Results.Ok(token);
                }
                else
                {
                    //si las credenciales no son válidas, devuele una repsuesta HTTP Unauthorized(401).
                    return Results.Unauthorized();
                }
            });

        }
    }
}

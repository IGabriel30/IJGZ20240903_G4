namespace IJGZ20240903.Auth
{
    //interfaz para servicio de autenticacion JWT
    public interface IJwtAuthenticationService
    {
        //metodo para autenticar al usuario y generar un token JWT
        string Authenticate(string userName);
    }
}

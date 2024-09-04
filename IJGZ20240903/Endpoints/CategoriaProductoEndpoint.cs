using Microsoft.AspNetCore.Authorization;

namespace IJGZ20240903.Endpoints
{
    public static class CategoriaProductoEndpoint
    {
        // Lista estática en memoria para almacenar las categorías de productos
        private static List<object> categorias = new List<object>();

        // Método para agregar los endpoints relacionados con CategoriaProducto.
        public static void AddCategoriaProductoEndpoints(this WebApplication app)
        {
            // Endpoint público para obtener todas las categorías
            app.MapGet("/categorias", () =>
            {
                // Devuelve todas las categorías
                return categorias;
            });

            // Endpoint privado para registrar una nueva categoría
            app.MapPost("/categorias", (string name, string descripcion) =>
            {
                // Agrega la nueva categoría con el ID proporcionado por el usuario
                categorias.Add(new { name, descripcion });
                // Devuelve un resultado exitoso
                return Results.Ok("Categoría registrada exitosamente.");
            }).RequireAuthorization(); // Requiere autenticación para acceder
        }
    }
}

using Microsoft.AspNetCore.Authorization;

namespace IJGZ20240903.Endpoints
{
    public class Bodega
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
    }
    public static class BodegaEndpoint
    {
        // Lista estática en memoria para almacenar las bodegas
        private static List<Bodega> bodegas = new List<Bodega>();
        // Método para agregar los endpoints relacionados con Bodega.
        public static void AddBodegaEndpoints(this WebApplication app)
        {
            // Endpoint privado para crear una nueva bodega
            app.MapPost("/bodega/crear", (int id, string nombre, string ubicacion) =>
            {
                // Agrega la nueva bodega con el ID proporcionado por el usuario
                var nuevaBodega = new Bodega { Id = id, Nombre = nombre, Ubicacion = ubicacion };
                bodegas.Add(nuevaBodega);
                return Results.Ok(nuevaBodega);
            }).RequireAuthorization(); // Requiere autenticación para acceder

            // Endpoint privado para modificar una bodega existente
            app.MapPut("/bodega/modificar", (int id, string nombre, string ubicacion) =>
            {
                var bodega = bodegas.FirstOrDefault(b => b.Id == id);
                if (bodega == null)
                {
                    return Results.NotFound("Bodega no encontrada.");
                }
                // Modificar los detalles de la bodega con el ID proporcionado por el usuario
                bodega.Nombre = nombre;
                bodega.Ubicacion = ubicacion;
                return Results.Ok("Bodega modificada exitosamente.");
            }).RequireAuthorization(); // Requiere autenticación para acceder

            // Endpoint privado para obtener una bodega por su ID
            app.MapGet("/bodega/{id}", (int id) =>
            {
                var bodega = bodegas.FirstOrDefault(b => b.Id == id);
                if (bodega == null)
                {
                    return Results.NotFound("Bodega no encontrada.");
                }
                return Results.Ok(bodega);
            }).RequireAuthorization(); // Requiere autenticación para acceder
        }
    }
}

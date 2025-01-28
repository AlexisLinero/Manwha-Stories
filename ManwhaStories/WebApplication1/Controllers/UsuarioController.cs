using ManwhaStories.Data;
using ManwhaStories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ManwhaStories.Controllers
{

    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult DatosUsuario()
        {
            return View("~/Views/Pago/Datos.cshtml");
        }

        // Acción para guardar los datos en la base de datos
        [HttpPost]
        public IActionResult GuardarDatos(string DireccionEntrega, string ObservacionDireccion, string Nombre, string Apellidos, string DocumentoIdentidad, string TipoDocumento, string Telefono, string Departamento, string Ciudad, string Correo)
        {
            var usuario = new Usuario
            {
                Nombre = $"{Nombre} {Apellidos}", // Concatenar nombre y apellido
                Email = Correo,
                FechaRegistro = DateTime.Now, // Fecha y hora actual
                TipoUsuario = "Cliente", // Tipo de usuario siempre será Cliente
                Direccion = $"{DireccionEntrega} {ObservacionDireccion}", // Concatenar dirección y observación
                TipoDocumento = TipoDocumento,
                NumDocumento = DocumentoIdentidad,
                Telefono = Telefono,
                Ciudad = $"{Ciudad} {Departamento}"
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            TempData["MensajeConfirmacion"] = "Los datos se han guardado correctamente.";
            return RedirectToAction("Resumen", "Pagos");
        }
    }

}

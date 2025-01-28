using ManwhaStories.Data;
using ManwhaStories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManwhaStories.Controllers
{
    public class PagosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PagosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Resumen()
        {
            var usuario = _context.Usuarios.OrderByDescending(u => u.FechaRegistro).FirstOrDefault();
            var carrito = _context.Carritos.OrderByDescending(c => c.FechaCreacion).FirstOrDefault();

            if (usuario == null || carrito == null)
            {
                TempData["Error"] = "Error al obtener los datos del usuario o carrito.";
                return RedirectToAction("Index", "Carrito");
            }

            var totalCarrito = _context.ItemsCarrito
                .Where(i => i.ID_Carrito == carrito.ID_Carrito)
                .Sum(i => i.Cantidad * i.Producto.Precio);

            decimal valorEnvio = 20000; // Puedes ajustar este valor según sea necesario

            // Calcular el valor total sumando el total del carrito y el valor de envío
            decimal valorTotal = totalCarrito + valorEnvio;


            var resumen = new ResumenCompra
            {
                NombreCliente = usuario.Nombre,
                Ciudad = usuario.Ciudad,
                DireccionEnvio = usuario.Direccion,
                TotalCarrito = totalCarrito,
                ValorEnvio = valorEnvio,
                ValorTotal = valorTotal
            };

            var ViewModel = new ResumenPagoViewModel
            {
                ResumenCompra = resumen,
            };

            return View("~/Views/Pago/ResumenCompra.cshtml", ViewModel);

        }


        // Acción para mostrar la página de pagos
        public IActionResult Index(int id)
        {
            // Obtener el pedido usando Id_Pedido
            var pedido = _context.Pedidos.FirstOrDefault(p => p.Id_Pedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // Acción para confirmar el pago
        public IActionResult ConfirmarPago(int id)
        {
            // Obtener el pedido usando Id_Pedido y confirmar el pago
            var pedido = _context.Pedidos.FirstOrDefault(p => p.Id_Pedido == id);
            if (pedido != null)
            {
                pedido.Estado = "Pagado";
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Catalogo");
        }

        public IActionResult ProcesarPago1(int ID_Usuario, int Id_Pedido, decimal Monto, DateTime FechaPago, ResumenPagoViewModel model)
        {

            // Recuperar el usuario y el pedido para asociar el pago            
            var usuario = _context.Usuarios.FirstOrDefault(u => u.ID_Usuario == ID_Usuario);
            var pedido = _context.Pedidos.FirstOrDefault(p => p.Id_Pedido == Id_Pedido);

            if (usuario == null || pedido == null)
            {
                TempData["Error"] = "Error al obtener los datos del usuario o pedido.";
                return RedirectToAction("Index", "Home");
            }

            decimal valorTotal = model.ResumenCompra.ValorTotal;
            DateTime fechaPago = DateTime.Now;


            // Crear el objeto DatoPago
            var datoPago = new DatoPago
            {
                ID_Usuario = ID_Usuario,
                Id_Pedido = Id_Pedido,
                Monto = valorTotal,
                FechaPago = fechaPago
            };

            var ViewModel = new ResumenPagoViewModel
            {
                DatoPago = datoPago
            };


            // Guardar el pago en la base de datos
            _context.Add(datoPago);
            _context.SaveChanges();

            // Redirigir a una vista de éxito o resumen del pago
            TempData["Success"] = "Pago procesado con éxito.";

            return RedirectToAction("PagoExitoso");

        }

        public IActionResult Confirmacion(int id)
        {
            var pedido = _context.Pedidos
                .Include(p => p.Carrito)
                .FirstOrDefault(p => p.Id_Pedido == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View("~/Views/Pago/ConfirmaPedido.cshtml", pedido);
        }

        public IActionResult PagoExitoso()
        {
            return View("~/Views/Pago/Confirmacion.cshtml");
        }

    }
}

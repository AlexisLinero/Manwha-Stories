using ManwhaStories.Data;
using ManwhaStories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManwhaStories.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarritoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var carrito = ObtenerCarritoActual();
            var itemsCarrito = _context.ItemsCarrito
                .Where(i => i.ID_Carrito == carrito.ID_Carrito)
                .Include(i => i.Producto)
                .Select(i => new
                {
                    i.Id,
                    ProductoId = i.Id_Producto,
                    i.Producto.Nombre,
                    i.Producto.Precio,
                    i.Cantidad,
                    Total = i.Cantidad * i.Producto.Precio
                })
                .ToList();

            return View(itemsCarrito); // Considera usar un ViewModel
        }

        private Carrito ObtenerCarritoActual()
        {
            var carrito = _context.Carritos
                .Include(c => c.Items)
                .ThenInclude(i => i.Producto)
                .FirstOrDefault(c => c.FechaCreacion.Date == DateTime.Today);

            if (carrito == null)
            {
                carrito = new Carrito
                {
                    FechaCreacion = DateTime.Today
                };
                _context.Carritos.Add(carrito);
                _context.SaveChanges();
            }
            return carrito;
        }

        [HttpPost]
        public IActionResult CrearPedido()
        {
            var carrito = ObtenerCarritoActual();

            if (carrito == null)
            {
                Console.WriteLine("Carrito no encontrado.");
                return RedirectToAction("Index");
            }

            var items = _context.ItemsCarrito
                .Where(i => i.ID_Carrito == carrito.ID_Carrito)
                .Include(i => i.Producto)
                .ToList();

            if (!items.Any())
            {
                Console.WriteLine("El carrito está vacío.");
                return RedirectToAction("Index");
            }

            // Calcular el total del pedido
            var total = items.Sum(i => i.Cantidad * i.Producto.Precio);

            // Crear el pedido
            var pedido = new Pedido
            {
                Id_Carrito = carrito.ID_Carrito,
                Total = total,
                FechaPedido = DateTime.Now
            };

            _context.Pedidos.Add(pedido);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el pedido: {ex.Message}");
                return RedirectToAction("Index");
            }

            return RedirectToAction("Confirmacion", "Pagos", new { id = pedido.Id_Pedido });
        }

        [HttpPost]
        public IActionResult AgregarAlCarrito(int id)
        {
            var carrito = ObtenerCarritoActual();  // Obtén el carrito actual
            if (carrito == null)
            {
                // Si no hay un carrito, no puedes agregar el item
                Console.WriteLine("Carrito no encontrado.");
                return RedirectToAction("Index", "Carrito");
            }

            var producto = _context.Productos.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            var itemCarrito = new ItemCarrito
            {
                Id_Producto = producto.Id_Producto,
                ID_Carrito = carrito.ID_Carrito,  // Asegúrate de asignar el ID del carrito
                Cantidad = 1
            };

            _context.ItemsCarrito.Add(itemCarrito);
            _context.SaveChanges();

            TempData["MensajeConfirmacion"] = "Producto añadido al carrito correctamente.";

            return RedirectToAction("Index", "Catalogo");
        }


        [HttpPost]
        public IActionResult ActualizarCantidad(int itemId, int cantidad)
        {
            if (cantidad <= 0)
            {
                TempData["MensajeError"] = "La cantidad debe ser mayor a cero.";
                return RedirectToAction("Index", "Carrito");
            }

            var itemCarrito = _context.ItemsCarrito.FirstOrDefault(i => i.Id == itemId);
            if (itemCarrito == null)
            {
                return NotFound();
            }

            itemCarrito.Cantidad = cantidad;
            _context.SaveChanges();

            TempData["MensajeConfirmacion"] = "Cantidad actualizada correctamente.";
            return RedirectToAction("Index", "Carrito");
        }

        [HttpPost]
        public IActionResult EliminarDelCarrito(int itemId)
        {
            var itemCarrito = _context.ItemsCarrito.FirstOrDefault(i => i.Id == itemId);
            if (itemCarrito == null)
            {
                return NotFound();
            }

            _context.ItemsCarrito.Remove(itemCarrito);
            _context.SaveChanges();

            TempData["MensajeConfirmacion"] = "Producto eliminado del carrito.";
            return RedirectToAction("Index", "Carrito");
        }

        public IActionResult Descripcion(int id)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.Id_Producto == id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
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

            return View(pedido);
        }
    }
}

using ManwhaStories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManwhaStories.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Acción para mostrar el catálogo de productos
        public IActionResult Index()
        {
            var productos = _context.Productos.ToList();
            return View(productos);
        }

        // Acción para mostrar la descripción del producto
        public IActionResult Descripcion(int id)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.Id_Producto == id);
            if (producto == null)
            {
                return NotFound();
            }
            return View("Descripcion", producto);  // Aquí especificamos la vista
        }

        // Acción para mostrar los detalles del pedido
        public IActionResult Detalles(int id)
        {
            var pedido = _context.Pedidos
                .Include(p => p.ItemsCarrito)
                .ThenInclude(i => i.Producto)
                .FirstOrDefault(p => p.Id_Pedido == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }
    }
}

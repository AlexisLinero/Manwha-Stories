using ManwhaStories.Data;
using Microsoft.AspNetCore.Mvc;

namespace ManwhaStories.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Confirmacion(int id)
        {
            var pedido = _context.Pedidos
                .FirstOrDefault(p => p.Id_Pedido == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }



    }
}
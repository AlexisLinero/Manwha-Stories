using Microsoft.AspNetCore.Mvc;
using ManwhaStories.Data;
using ManwhaStories.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ManwhaStories.Controllers
{
    public class InventarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Acción para mostrar la lista de inventario
        public IActionResult Index()
        {
            var inventario = _context.Inventario.Include(i => i.Producto).ToList();
            return View(inventario);
        }

        // Acción para editar un producto en el inventario
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var inventario = _context.Inventario.Find(id);
            if (inventario == null) return NotFound();

            return View(inventario);
        }

        [HttpPost]
        public async Task<IActionResult> EditarProducto(int Id_Producto, string NombreProducto, int Cantidad)
        {
            var producto = await _context.Productos.FindAsync(Id_Producto);
            var inventario = await _context.Inventario.FirstOrDefaultAsync(i => i.Id_Producto == Id_Producto);

            if (producto == null || inventario == null)
            {
                return NotFound();
            }

            producto.Nombre = NombreProducto;
            inventario.Cantidad = Cantidad;

            _context.Productos.Update(producto);
            _context.Inventario.Update(inventario);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Acción para eliminar un producto del inventario
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var inventario = _context.Inventario.Include(i => i.Producto).FirstOrDefault(i => i.ID_Inventario == id);
                if (inventario == null) return NotFound();

                _context.Inventario.Remove(inventario);
                _context.Productos.Remove(inventario.Producto);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // Acción GET para mostrar el formulario de creación
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Productos = new SelectList(_context.Productos.ToList(), "Id_Producto", "Nombre");
            return View("~/Views/inventario/Create.cshtml");

        }

        // Acción POST para agregar el producto al inventario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                _context.Inventario.Add(inventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Productos = new SelectList(_context.Productos.ToList(), "Id_Producto", "Nombre");
            return View("~/Views/inventario/Create.cshtml", inventario);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> GuardarProductoEInventario(Producto producto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Guardar el nuevo producto en la base de datos
                    _context.Productos.Add(producto);
                    await _context.SaveChangesAsync();

                    // Si el producto tiene inventario, crea un registro en la tabla de inventarios
                    
                    
                        var inventario = new Inventario
                        {
                            Id_Producto = producto.Id_Producto,
                            
                        };
                        _context.Inventario.Add(inventario);
                        await _context.SaveChangesAsync();
                    

                    // Redirige al listado de inventarios o muestra un mensaje de éxito
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Maneja la excepción en caso de error
                    ModelState.AddModelError(string.Empty, $"Error al guardar: {ex.Message}");
                }
            }

            // Si el modelo no es válido, vuelve a cargar las categorías
            ViewBag.Categorias = new SelectList(_context.Productos.Select(p => p.IdCategoria).Distinct(), "IdCategoria", "IdCategoria");
            return View("Create", producto);
        }



    }
}

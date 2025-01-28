using ManwhaStories.Data;
using ManwhaStories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

public class InventarioController : Controller
{
    private readonly ApplicationDbContext _context;

    public InventarioController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        // Obtener productos desde la base de datos
        var productos = _context.Productos.ToList();

        // Construir la lista de SelectListItem
        var selectListItems = productos.Select(p => new SelectListItem
        {
            Value = p.Id_Producto.ToString(),
            Text = p.Nombre
        }).ToList();

        // Pasar la lista a la vista
        ViewBag.Productos = selectListItems;

        return View();
    }
}

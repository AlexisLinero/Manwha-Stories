using Microsoft.AspNetCore.Mvc;
using ManwhaStories.Models;
using System.Collections.Generic;

namespace ManwhaStories.Controllers
{
    public class SoporteController : Controller
    {
        private static List<SoporteModel> soporteData = new List<SoporteModel>(); // Datos simulados

        public IActionResult Index()
        {
            // Muestra los casos de soporte registrados
            return View(soporteData);
        }

        public IActionResult Create()
        {
            // Muestra el formulario para crear un nuevo caso de soporte
            return View();
        }

        [HttpPost]
        public IActionResult Create(SoporteModel soporte)
        {
            if (ModelState.IsValid)
            {
                // Agrega el nuevo caso de soporte a la lista simulada
                soporte.ID_Soporte = soporteData.Count + 1; // Simula el ID
                soporteData.Add(soporte);
                return RedirectToAction("Index");
            }
            return View(soporte);
        }
    }
}

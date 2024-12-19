using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TareasApp.Models;

namespace TareasApp.Controllers
{
    public class TareasController : Controller
    {
        // Lista estática para almacenar las tareas temporalmente
        private static List<Tarea> tareas = new List<Tarea>();

        // Acción para mostrar la lista de tareas
        public IActionResult Index()
        {
            return View(tareas);
        }

        // Acción para crear una nueva tarea
        [HttpPost]
        public IActionResult Crear(string descripcion)
        {
            if (!string.IsNullOrEmpty(descripcion))
            {
                var nuevaTarea = new Tarea
                {
                    Id = tareas.Count + 1,
                    Descripcion = descripcion,
                    Completada = false
                };
                tareas.Add(nuevaTarea);
            }
            return RedirectToAction("Index");
        }

        // Acción para marcar una tarea como completada
        public IActionResult Completar(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                tarea.Completada = true;
            }
            return RedirectToAction("Index");
        }
    }
}

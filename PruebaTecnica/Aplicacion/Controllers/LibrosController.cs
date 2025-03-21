using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Servicio.DTOs;
using Servicio.Servicios.Interfaz;

namespace Aplicacion.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ILibroServe _libroServe;
        private readonly IAutorServi _autorServi;
        public LibrosController(ILibroServe libroServe, IAutorServi autorServi)
        {
            _libroServe = libroServe;
            _autorServi = autorServi;
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            ICollection<LibroDTOs> Lista = await _libroServe.GetLibroServe();
            return View(Lista);
        }

        [HttpGet]
        public async Task<IActionResult>  AgregarLibro()
        {
            ICollection<AutorDTOs> Lista =  await  _autorServi.GetAutorServi();
            ViewBag.Autores = new SelectList(Lista, "Id", "Nombre");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ModificarLibro(int Id)
        {
            LibroDTOs Resul = await _libroServe.GetLibroByIdServe(Id);
            ICollection<AutorDTOs> Lista = await _autorServi.GetAutorServi();
            ViewBag.Autores = new SelectList(Lista, "Id", "Nombre");
            return View(Resul);
        }


        [HttpPost]
        public async Task<IActionResult> NuevoLibro(CrearLibroDTOs _libroDTOs) {

           string Resul =  await _libroServe.AddLibroServe(_libroDTOs);
            if (Resul == null && Resul == "error")
            {
                TempData["ErrorMensaje"] = "El sistema a tenido una falla";
                return RedirectToAction(nameof(Lista));
            }
            if (Resul == "guardado")
            {
                TempData["Mensaje"] = "Sea guardado correctamente";
                return RedirectToAction(nameof(Lista));
            }
            if (Resul == "existe")
            {
                TempData["Mensaje"] = "El autor ya  existe";
                return RedirectToAction(nameof(Lista));
            }
            return RedirectToAction(nameof(Lista));
        }

        [HttpPost]
        public async Task<IActionResult> EditarLibro(LibroDTOs _libroDTOs)
        {
            string Resul = await _libroServe.UpdateLibroServe(_libroDTOs);
            if (Resul == null && Resul == "error")
            {
                TempData["ErrorMensaje"] = "El sistema a tenido una falla";
                return RedirectToAction(nameof(Lista));
            }
            if (Resul == "guardado")
            {
                TempData["Mensaje"] = "Sea guardado correctamente";
                return RedirectToAction(nameof(Lista));
            }
            if (Resul == "existe")
            {
                TempData["Mensaje"] = "El autor ya  existe";
                return RedirectToAction(nameof(Lista));
            }
            return RedirectToAction(nameof(Lista));
        }
        [HttpGet]
        public async Task<IActionResult> EliminarLibro(int Id)
        {
            bool Resul = await _libroServe.DeleteLibroServe(Id);
            TempData["Mensaje"] = "Sea eliminado correctamente";
            return RedirectToAction(nameof(Lista));
        }

    }
}

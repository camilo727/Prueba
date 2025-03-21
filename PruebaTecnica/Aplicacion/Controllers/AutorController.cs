using Microsoft.AspNetCore.Mvc;
using Modelos.Datos;
using Modelos.Entidad;
using Servicio.DTOs;
using Servicio.Servicios.Interfaz;

namespace Aplicacion.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorServi _autorServi;
        public AutorController(IAutorServi autorServi)
        {
            _autorServi = autorServi;
        }
        [HttpGet]
        public async Task<IActionResult>  Lista()
        {
            ICollection<AutorDTOs>lista = await _autorServi.GetAutorServi();

            return View(lista);
        }
        [HttpGet]
        public IActionResult Agregar() { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Nuevo(CrearAutorDTOs _autor)
        {
            string Resul = await _autorServi.AddAutorServi(_autor);
            if (Resul == null && Resul == "error")
            {
                TempData["ErrorMensaje"] = "El sistema a tenido una falla";
                return RedirectToAction(nameof(Lista));
            }
            if (Resul== "guardado")
            {
                TempData["Mensaje"] = "Sea guardado correctamente";
                return RedirectToAction(nameof(Lista));
            }
            if (Resul== "existe")
            {
                TempData["Mensaje"] = "El autor ya  existe";
                return RedirectToAction(nameof(Lista));
            }
            return RedirectToAction(nameof(Lista));
        }
        [HttpGet]
        public async Task<IActionResult> Modificar(int Id)
        {
           AutorDTOs Resul= await _autorServi.GetAutorByIdServi(Id);
            return View(Resul);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(AutorDTOs _autor)
        {
            string Resul = await _autorServi.UpdateAutorServi(_autor);
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
        public async Task<IActionResult> Eliminar(int Id)
        {

          string Result =  await _autorServi.DeleteAutoresServi(Id);
            if(Result == null && Result == "error")
            {
                TempData["ErrorMensaje"] = "El sistema a tenido una falla";
                return RedirectToAction(nameof(Lista));
            }
            if (Result == "Eliminado")
            {
                TempData["Mensaje"] = "Sea eliminado correctamente";
                return RedirectToAction(nameof(Lista));
            }
            if (Result == "YaExisteTable")
            {
                TempData["MensajeAdvertencia"] = "El autor ya tiene libros";
                return RedirectToAction(nameof(Lista));
            }
            return RedirectToAction(nameof(Lista));
        }
    }
}

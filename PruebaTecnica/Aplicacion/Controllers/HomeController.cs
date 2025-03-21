using Aplicacion.Models;
using Microsoft.AspNetCore.Mvc;
using Servicio.DTOs;
using Servicio.Servicios.Interfaz;
using Servicio.Servicios.Repositorio;
using System.Diagnostics;

namespace Aplicacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILibroServe _libroServe;
        public HomeController(ILogger<HomeController> logger, ILibroServe libroServe)
        {
            _logger = logger;
            _libroServe = libroServe;
        }

        public async Task<IActionResult>Index()
        {
            ICollection<LibroDTOs> Lista = await _libroServe.GetLibroServe();
            return View(Lista);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

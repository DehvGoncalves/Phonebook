using System.Diagnostics;
using MeuSiteEmMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeuSiteEmMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HomeModel prop = new HomeModel();
            prop.Nome = "Debora";
            prop.Email = "dehv@gmail.com";
            return View(prop);
        }

        public IActionResult Privacy()
        {
            PrivacidadeModel prop = new PrivacidadeModel();
            prop.Idioma = "Português";
            prop.Pais = "Brasil";
            prop.Ano = 2025;
            prop.Versao = 1.0M;
            return View(prop);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

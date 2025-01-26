using MeuSiteEmMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MeuSiteEmMVC.Controllers
{
    public class ContatoController : Controller
    {
        // Injeção de dependência para o contexto do banco de dados
        private readonly AppDbContext _context;
        public ContatoController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var contatos = await _context.Contatos.ToListAsync();
            return View(contatos);
        }
    }
}

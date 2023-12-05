using EmprestimoApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoApp.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmprestimoController(ApplicationDbContext database)
        {
            _db = database;
        }
        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _db.Emprestimos;
            return View(emprestimos);
        }
    }
}

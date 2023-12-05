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

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimo)
        {
            if(ModelState.IsValid){
                _db.Emprestimos.Add(emprestimo);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id){
            if(id == null || id == 0){
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if(emprestimo == null){
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo){
            if(ModelState.IsValid){
                _db.Emprestimos.Update(emprestimo);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emprestimo);
        }
    }
}

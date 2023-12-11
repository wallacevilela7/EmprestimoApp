using ClosedXML.Excel;
using EmprestimoApp.Data;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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
            if (ModelState.IsValid)
            {
                _db.Emprestimos.Add(emprestimo);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _db.Emprestimos.Update(emprestimo);
                _db.SaveChanges();
                TempData["MensagemSucesso"] = "Edição realizado com sucesso";

                return RedirectToAction("Index");
            }
            return View(emprestimo);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _db.Emprestimos.FirstOrDefault(x => x.Id == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimo)
        {
            if (emprestimo == null)
            {
                return NotFound();
            }
            _db.Emprestimos.Remove(emprestimo);
            _db.SaveChanges();
            TempData["MensagemSucesso"] = "Exclusão realizado com sucesso";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Exportar()
        {
            var dados = GetDados();

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.AddWorksheet(dados, "Dados Empréstimos");
                using(MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Emprestimo.xls");
                }
            }
        }
        private DataTable GetDados()
        {
            DataTable dt = new DataTable();

            dt.TableName = "Dados empréstimo";
            dt.Columns.Add("Recebedor", typeof(string));
            dt.Columns.Add("Fornecedor", typeof(string));
            dt.Columns.Add("Livro", typeof(string));
            dt.Columns.Add("DataEmprestimo", typeof(DateTime));

            var dados = _db.Emprestimos.ToList();
            if (dados.Count > 0)
            {
                dados.ForEach(emprestimo =>
                {
                    dt.Rows.Add(emprestimo.Recebedor, emprestimo.Fornecedor, emprestimo.LivroEmprestado, emprestimo.DataUltimaAtualizacao);
                });
            }
            return dt;
        }
    }
}

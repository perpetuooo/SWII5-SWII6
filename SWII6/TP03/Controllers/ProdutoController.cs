using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TP03.Database;
using TP03.Models;

namespace TP03.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var produtos = _context.Produtos.ToList();
            return View(produtos);
        }

        public IActionResult Create()
        {
            return View(new Produto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public async Task<IActionResult> Details(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ID == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Update(produto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ID == id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

// Pedro H Perpétuo CB3021688 & Igor Benites CB3021734
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace Website.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApiService _apiService;

        public ProdutosController(ApiService apiService)
        {
            _apiService = apiService;
        }

        private bool IsUserLoggedIn()
        {
            return HttpContext.Session.GetInt32("UserId") != null;
        }

        public async Task<IActionResult> Index()
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Auth");

            var produtos = await _apiService.GetProdutosAsync();
            return View(produtos);
        }

        public IActionResult Create()
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Auth");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Auth");

            produto.IdUsuarioCadastro = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
            await _apiService.AddProdutoAsync(produto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Auth");

            var produto = await _apiService.GetProdutoByIdAsync(id);
            return View(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Auth");

            produto.IdUsuarioUpdate = HttpContext.Session.GetInt32("UserId").GetValueOrDefault();
            await _apiService.UpdateProdutoAsync(id, produto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (!IsUserLoggedIn()) return RedirectToAction("Login", "Auth");

            await _apiService.DeleteProdutoAsync(id);
            return RedirectToAction("Index");
        }
    }
}

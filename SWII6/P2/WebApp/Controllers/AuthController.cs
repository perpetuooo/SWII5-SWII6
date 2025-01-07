using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApiService _apiService;

        public AuthController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string nome, string senha)
        {
            var usuarios = await _apiService.GetUsersAsync();

            var usuario = usuarios.FirstOrDefault(u => u.Nome == nome && u.Senha == senha);

            if (usuario == null || !usuario.Status)
            {
                ViewBag.Error = "Usuário inválido ou inativo.";
                return View();
            }

            HttpContext.Session.SetInt32("UserId", usuario.Id);
            HttpContext.Session.SetString("UserName", usuario.Nome);

            return RedirectToAction("Index", "Produtos");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

using System.Net.Http.Json;
using WebApp.Models;

namespace WebApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Produto>>("Produto");
        }

        public async Task<List<Usuario>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Usuario>>("Usuario");
        }

        public async Task<Produto> GetProdutoByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Produto>($"Produto/{id}");
        }

        public async Task AddProdutoAsync(Produto produto)
        {
            await _httpClient.PostAsJsonAsync("Produto", produto);
        }

        public async Task UpdateProdutoAsync(int id, Produto produto)
        {
            await _httpClient.PutAsJsonAsync($"Produto/{id}", produto);
        }

        public async Task DeleteProdutoAsync(int id)
        {
            await _httpClient.DeleteAsync($"Produto/{id}");
        }

        public async Task<Usuario> AuthenticateUserAsync(string nome, string senha)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuarios/Authenticate", new { Nome = nome, Senha = senha });
            return response.IsSuccessStatusCode ? await response.Content.ReadFromJsonAsync<Usuario>() : null;
        }
    }
}

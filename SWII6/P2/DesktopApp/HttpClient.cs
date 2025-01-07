using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DesktopApp
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            var handler = new HttpClientHandler { AllowAutoRedirect = true };
            _httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("http://localhost:5137/api/")
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Usuario>> GetUsersAsync()
        {
            try
            {
                var users = await _httpClient.GetFromJsonAsync<List<Usuario>>("Usuario");
                return users ?? new List<Usuario>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter usuários: {ex.Message}", ex);
            }
        }

        public async Task<Usuario> AddUserAsync(Usuario user)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Usuario", user);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<Usuario>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adicionar usuário: {ex.Message}", ex);
            }
        }

        public async Task UpdateUserAsync(int id, Usuario user)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"Usuario/{id}", user);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar usuário: {ex.Message}", ex);
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Usuario/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar usuário: {ex.Message}", ex);
            }
        }
    }


public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Status { get; set; }
    }
}

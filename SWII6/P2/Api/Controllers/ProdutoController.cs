using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api.Models;
using Api.Data;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Produtos.ToList());
        }

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            if (produto.IdUsuarioCadastro <= 0)
            {
                return BadRequest("O ID do usuário deve ser informado.");
            }

            produto.IdUsuarioUpdate = produto.IdUsuarioCadastro;
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAll), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Produto produto)
        {
            var existing = _context.Produtos.Find(id);
            if (existing == null) return NotFound();

            if (produto.IdUsuarioUpdate <= 0)
            {
                return BadRequest("O ID do usuário deve ser informado.");
            }

            existing.Nome = produto.Nome;
            existing.Preco = produto.Preco;
            existing.Status = produto.Status;
            existing.IdUsuarioUpdate = produto.IdUsuarioUpdate;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null) return NotFound();

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return NoContent();
        }
    }
}

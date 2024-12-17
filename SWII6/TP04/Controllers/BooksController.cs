using TP04.Models;
using Microsoft.AspNetCore.Mvc;
using ISBNGenerator;
using ISBNValidator;
using System.Linq;

namespace TP04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _context.Books
                .Select(b => new
                {
                    b.Id,
                    b.Title,
                    b.Author,
                    b.Year,
                    b.ISBN
                }).ToList();

            if (books == null || !books.Any())
            {
                return Ok(new List<object>()); 
            }

            return Ok(books);
        }
     


        // GET: api/Books/5
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound($"Livro com ID {id} não encontrado.");
            }
            return Ok(book);
        }

        // POST: api/Books
        [HttpPost]
        public IActionResult PostBook(Book book)
        {
            if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
            {
                return BadRequest("Título e Autor são obrigatórios.");
            }

            if (string.IsNullOrEmpty(book.ISBN))
            {
                book.ISBN = ISBNGen.GenerateISBN();
            }

            if (!Validator.IsValidISBN(book.ISBN))
            {
                return BadRequest("Esse ISBN é inválido.");
            }

            if (_context.Books.Any(b => b.ISBN == book.ISBN))
            {
                return Conflict("Já existe um livro com esse ISBN.");
            }

            _context.Books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book updatedBook)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound($"Livro com ID {id} não encontrado.");
            }

            if (string.IsNullOrEmpty(updatedBook.Title) || string.IsNullOrEmpty(updatedBook.Author))
            {
                return BadRequest("Título e Autor são obrigatórios.");
            }

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Year = updatedBook.Year;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound($"Livro com ID {id} não encontrado.");
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return NoContent();
        }

    }
}

// Pedro H Perpétuo CB3021688 & Igor Benites CB3021734
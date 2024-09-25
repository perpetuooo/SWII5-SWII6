using Microsoft.AspNetCore.Mvc;
using TP01.Models;

namespace TP01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly Book _book;

        public BookController()
        {
            var authors = new List<Author>
            {
                new Author("jk rowling", "jkrling@email.com", 'F'),
                new Author("albert camus", "ac@email.com", 'M')
            };

            _book = new Book("O Mito de Sísifo", authors, 29.99, 100);
        }

        [HttpGet("GetBookName")]
        public string GetBookName()
        {
            return _book.GetName();
        }

        [HttpGet("ToString")]
        public string GetBookToString()
        {
            return _book.BookToString();
        }

        [HttpGet("GetAuthorNames")]
        public string GetAuthorNames()
        {
            return _book.GetAuthorNames();
        }

        [HttpGet("ApresentarLivro")]
        public IActionResult ApresentarLivro()
        {
            var content = $@"
                <html>
                <head><title>Livro</title></head>
                <body>
                    <h1>Nome do Livro: {_book.GetName()}</h1>
                    <h2>Autores:</h2>
                    <ul>
                        {string.Join("", _book.GetAuthors().Select(a => $"<li>{a.Name}</li>"))}
                    </ul>
                </body>
                </html>";

            return Content(content, "text/html");
        }
    }
}
//Pedro H Perpétuo & Igor Benites
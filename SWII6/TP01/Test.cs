using TP01.Models;


namespace TP01
{
    public class Test
    {
        public void TestBookMethods()
        {
            Author author1 = new Author("jk rowling", "jkr@email.com", 'F');
            Author author2 = new Author("albert camus", "ac@email.com", 'M');

            List<Author> authors = new List<Author> { author1, author2 };

            Book book = new Book("livro com varios autores", authors, 55.55, 100);

            Console.WriteLine($"Nome do livro: {book.GetName()}");

            foreach (var author in book.GetAuthors())
            {
                Console.WriteLine($"Nome: {author.Name}, Email: {author.Email}, Gênero: {author.Gender}");
            }

            Console.WriteLine($"Preço do livro: {book.GetPrice()}");
            Console.WriteLine($"Quantidade em estoque: {book.GetQty()}");

            book.SetPrice(45.55);
            book.SetQty(120);

            Console.WriteLine($"Novo preço do livro: {book.GetPrice()}");
            Console.WriteLine($"Nova quantidade em estoque: {book.GetQty()}");

            Console.WriteLine($"ToString(): {book.BookToString()}");

        }
    }
}
//Pedro H Perpétuo & Igor Benites
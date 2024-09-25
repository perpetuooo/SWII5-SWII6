using Newtonsoft.Json;
using System.Globalization;
using TP01.Models;

namespace TP01.CSV
{
    public class BookRepository
    {
        private static readonly string nameDatabaseCSV = "books.csv";
        private List<Book> _books = new List<Book>();

        public BookRepository()
        {
            LoadBooksCsv();
        }

        public List<Book> GetAll()
        {
            return _books.ToList();
        }

        public void Add(Book book)
        {
            var authorsJson = JsonConvert.SerializeObject(book.GetAuthors());
            using (var file = File.AppendText(nameDatabaseCSV))
            {
                file.WriteLine($"{book.GetName()};{authorsJson};{book.GetPrice()};{book.GetQty()}");
            }
            _books.Add(book);
        }

        private void LoadBooksCsv()
        {
            _books = new List<Book>();

            if (!File.Exists(nameDatabaseCSV))
            {
                File.Create(nameDatabaseCSV).Close();
            }

            using (var file = File.OpenText(nameDatabaseCSV))
            {
                while (!file.EndOfStream)
                {
                    var line = file.ReadLine();
                    if (string.IsNullOrEmpty(line)) continue;

                    var parts = line.Split(';');
                    var authors = JsonConvert.DeserializeObject<List<Author>>(parts[1]) ?? new List<Author>();

                    var book = new Book(
                        parts[0],
                        authors,
                        double.Parse(parts[2], CultureInfo.InvariantCulture),
                        int.Parse(parts[3])
                    );

                    _books.Add(book);
                }
            }
        }
    }
}
//Pedro H Perpétuo & Igor Benites
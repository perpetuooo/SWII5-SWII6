using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP01.Models
{
    public class Book
    {
        public string Name { get; set; }
        public List<Author> Authors { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }

        public Book(string name, List<Author> authors, double price, int qty = 0)
        {
            Name = name;
            Authors = authors;
            Price = price;
            Qty = qty;
        }

        public string GetName()
        {
            return Name;
        }

        public List<Author> GetAuthors()
        {
            return Authors;
        }

        public double GetPrice()
        {
            return Price;
        }

        public void SetPrice(double price)
        {
            Price = price;
        }

        public int GetQty()
        {
            return Qty;
        }

        public void SetQty(int qty)
        {
            Qty = qty;
        }

        public string BookToString()
        {
            return $"Book[name={Name}, authors={string.Join(", ", Authors.Select(a => a.Name))}, price={Price}, qty={Qty}]";
        }

        public string GetAuthorNames()
        {
            return string.Join(", ", Authors.Select(a => a.Name));
        }
    }
}
//Pedro H Perpétuo & Igor Benites
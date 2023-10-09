using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave1
{
    public class BooksRepository
    {
        private List<Book> books;

        private int NextInt { get; set; }

        public BooksRepository()
        {
            books = new List<Book>();
        }

        public Book Add(Book book)
        {
            book.ID = NextInt++;
            books.Add(book);
            return book;
        }

        public Book? Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.ID == id);
            if (book != null)
            {
                books.Remove(book);
                return book;
            }
            return null;
        }

        public Book? Update(int id, Book values)
        {
            var bookToUpdate = GetByID(id);
            if (bookToUpdate != null && values.IsValid())
            {
                bookToUpdate.Title = values.Title;
                bookToUpdate.Price = values.Price;
                return bookToUpdate;
            }
            return null;
        }

        public List<Book> Get()
        {
            return books.Select(b => new Book
            {
                ID = b.ID,
                Title = b.Title,
                Price = b.Price
            }).ToList();
        }

        public Book? GetByID(int id)
        {
            return books.FirstOrDefault(b => b.ID == id);
        }

        public List<Book> Get(String sortBy)
        {
            if (sortBy.ToLower() == "title")
            {
                return books.OrderBy(b => b.Title)
                    .Select(b => new Book
                    {
                        ID = b.ID,
                        Title = b.Title,
                        Price = b.Price
                    })
                    .ToList();
            }
            else if (sortBy.ToLower() == "price")
            {
                return books.OrderBy(b => b.Price)
                    .Select(b => new Book
                    {
                        ID = b.ID,
                        Title = b.Title,
                        Price = b.Price
                    })
                    .ToList();
            }
            else
            {
                throw new ArgumentException("Invalid sort option.");
            }


        }

        public List<Book> Get(double maxPrice)
        {
            return books
                .Where(b => b.Price <= maxPrice)
                .Select(b => new Book
                {
                    ID = b.ID,
                    Title = b.Title,
                    Price = b.Price
                })
                .ToList();
        }



    }
}

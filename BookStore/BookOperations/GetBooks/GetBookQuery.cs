using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBookQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBookQuery(BookStoreDbContext dbContext)
        {

            _dbContext = dbContext;


        }


        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> result = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                result.Add(new BooksViewModel
                {
                    Name = book.Name,
                    Description = book.Description,
                    Author = book.Author,
                    Title = book.Title,
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                });
            }


            return result;
        }


        public class BooksViewModel
        {
        
            public string Name { get; set; }
            public string Description { get; set; }
            public string Author { get; set; }
            public string Title { get; set; }

            public string PublishDate  { get; set; }

        }

    }
}

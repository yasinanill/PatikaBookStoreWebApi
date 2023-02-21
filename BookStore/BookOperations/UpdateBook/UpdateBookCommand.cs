using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {


    
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }

        public UpdateBookModel Model { get; set; }
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {

            _dbContext = dbContext;
        }
        public void Handle()
        {


            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

            if (book is null)
            {
                throw new InvalidOperationException("Kitap  bulunamadi");

            }
            book.Title = Model.Title != default ? Model.Title : book.Title;
            book.Author = Model.Author != default ? Model.Author : book.Author;


            _dbContext.SaveChanges();
      

        }
        public class UpdateBookModel
        {


            public string Author { get; set; }
            public string Title { get; set; }
  

        }

    }
}

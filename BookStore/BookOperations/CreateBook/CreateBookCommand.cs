using BookStore.DBOperations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BookStore.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; }


        private readonly BookStoreDbContext _dbContext;
        public CreateBookCommand(BookStoreDbContext dbContext)
        {

            _dbContext = dbContext;
        }
        public void Handle()
        {

            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);

            if (book is not null)
            {
                throw new InvalidOperationException("Kitap  zaten Mevcut");
            }
            book = new Book();
            book.Title = Model.Title;
            book.Author = Model.Author;
            book.Description = Model.Description;
            book.PublishDate = Model.PublishDate;

           _dbContext.Books.Add(book);
            _dbContext.SaveChanges();



        }
        public class CreateBookModel
        {


            public string Name { get; set; }
            public string Description { get; set; }
            public string Author { get; set; }
            public string Title { get; set; }
            public DateTime PublishDate { get; set; }

        }


    }
}

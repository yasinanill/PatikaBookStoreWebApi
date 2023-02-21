using BookStore.DBOperations;
using static BookStore.BookOperations.GetBooks.GetBookQuery;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BookStore.BookOperations.GetBookDetail
{


    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public int BookId { get; set; }


        public GetBookDetailQuery(BookStoreDbContext dbContext)
        {

            _dbContext = dbContext;


        }
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();


            if (book is null)

            {
                throw new InvalidOperationException("Kitap bulunamdi");
            }
            BookDetailViewModel viewModel = new BookDetailViewModel();
            viewModel.Title= book.Title;
            viewModel.Description= book.Description;
            viewModel.PublishDate= book.PublishDate.ToString("dd/MM/yyy");
            viewModel.Author= book.Author;
         

            return viewModel;
        }

        public class BookDetailViewModel
        {

            public string Name { get; set; }
            public string Description { get; set; }
            public string Author { get; set; }
            public string Title { get; set; }

            public string PublishDate { get; set; }

        }



    }

}
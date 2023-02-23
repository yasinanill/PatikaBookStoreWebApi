using BookStore.DBOperations;
using static BookStore.Application.BookOperations.Queries.GetBookDetail.GetBooks.GetBookQuery;
using System.Collections.Generic;
using System.Linq;
using System;
using AutoMapper;

namespace BookStore.Application.BookOperations.Queries.GetBookDetail
{


    public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }


        public GetBookDetailQuery(BookStoreDbContext dbContext, IMapper mapper)
        {

            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Where(x => x.Id == BookId).SingleOrDefault();


            if (book == null)

            {
                throw new InvalidOperationException("Kitap bulunamdi");
            }
            BookDetailViewModel viewModel = _mapper.Map<BookDetailViewModel>(book);        // new BookDetailViewModel();





            return viewModel;
        }

        public class BookDetailViewModel
        {


            public int Id { get; set; }
            public string Title { get; set; }
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }

        }



    }

}
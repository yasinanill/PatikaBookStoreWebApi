using BookStore.DBOperations;
using static BookStore.Application.BookOperations.Queries.GetBookDetail.GetBooks.GetBookQuery;
using System.Collections.Generic;
using System.Linq;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.BookOperations.Queries.GetBookDetail
{


    public class GetBookDetailQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int BookId { get; set; }


        public GetBookDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {

            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BookDetailViewModel Handle()
        {
            var book = _dbContext.Books.Include(x=>x.Genre).Where(x => x.Id == BookId).SingleOrDefault();


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
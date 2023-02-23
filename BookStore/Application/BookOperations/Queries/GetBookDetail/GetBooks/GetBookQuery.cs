﻿using AutoMapper;
using BookStore.DBOperations;
using BookStore.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace BookStore.Application.BookOperations.Queries.GetBookDetail.GetBooks
{
    public class GetBookQuery
    {
        private readonly IMapper _mapper;

        private readonly BookStoreDbContext _dbContext;
        public GetBookQuery(BookStoreDbContext dbContext, IMapper mapper)
        {

            _dbContext = dbContext;
            _mapper = mapper;
        }


        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList();
            List<BooksViewModel> result = _mapper.Map<List<BooksViewModel>>(bookList);
            //new List<BooksViewModel>();



            return result;
        }


        public class BooksViewModel
        {

            public string Title { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
            public string Genre { get; set; }

        }

    }
}
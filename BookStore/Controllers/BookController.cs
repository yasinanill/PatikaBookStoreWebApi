using AutoMapper;
using BookStore.Application.BookOperations.Commands.DeleteBook;
using BookStore.BookOperations.CreateBook;
using BookStore.DBOperations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;
using static BookStore.Application.BookOperations.Queries.GetBookDetail.GetBookDetailQuery;
using static BookStore.Application.BookOperations.Commands.UpdateBook.UpdateBookCommand;
using BookStore.Application.BookOperations.Commands.UpdateBook;
using BookStore.Application.BookOperations.Queries.GetBookDetail;
using BookStore.Application.BookOperations.Queries.GetBookDetail.GetBooks;

namespace BookStore.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : Controller
    {

        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(IBookStoreDbContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBookQuery query = new GetBookQuery(_context, _mapper);
            var result = query.Handle();

            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            BookDetailViewModel result;


            GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
            query.BookId = id;
            GetByIdBookQueryValidator validationRules = new GetByIdBookQueryValidator();
            validationRules.ValidateAndThrow(query);
            result = query.Handle();

            return Ok(result);

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);

            command.Model = newBook;

            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();





            return Ok();
        }



        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, UpdateBookModel updatebook)
        {


            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.BookId = id;
            command.Model = updatebook;
            UpdateBookViewCommandValidator validator = new UpdateBookViewCommandValidator();
            validator.ValidateAndThrow(command);



            command.Handle();


            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult deleteBook(int id)
        {


            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;
            DeleteBookCommandValidator validationRules = new DeleteBookCommandValidator();
            validationRules.ValidateAndThrow(command);
            command.Handle();




            return Ok();






        }



    }
}

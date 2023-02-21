using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.DeleteBook;
using BookStore.BookOperations.GetBookDetail;
using BookStore.BookOperations.GetBooks;
using BookStore.BookOperations.UpdateBook;
using BookStore.DBOperations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;
using static BookStore.BookOperations.GetBookDetail.GetBookDetailQuery;
using static BookStore.BookOperations.UpdateBook.UpdateBookCommand;

namespace BookStore.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : Controller
    {

        private readonly BookStoreDbContext _context;


        public BookController(BookStoreDbContext context)
        {

            _context = context;


        }



        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBookQuery query = new GetBookQuery(_context);
            var result = query.Handle();

            return Ok(result);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            BookDetailViewModel result;

            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
                result = query.Handle();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(result);

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newBook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


            return Ok();
        }



        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, UpdateBookModel updatebook)
        {
           
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);    
                 command.BookId= id;
                 command.Model = updatebook;
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult deleteBook(int id)
        {
            


            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                 command.Handle();


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();






        }



    }
}

using AutoMapper;
using BookStore.Application.AuthorOperations.Commands.CreateAuthor;
using BookStore.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStore.Application.AuthorOperations.Queries.GetAuthors;
using BookStore.DBOperations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetAuthors()
        {
            GetAuthorsQuery query = new(context, mapper);
            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult AddAuthor([FromBody] CreateAuthorCommand.CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new(context, mapper);
            command.Model = newAuthor;

            CreateAuthorCommandValidator validator = new();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            GetAuthorDetailQuery query = new(context, mapper);
            query.AuthorId = id;
            GetAuthorDetailQueryValidator validator = new();
            validator.ValidateAndThrow(query);
            var result = query.Handle();

            return Ok(result);
        }

    }
}
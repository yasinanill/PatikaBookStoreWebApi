using AutoMapper;
using BookStore.DBOperations;
using BookStore.Entites;
using System;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Handle()
        {
            var newAuthor = context.Authors.SingleOrDefault(a => a.LastName.ToUpper() == Model.LastName.ToUpper() && a.FirstName.ToUpper() == Model.FirstName.ToUpper());
            if (newAuthor is not null)
                throw new InvalidOperationException("That Author already exists");

            newAuthor = mapper.Map<Author>(Model);

            context.Authors.Add(newAuthor);
            context.SaveChanges();
        }

        public class CreateAuthorModel
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public DateTime Birthday { get; set; }
        }
    }
}
using FluentValidation;
using System;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookViewCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookViewCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).GreaterThan(0);
            RuleFor(command => command.Model.PageCount).GreaterThan(0).NotEmpty();
            RuleFor(command => command.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date).NotEmpty();
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(4);
        }
    }
}

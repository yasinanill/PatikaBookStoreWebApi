using FluentValidation;

namespace BookStore.Application.BookOperations.Queries.GetBookDetail
{
    public class GetByIdBookQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetByIdBookQueryValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0).NotEmpty();
        }
    }
}

using FluentValidation;

namespace BookStore.BookOperations.GetBookDetail
{
    public class GetByIdBookQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetByIdBookQueryValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0).NotEmpty();
        }
    }
}

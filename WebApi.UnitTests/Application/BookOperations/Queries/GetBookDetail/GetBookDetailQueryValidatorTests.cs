using BookStore.Application.BookOperations.Queries.GetBookDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private GetBookDetailQueryValidator _validator;

        public GetBookDetailQueryValidatorTests()
        {
            _validator = new();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void WhenBookIdLessThanOrEqualZero_ValidationShouldReturnError(int bookId)
        {
            // arrange
            GetBookDetailQuery query = new(null, null);
            query.BookId = bookId;

            // act
            var result = _validator.Validate(query);

            // assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenBookIdGreaterThanZero_ValidationShouldNotReturnError()
        {
            // arrange
            GetBookDetailQuery query = new(null, null);
            query.BookId = 12;

            // act
            var result = _validator.Validate(query);

            // assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
using AutoMapper;
using BookStore.Application.AuthorOperations.Queries.GetAuthors;
using BookStore.DBOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQueryTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public GetAuthorsQueryTests(CommonTestFixture testFixture)
        {
            this.context = testFixture.Context;
            this.mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenGetAuthorsQueryIsHandled_AuthorListShouldBeReturned()
        {
            // Arrange
            var query = new GetAuthorsQuery(context, mapper);

            // Act
            var result = query.Handle();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);

            result[0].FullName.Should().Be("Eric Ries");
            result[0].Birthday.Should().Be("22.09.1978 00:00:00");

            result[1].FullName.Should().Be("Charlotte Perkins Gilman");
            result[1].Birthday.Should().Be("3.07.1860 00:00:00");

            result[2].FullName.Should().Be("Frank Herbert");
            result[2].Birthday.Should().Be("3.10.1920 00:00:00");
        }
    }
}
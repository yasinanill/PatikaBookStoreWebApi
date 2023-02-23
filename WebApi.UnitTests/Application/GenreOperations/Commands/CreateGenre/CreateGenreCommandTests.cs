using BookStore.Application.GenreOperations.Commands.CreateGenre;
using BookStore.DBOperations;
using BookStore.Entites;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext context;

        public CreateGenreCommandTests(CommonTestFixture testFixture)
        {
            this.context = testFixture.Context;
        }

        [Fact]
        public void WhenAlreadyExitsGenreNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // arrange (Hazırlık)
            var genre = new Genre()
            {
                Name = "Deneme",
                IsActive = true
            };
            context.Genres.Add(genre);
            context.SaveChanges();

            CreateGenreCommand command = new(context);
            command.Model = new CreateGenreCommand.CreateGenreModel { Name = genre.Name };

            // act & assert (Çalıştırma - Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("That Book Genre is exists");

        }

        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeCreated()
        {
            // arrange
            CreateGenreCommand command = new(context);
            CreateGenreCommand.CreateGenreModel model = new CreateGenreCommand.CreateGenreModel()
            {
                Name = "Test test",
            };

            command.Model = model;

            // act
            FluentActions.Invoking(() => command.Handle()).Invoke();
            // assert
            var genre = context.Genres.SingleOrDefault(g => g.Name == model.Name);
            genre.Should().NotBeNull();
            genre.IsActive.Should().BeTrue();
        }
    }
}
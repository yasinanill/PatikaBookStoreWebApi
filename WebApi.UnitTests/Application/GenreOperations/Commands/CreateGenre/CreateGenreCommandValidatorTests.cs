using BookStore.Application.GenreOperations.Commands.CreateGenre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookStore.Application.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidatorTests : IClassFixture<CommonTestFixture>
    {

        [Theory]
        [InlineData("a")]
        [InlineData("abc")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldReturnErrors(string name)
        {
            // arrange
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model = new CreateGenreModel() { Name = name };

            CreateGenreCommandValidator validator = new();

            // act
            var result = validator.Validate(command);

            // assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("abcd")]
        [InlineData("action")]
        public void WhenValidInputsAreGiven_Validator_ShouldNotReturnError(string name)
        {
            // arrange
            CreateGenreCommand command = new CreateGenreCommand(null);
            command.Model = new CreateGenreModel() { Name = name };

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();

            // act
            var result = validator.Validate(command);

            // assert
            result.Errors.Count.Should().Be(0);
        }
    }
using AutoMapper;
using BookStore.BookOperations.CreateBook;
using BookStore.Entites;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;
using static BookStore.Application.BookOperations.Queries.GetBookDetail.GetBookDetailQuery;
using static BookStore.Application.BookOperations.Queries.GetBookDetail.GetBooks.GetBookQuery;
using static BookStore.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;
using BookStore.Application.GenreOperations.Queries.GetGenreDetail;
using BookStore.Application.UserOperations.Command.CreateUser;
using static BookStore.Application.AuthorOperations.Queries.GetAuthors.GetAuthorsQuery;
using static BookStore.Application.AuthorOperations.Queries.GetAuthorDetail.GetAuthorDetailQuery;

namespace BookStore.Common
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateUserModel, User>();
            CreateMap<Author, AuthorsViewModel>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
            CreateMap<Author, AuthorDetailViewModel>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
        }

    }
}

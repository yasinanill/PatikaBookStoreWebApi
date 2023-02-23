using AutoMapper;
using BookStore.BookOperations.CreateBook;
using BookStore.Entites;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;
using static BookStore.Application.BookOperations.Queries.GetBookDetail.GetBookDetailQuery;
using static BookStore.Application.BookOperations.Queries.GetBookDetail.GetBooks.GetBookQuery;
using static BookStore.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;

namespace BookStore.Common
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Genre, GenresViewModel>();

        }

    }
}

using AutoMapper;
using BookStore.BookOperations.CreateBook;
using BookStore.BookOperations.GetBookDetail;
using BookStore.BookOperations.GetBooks;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;
using static BookStore.BookOperations.GetBookDetail.GetBookDetailQuery;
using static BookStore.BookOperations.GetBooks.GetBookQuery;

namespace BookStore.Common
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));

        }

    }
}

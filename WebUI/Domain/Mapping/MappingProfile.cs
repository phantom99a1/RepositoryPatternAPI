using AutoMapper;
using WebUI.Domain.Contracts;
using WebUI.Domain.Entities;

namespace WebUI.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, GetAuthorDTO>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
            CreateMap<CreateAuthor, Author>();
            CreateMap<UpdateAuthor, Author>();
            CreateMap<DeleteAuthor, Author>();
            CreateMap<GetAuthor, Author>();

            //Mapping for Book
            CreateMap<Book, GetBookDTO>();
            CreateMap<CreateBook, Book>();
            CreateMap<UpdateBook, Book>();
            CreateMap<DeleteBook, Book>();
            CreateMap<GetBook, Book>();
        }
    }
}

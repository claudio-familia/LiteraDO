using AutoMapper;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.Domain.Readers;

namespace LiteraDO.BusinessLogic.Profiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}

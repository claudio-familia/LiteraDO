using AutoMapper;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.Domain.Readers;

namespace LiteraDO.BusinessLogic.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
        }
    }
}

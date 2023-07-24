using AutoMapper;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.Domain.Readers;

namespace LiteraDO.BusinessLogic.Profiles
{
    public class LiteraryGenreProfile : Profile
    {
        public LiteraryGenreProfile()
        {
            CreateMap<LiteraryGenre, LiteraryGenreDto>().ReverseMap();
        }
    }
}

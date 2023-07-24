using AutoMapper;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.Domain.Users;

namespace LiteraDO.BusinessLogic.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
        }
    }
}

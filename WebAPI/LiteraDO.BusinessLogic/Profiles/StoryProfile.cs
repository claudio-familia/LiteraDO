using AutoMapper;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.Domain.Writers;

namespace LiteraDO.BusinessLogic.Profiles
{
    public class StoryProfile : Profile
    {
        public StoryProfile()
        {
            CreateMap<Story, StoryDto>().ReverseMap();
        }
    }
}

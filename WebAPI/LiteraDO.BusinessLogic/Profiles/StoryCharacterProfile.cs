using AutoMapper;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.Domain.Writers;

namespace LiteraDO.BusinessLogic.Profiles
{
    public class StoryCharacterProfile : Profile
    {
        public StoryCharacterProfile()
        {
            CreateMap<StoryCharacter, StoryCharacterDto>().ReverseMap();
        }
    }
}

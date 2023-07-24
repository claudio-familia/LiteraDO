using AutoMapper;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.Domain.Writers;

namespace LiteraDO.BusinessLogic.Profiles
{
    public class StoryChapterProfile : Profile
    {
        public StoryChapterProfile()
        {
            CreateMap<StoryChapter, StoryChapterDto>().ReverseMap();
        }
    }
}

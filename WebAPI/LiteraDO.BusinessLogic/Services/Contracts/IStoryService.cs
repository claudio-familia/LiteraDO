using LiteraDO.BusinessLogic.Dto;
using LiteraDO.Domain.Writers;

namespace LiteraDO.BusinessLogic.Services.Contracts
{
    public interface IStoryService : IBaseService<Story, StoryDto>
    {
        Story Publish(int id);
        IEnumerable<StoryDto> GetPublishStories();
    }
}

using AutoMapper;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.Common.Services.Contracts;
using LiteraDO.DataAccess.Repositories.Contracts;
using LiteraDO.Domain.Writers;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;

namespace LiteraDO.BusinessLogic.Services.Writers
{
    public class StoryService : BaseService<Story, StoryDto>, IStoryService
    {
        private readonly IDataRepository<Story> dataRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICurrentUserService currentUser;
        private readonly IMapper mapper;

        public StoryService(IDataRepository<Story> dataRepository,
                             IUnitOfWork unitOfWork,
                             ICurrentUserService currentUser,
                             IMapper mapper) : base(dataRepository, mapper)
        {
            this.dataRepository = dataRepository;
            this.unitOfWork = unitOfWork;
            this.currentUser = currentUser;
            this.mapper = mapper;
        }

        public override Story Update(StoryDto entity)
        {
            try
            {
                var element = repository.GetAll(x => x.Include(i => i.LiteraryGenre), x => x.UserId == currentUser.UserId).FirstOrDefault(x => x.Id == entity.Id);

                element.Language = entity.Language;
                element.Description = entity.Description;
                element.Title = entity.Title;
                element.TagetAudience = entity.TagetAudience;
                element.LiteraryGenreId = entity.LiteraryGenreId;
                element.Tags = entity.Tags;
                element.HasAdultContent = entity.HasAdultContent;
                element.Cover = entity.Cover;


                return repository.Update(element);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public override IEnumerable<StoryDto> GetAll()
        {
            var result = repository.GetAll(x => x.Include(i => i.LiteraryGenre), x => x.UserId == currentUser.UserId);

            return mapper.Map<IEnumerable<StoryDto>>(result);
        }

        public override StoryDto Get(int id)
        {
            var result = dataRepository.Get(x => x.Include(i => i.LiteraryGenre).Include(i => i.LiteraryGenre).Include(i => i.Chapters).Include(x => x.User).ThenInclude(x => x.Country), x => x.Id == id);

            if (result.CreatorUserId != currentUser.UserId && result.PublishedDate < new DateTime(2000, 1, 1)) throw new TypeAccessException("This resource does not belong to the requester");

            return mapper.Map<StoryDto>(result);
        }

        public Story Publish(int id)
        {
            var entity = repository.GetAll(x => x, x => x.UserId == currentUser.UserId.Value).FirstOrDefault(x => x.Id == id);

            entity.PublishedDate = DateTime.Now;

            return repository.Update(entity);
        }

        public IEnumerable<StoryDto> GetPublishStories()
        {
            var result = repository.GetAll(x => x.Include(i => i.LiteraryGenre).Include(x => x.User).ThenInclude(x => x.Country), x => x.PublishedDate > new DateTime(2000, 1, 1));

            return mapper.Map<IEnumerable<StoryDto>>(result);
        }
    }
}
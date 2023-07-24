using AutoMapper;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.Common.Services.Contracts;
using LiteraDO.DataAccess.Repositories.Contracts;
using LiteraDO.Domain.Writers;

namespace LiteraDO.BusinessLogic.Services.Writers
{
    public class StoryService : BaseService<Story, StoryDto>, IBaseService<Story, StoryDto>
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

        public override IEnumerable<StoryDto> GetAll()
        {
            var result = repository.GetAll().Where(x => x.CreatorUserId == currentUser.UserId);

            return mapper.Map<IEnumerable<StoryDto>>(result);
        }

        public override StoryDto Get(int id)
        {
            var result = dataRepository.Get(id);

            if (result.CreatorUserId != currentUser.UserId) throw new TypeAccessException("This resource does not belong to the requester");

            return mapper.Map<StoryDto>(result);
        }
    }
}
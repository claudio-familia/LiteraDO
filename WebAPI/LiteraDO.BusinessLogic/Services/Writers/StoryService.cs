
using LiteraDO.BusinessLogic.Services.Contracts;
using LiteraDO.Common.Services.Contracts;
using LiteraDO.DataAccess.Repositories.Contracts;
using LiteraDO.Domain.Writers;

namespace LiteraDO.BusinessLogic.Services.Writers
{
    public class StoryService : BaseService<Story>, IBaseService<Story>
    {
        private readonly IDataRepository<Story> dataRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICurrentUserService currentUser;

        public StoryService(IDataRepository<Story> dataRepository,
                             IUnitOfWork unitOfWork,
                             ICurrentUserService currentUser) : base(dataRepository)
        {
            this.dataRepository = dataRepository;
            this.unitOfWork = unitOfWork;
            this.currentUser = currentUser;
        }

        public override IEnumerable<Story> GetAll()
        {
            return repository.GetAll().Where(x => x.CreatorUserId == currentUser.UserId);
        }

        public override StoryDto Get(int id)
        {
            var result = dataRepository.Get(id);

            if (result.CreatorUserId != currentUser.UserId) throw new TypeAccessException("This resource does not belong to the requester");

            return result;
        }
    }
}
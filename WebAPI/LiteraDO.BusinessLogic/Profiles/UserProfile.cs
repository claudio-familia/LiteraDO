using AutoMapper;
using LiteraDO.BusinessLogic.Dto;
using LiteraDO.Domain.Users;

namespace WalletPlanifier.BusinessLogic.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}

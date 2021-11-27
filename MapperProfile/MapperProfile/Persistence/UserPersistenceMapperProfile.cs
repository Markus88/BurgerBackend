using AutoMapper;
using User.Domain.Interface.Model;

namespace MapperProfile.Persistence
{
    public class UserPersistenceMapperProfile : Profile
    {
        public UserPersistenceMapperProfile()
        {
            CreateMap<User, IUserModel>().ReverseMap();
        }
    }
}
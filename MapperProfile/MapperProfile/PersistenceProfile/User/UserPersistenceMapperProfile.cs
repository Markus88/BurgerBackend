using AutoMapper;
using User.Domain.Interface.Model;

namespace MapperProfile.PersistenceProfile.User
{
    public class UserPersistenceMapperProfile : Profile
    {
        public UserPersistenceMapperProfile()
        {
            CreateMap<Persistence.User.Model.User, IUserModel>().ReverseMap();
        }
    }
}

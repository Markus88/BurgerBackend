using Application.Interface.User.Model;
using AutoMapper;
using User.Domain.Interface.Model;

namespace MapperProfile.ApplicationProfile.User
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserWriteDto, IUserModel>()
              .ForMember(dest => dest.ID, opt => opt.Ignore());

            CreateMap<IUserModel, UserWriteDto>();

            CreateMap<UserReadDto, IUserModel>()
              .IncludeBase<UserWriteDto, IUserModel>();

            CreateMap<IUserModel, UserReadDto>()
              .IncludeBase<IUserModel, UserWriteDto>();
        }
    }
}
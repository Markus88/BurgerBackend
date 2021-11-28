using AutoMapper;
using CrossTools.ConnectionStringFactory;
using User.Domain.Interface.Persistence;
using Persistence.User.Service;
using User.Domain.Implementation.Model;
using MapperProfile.PersistenceProfile.User;

namespace Persistence.Test.User
{
    public class UserDataServiceTestFixture
    {
        private IConnectionStringFactory ConnectionStringFactory { get; }
        public static IMapper Mapper = new Mapper(new MapperConfiguration(cfg => AddProfiles(cfg)));

        public UserDataServiceTestFixture()
        {
            ConnectionStringFactory = new ConnectionStringFactory();
        }

        public IUserDataService Create()
        {
            return new UserDataService(ConnectionStringFactory, Mapper);
        }

        private static void AddProfiles(IMapperConfigurationExpression configuration)
        {
            configuration.AddProfile(typeof(UserPersistenceMapperProfile));

            configuration.CreateMap<Persistence.User.Model.User, UserModel>();
        }
    }
}
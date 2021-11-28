using AutoMapper;
using MapperProfile.PersistenceProfile.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using User.Domain.Interface.Model;

namespace MapperProfile.Test.Persistence.User
{
    [TestClass]
    public class UserMapperProfileTest
    {
        private MapperConfiguration _configuration;

        [TestInitialize]
        public void TestInitialize()
        {
            _configuration = new MapperConfiguration(m => m.AddProfile<UserPersistenceMapperProfile>());
            _configuration.AssertConfigurationIsValid<UserPersistenceMapperProfile>();
        }

        [TestMethod]
        public void Map_UserToUserModel_MapsAllProperties()
        {
            // Arrange
            var createUser = new Persistence.User.Model.User
            {
                ID = 0,
                UserName = "JohnDoe2000",
                Email = "JohnDoe2000@super.com"
            };

            var target = _configuration.CreateMapper();

            // Act
            var actual = target.Map<Persistence.User.Model.User, IUserModel>(createUser);

            // Assert
            Assert.AreEqual(createUser.ID, actual.ID);
            Assert.AreEqual(createUser.UserName, actual.UserName);
            Assert.AreEqual(createUser.Email, actual.Email);
        }
    }
}

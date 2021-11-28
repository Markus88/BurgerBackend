using Application.Interface.User.Model;
using AutoMapper;
using MapperProfile.ApplicationProfile.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using User.Domain.Interface.Model;

namespace MapperProfile.Test.Application.User
{
    [TestClass]
    public class UserMapperProfileTest
    {
        private MapperConfiguration _configuration;

        [TestInitialize]
        public void TestInitialize()
        {
            _configuration = new MapperConfiguration(m => m.AddProfile<UserMapperProfile>());
            _configuration.AssertConfigurationIsValid<UserMapperProfile>();
        }

        [TestMethod]
        public void Map_UserWriteDtoToCreateUserModel_MapsAllProperties()
        {
            // Arrange
            var createUserDto = new UserWriteDto
            {
                UserName = "JohnDoe2000",
                Email = "JohnDoe2000@super.com"
            };

            var target = _configuration.CreateMapper();

            // Act
            var actual = target.Map<UserWriteDto, IUserModel>(createUserDto);

            // Assert
            Assert.AreEqual(createUserDto.UserName, actual.UserName);
            Assert.AreEqual(createUserDto.Email, actual.Email);
        }

        [TestMethod]
        public void Map_UserReadDtoDtoToUpdateUserModel_MapsAllProperties()
        {
            // Arrange
            var readUserDto = new UserReadDto
            {
                ID = 0,
                UserName = "JohnDoe2000",
                Email = "JohnDoe2000@super.com"
            };

            var target = _configuration.CreateMapper();

            // Act
            var actual = target.Map<UserReadDto, IUserModel>(readUserDto);

            // Assert
            Assert.AreEqual(readUserDto.ID, actual.ID);
            Assert.AreEqual(readUserDto.UserName, actual.UserName);
            Assert.AreEqual(readUserDto.Email, actual.Email);
        }
    }
}

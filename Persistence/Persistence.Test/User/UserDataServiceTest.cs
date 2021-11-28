using CrossTools.ConnectionStringFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence.User.Context;
using System.Linq;
using System.Threading.Tasks;
using User.Domain.Implementation.Model;

namespace Persistence.Test.User
{
    [TestClass]
    public class UserDataServiceTest
    {
        private IConnectionStringFactory _connectionString;
        private Persistence.User.Model.User _testUser;

        private UserDataServiceTestFixture _fixture;

        [TestInitialize]
        public async Task TestInitializeAsync()
        {
            _connectionString = new ConnectionStringFactory();
            _fixture = new UserDataServiceTestFixture();

            using (var context = new UserContext(_connectionString))
            {

                var newlyCreatedUser = new Persistence.User.Model.User
                {
                    UserName = "JohnDoe2000",
                    Email = "JohnDoe2000@coolmail.com"
                };
                context.User.Add(newlyCreatedUser);
                await context.SaveChangesAsync();

                _testUser = context.User.FirstOrDefault(x => x.ID == newlyCreatedUser.ID);
            }
        }

        [TestCleanup]
        public async Task CleanUpTestDataAsync()
        {
            using (var context = new UserContext(_connectionString))
            {
                var oldTestResults = context.User.Where(x => x.ID == _testUser.ID);

                if (!oldTestResults.Any()) return;
                foreach (var user in oldTestResults)
                {
                    context.User.Remove(user);
                }

                await context.SaveChangesAsync();
            }
        }
        [TestMethod, Owner("PML"), TestCategory("IntegrationsTest")]
        public async Task GetUser_CanFindValueId_GetSuccessfullyAsync()
        {
            // Arrange
            var dataService = _fixture.Create();

            // Act

            var entries = await dataService.GetAsync(_testUser.ID);

            // Assert
            Assert.IsTrue(entries != null, "Not able to fetch user from ID.");
        }

        [TestMethod, Owner("PML"), TestCategory("IntegrationsTest")]
        public async Task GetUser_CanFindValueType_GetSuccessfullyAsync()
        {
            // Arrange
            var dataService = _fixture.Create();

            // Act
            var entries = await dataService.GetAsync(_testUser.ID);

            // Assert
            Assert.IsTrue(entries != null, string.Format("Not able to fetch user from ID: {0}.", _testUser.ID));
        }

        [TestMethod, Owner("PML"), TestCategory("IntegrationsTest")]
        public async Task CreateUser_ValidModel_SuccessfullyCreatedAsync()
        {
            // Arrange
            var dataService = _fixture.Create();
            var user = await dataService.GetAsync(_testUser.ID);
            await CleanUpTestDataAsync();

            var model = new UserModel
            {
                ID = _testUser.ID,
                UserName = user.UserName
            };

            // Act
            var result = await dataService.CreateAsync(model);
            _testUser.ID = result.ResultValue ?? 0;

            // Assert
            Assert.AreNotEqual(0, _testUser.ID);
            Assert.IsTrue(result.Success);
        }

        [TestMethod, Owner("PML"), TestCategory("IntegrationsTest")]
        public async Task UpdateUser_ValidData_SuccessfullyUpdatedAsync()
        {
            // Arrange
            var dataService = _fixture.Create();
            var model = await dataService.GetAsync(_testUser.ID);
            var newUserName = "NewJohnDoe3000";

            model.UserName = newUserName;

            // Act
            await dataService.UpdateAsync(model);
            var fetchResult = await dataService.GetAsync(model.ID);

            // Assert
            Assert.AreEqual(newUserName, fetchResult.UserName);
        }

        [TestMethod, Owner("PML"), TestCategory("IntegrationsTest")]
        public async Task DeleteUser_SpecificationExists_SuccessfullyDeletedAsync()
        {
            // Arrange
            var dataService = _fixture.Create();

            // Act
            var deleted = await dataService.DeleteAsync(_testUser.ID);

            // Assert
            Assert.IsNotNull(deleted, "Could not delete user.");
        }
    }
}

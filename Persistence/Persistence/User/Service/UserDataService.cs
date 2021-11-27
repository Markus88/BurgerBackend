using AutoMapper;
using Persistence.ConnectionStringFactory;
using User.Domain.Interface.Model;
using User.Domain.Interface.Persistence;

namespace Persistence.User.Service
{
    public class UserDataService : IUserDataService
    {
        private readonly IConnectionStringFactory _connectionStringFactory;
        private readonly IMapper _mapper;

        public UserDataService(IConnectionStringFactory connectionStringFactory, IMapper mapper)
        {
            _connectionStringFactory = connectionStringFactory ?? throw new ArgumentNullException(nameof(connectionStringFactory));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<int?> CreateAsync(IUserModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IUserModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IUserModel>> GetAsync(string matterId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IUserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
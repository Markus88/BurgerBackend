using User.Domain.Interface.Model;

namespace User.Domain.Interface.Persistence
{
    public interface IUserDataService
    {
        Task<IUserModel> GetAsync(int id);
        Task<IEnumerable<IUserModel>> GetAsync(string matterId);
        Task<int?> CreateAsync(IUserModel model);
        Task UpdateAsync(IUserModel model);
        Task DeleteAsync(int id);
    }
}
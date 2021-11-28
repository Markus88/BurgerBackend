using CrossTools.ResultHandling.Interface;
using User.Domain.Interface.Model;

namespace User.Domain.Interface.Persistence
{
    public interface IUserDataService
    {
        Task<IUserModel> GetAsync(int id);
        Task<IErrorResult<int?, IExtendedError<IUserModel>>> CreateAsync(IUserModel userModel);
        Task<INotification<IExtendedError<IUserModel>>> UpdateAsync(IUserModel userModel);
        Task<IErrorResult<IExtendedError<IUserModel>>> DeleteAsync(int id);
    }
}
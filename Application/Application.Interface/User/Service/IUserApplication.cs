using Application.Interface.User.Model;
using CrossTools.ResultHandling.Interface;

namespace Application.Interface.User.Service
{
    public interface IUserApplication
    {
        Task<IErrorResult<UserReadDto, ISimpleError>> GetAsync(int id);
        Task<IErrorResult<int?, IExtendedError<UserWriteDto>>> CreateAsync(UserWriteDto userDto);
        Task<IErrorResult<IExtendedError<UserWriteDto>>> UpdateAsync(UserWriteDto userDto);
        Task<IErrorResult<IExtendedError<UserWriteDto>>> DeleteAsync(int id);
    }
}
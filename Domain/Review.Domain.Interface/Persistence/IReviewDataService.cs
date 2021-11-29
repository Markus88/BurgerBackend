using CrossTools.ResultHandling.Interface;
using Review.Domain.Interface.Model;

namespace Review.Domain.Interface.Persistence
{
    public interface IReviewDataService
    {
        Task<IReviewModel> GetAsync(int id);
        Task<IErrorResult<int?, IExtendedError<IReviewModel>>> CreateAsync(IReviewModel reviewModel);
        Task<IErrorResult<IExtendedError<IReviewModel>>> DeleteAsync(int id);
    }
}
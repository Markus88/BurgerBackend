using Application.Interface.Review.Model;
using CrossTools.ResultHandling.Interface;

namespace Application.Interface.Review.Service
{
    public interface IReviewApplication
    {
        Task<IErrorResult<ReviewReadDto, ISimpleError>> GetAsync(int id);
        Task<IErrorResult<int?, IExtendedError<ReviewWriteDto>>> CreateAsync(ReviewWriteDto reviewDto);
        Task<IErrorResult<IExtendedError<ReviewWriteDto>>> DeleteAsync(int id);
    }
}
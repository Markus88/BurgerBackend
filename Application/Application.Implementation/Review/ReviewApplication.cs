using Application.Interface.Review.Model;
using Application.Interface.Review.Service;
using AutoMapper;
using CrossTools.ExtensionTools;
using CrossTools.ExtensionTools.Validation;
using CrossTools.ResultHandling.Implementation;
using CrossTools.ResultHandling.Interface;
using CrossTools.ResultHandling.Interface.Validation.Error;
using Review.Domain.Interface.Model;
using Review.Domain.Interface.Persistence;

namespace Application.Implementation.Review
{
    public class ReviewApplication : IReviewApplication
    {
        private readonly IReviewDataService _reviewDataService;
        private readonly IMapper _mapper;
        private readonly IModelValidationService _modelValidationService;

        public ReviewApplication(
          IReviewDataService reviewDataService,
          IMapper mapper,
          IModelValidationService modelValidationService)
        {
            _reviewDataService = reviewDataService ?? throw new ArgumentNullException(nameof(reviewDataService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _modelValidationService = modelValidationService ?? throw new ArgumentNullException(nameof(modelValidationService));
        }

        public async Task<IErrorResult<ReviewReadDto, ISimpleError>> GetAsync(int id)
        {
            var notification = new Notification<ISimpleError>();
            var reviewResult = await _reviewDataService.GetAsync(id);

            var reviewDto = _mapper.Map<IReviewModel, ReviewReadDto>(reviewResult);
            reviewDto.Rating = CalculateRating(reviewDto);

            return ErrorResult.CreateResult(reviewDto, notification);
        }

        public async Task<IErrorResult<int?, IExtendedError<ReviewWriteDto>>> CreateAsync(ReviewWriteDto reviewDto)
        {
            if (reviewDto is null)
            {
                return ErrorResult.Fail<int?, IExtendedError<ReviewWriteDto>>(new ExtendedError<ReviewWriteDto>(new IsNull(), nameof(ReviewWriteDto)));
            }

            var reviewModel = _mapper.Map<ReviewWriteDto, IReviewModel>(reviewDto);
            var modelValidation = NotificationAutoMapper.Map
              <IReviewModel, ReviewWriteDto>(_modelValidationService.Validate<IReviewModel>(reviewModel), _mapper);

            if (modelValidation.HasErrors())
            {
                return ErrorResult.Fail<int?, IExtendedError<ReviewWriteDto>>(modelValidation);
            }


            var result = await _reviewDataService.CreateAsync(reviewModel);

            var persistanceNotifications = NotificationAutoMapper.Map<IReviewModel, ReviewWriteDto>(result.Notification, _mapper);
            modelValidation.Merge(persistanceNotifications);

            return ErrorResult.CreateResult(result.ResultValue, modelValidation);
        }

        public async Task<IErrorResult<IExtendedError<ReviewWriteDto>>> DeleteAsync(int id)
        {
            var deleted = await _reviewDataService.DeleteAsync(id);
            var persistanceNotifications = NotificationAutoMapper.Map<IReviewModel, ReviewWriteDto>(deleted.Notification, _mapper);

            return ErrorResult.CreateResult(deleted, persistanceNotifications);
        }

        private int CalculateRating(ReviewReadDto reviewReadDto)
        {
            return (reviewReadDto.Taste + reviewReadDto.Texture + reviewReadDto.VisualPresentation) / 3;
        }
    }
}

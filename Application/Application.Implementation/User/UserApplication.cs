using Application.Interface.User.Model;
using Application.Interface.User.Service;
using AutoMapper;
using CrossTools.ExtensionTools;
using CrossTools.ExtensionTools.Validation;
using CrossTools.ResultHandling.Implementation;
using CrossTools.ResultHandling.Interface;
using CrossTools.ResultHandling.Interface.Validation.Error;
using User.Domain.Interface.Model;
using User.Domain.Interface.Persistence;

namespace Application.Implementation.User
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserDataService _userDataService;
        private readonly IMapper _mapper;
        private readonly IModelValidationService _modelValidationService;

        public UserApplication(
          IUserDataService userDataService,
          IMapper mapper,
          IModelValidationService modelValidationService)
        {
            _userDataService = userDataService ?? throw new ArgumentNullException(nameof(userDataService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _modelValidationService = modelValidationService ?? throw new ArgumentNullException(nameof(modelValidationService));
        }

        public async Task<IErrorResult<UserReadDto, ISimpleError>> GetAsync(int id)
        {
            var notification = new Notification<ISimpleError>();
            var userResult = await _userDataService.GetAsync(id);

            var userDto = _mapper.Map<IUserModel, UserReadDto>(userResult);

            return ErrorResult.CreateResult(userDto, notification);
        }

        public async Task<IErrorResult<int?, IExtendedError<UserWriteDto>>> CreateAsync(UserWriteDto userDto)
        {
            if (userDto is null)
            {
                return ErrorResult.Fail<int?, IExtendedError<UserWriteDto>>(new ExtendedError<UserWriteDto>(new IsNull(), nameof(UserWriteDto)));
            }

            var userModel = _mapper.Map<UserWriteDto, IUserModel>(userDto);
            var modelValidation = NotificationAutoMapper.Map
              <IUserModel, UserWriteDto>(_modelValidationService.Validate<IUserModel>(userModel), _mapper);

            if (modelValidation.HasErrors())
            {
                return ErrorResult.Fail<int?, IExtendedError<UserWriteDto>>(modelValidation);
            }

            var result = await _userDataService.CreateAsync(userModel);

            var persistanceNotifications = NotificationAutoMapper.Map<IUserModel, UserWriteDto>(result.Notification, _mapper);
            modelValidation.Merge(persistanceNotifications);

            return ErrorResult.CreateResult(result.ResultValue, modelValidation);
        }

        public async Task<IErrorResult<IExtendedError<UserWriteDto>>> UpdateAsync(UserWriteDto userDto)
        {
            if (userDto is null) return ErrorResult.Fail<IExtendedError<UserWriteDto>>(
                new ExtendedError<UserWriteDto>(new IsNull(), nameof(userDto)));

            var userModel = _mapper.Map<UserWriteDto, IUserModel>(userDto);
            var userModelValidation = NotificationAutoMapper.Map
              <IUserModel, UserWriteDto>(_modelValidationService.Validate<IUserModel>(userModel), _mapper);

            if (userModelValidation.HasErrors())
            {
                return ErrorResult.Fail(userModelValidation);
            }

            var updateResult = await _userDataService.UpdateAsync(userModel);
            return ErrorResult.CreateResult<IUserModel, UserWriteDto>(updateResult, _mapper);
        }

        public async Task<IErrorResult<IExtendedError<UserWriteDto>>> DeleteAsync(int id)
        {
            var deleted = await _userDataService.DeleteAsync(id);
            var persistanceNotifications = NotificationAutoMapper.Map<IUserModel, UserWriteDto>(deleted.Notification, _mapper);

            return ErrorResult.CreateResult(deleted, persistanceNotifications);
        }
    }
}

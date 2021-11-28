using AutoMapper;
using CrossTools.ExtensionTools;
using CrossTools.ResultHandling.Interface;

namespace CrossTools.ResultHandling.Implementation
{
    public class ErrorResult : Result, IErrorResult
    {
        protected ErrorResult(bool success) : base(success)
        {
        }

        public static IErrorResult<TError> Ok<TError>() where TError : IError
        {
            return new ErrorResult<TError>(true);
        }

        public static IErrorResult<TResultValue, TError> Ok<TResultValue, TError>(TResultValue resultValue) where TError : IError
        {
            return new ErrorResult<TResultValue, TError>(resultValue, true);
        }

        public static IErrorResult<TType, TError> Ok<TModel, TType, TError>(TModel resultValue, IMapper mapper) where TError : IError
        {
            return new ErrorResult<TType, TError>(mapper.Map<TModel, TType>(resultValue), true);
        }

        public static IErrorResult<TError> Fail<TError>(TError error) where TError : IError
        {
            var notification = new Notification<TError>();
            notification.Add(error);
            return new ErrorResult<TError>(false, notification);
        }

        public static IErrorResult<TError> Fail<TError>(INotification<TError> notification) where TError : IError
        {
            return new ErrorResult<TError>(false, notification);
        }

        public static IErrorResult<TResultValue, TError> Fail<TResultValue, TError>(TError error) where TError : IError
        {
            var notification = new Notification<TError>();
            notification.Add(error);
            return new ErrorResult<TResultValue, TError>(default, false, notification);
        }

        public static IErrorResult<TResultValue, TError> Fail<TResultValue, TError>(INotification<TError> notification) where TError : IError
        {
            return new ErrorResult<TResultValue, TError>(default, false, notification);
        }

        public static IErrorResult<TResultValue, IExtendedError<TType>> Fail<TResultValue, TModel, TType>(INotification<IExtendedError<TModel>> notification, IMapper mapper)
        {
            return Fail<TResultValue, IExtendedError<TType>>(NotificationAutoMapper.Map<TModel, TType>(notification, mapper));
        }

        public static IErrorResult<TErrorResult> CreateResult<TErrorResult>(INotification<TErrorResult> notification) where TErrorResult : IError
        {
            if (notification.HasErrors()) return Fail<TErrorResult>(notification);
            return Ok<TErrorResult>();
        }

        public static IErrorResult<TResultValue, ISimpleError> CreateResult<TResultValue>(TResultValue resultValue, INotification<ISimpleError> notification)
        {
            if (notification.HasErrors())
            {
                return Fail<TResultValue, ISimpleError>(notification);
            }
            return Ok<TResultValue, ISimpleError>(resultValue);
        }

        public static IErrorResult<TResultValue, IExtendedError> CreateResult<TResultValue>(TResultValue resultValue, INotification<IExtendedError> notification)
        {
            if (notification.HasErrors())
            {
                return Fail<TResultValue, IExtendedError>(notification);
            }
            return Ok<TResultValue, IExtendedError>(resultValue);
        }

        public static IErrorResult<IEnumerable<TType>, ISimpleError> CreateResult<TModel, TType>(IEnumerable<TModel> resultList, INotification<ISimpleError> notification, IModelMapper<TModel, TType> mapper)
        {
            if (notification.HasErrors())
            {
                return Fail<IEnumerable<TType>, ISimpleError>(notification);
            }
            return Ok<IEnumerable<TType>, ISimpleError>(resultList.Select(d => mapper.MapFromDomain(d)));
        }

        public static IErrorResult<IExtendedError<TType>> CreateResult<TModel, TType>(INotification<IExtendedError<TModel>> notification, INotificationMapper<TModel, TType> mapper)
        {
            if (notification.HasErrors())
            {
                return Fail<IExtendedError<TType>>(mapper.Map(notification));
            }
            return Ok<IExtendedError<TType>>();
        }

        public static IErrorResult<TResultValue, IExtendedError<TType>> CreateResult<TResultValue, TModel, TType>(TResultValue resultValue, INotification<IExtendedError<TModel>> notification, INotificationMapper<TModel, TType> mapper)
        {
            if (notification.HasErrors())
            {
                return Fail<TResultValue, IExtendedError<TType>>(mapper.Map(notification));
            }
            return Ok<TResultValue, IExtendedError<TType>>(resultValue);
        }

        public static IErrorResult<IExtendedError<TType>> CreateResult<TModel, TType>(INotification<IExtendedError<TModel>> notification, IMapper mapper)
        {
            if (notification.HasErrors())
            {
                return Fail(NotificationAutoMapper.Map<TModel, TType>(notification, mapper));
            }
            return Ok<IExtendedError<TType>>();
        }

        public static IErrorResult<TResultValue, IExtendedError<TType>> CreateResult<TResultValue, TModel, TType>(TResultValue resultValue, INotification<IExtendedError<TModel>> notification, IMapper mapper)
        {
            if (notification.HasErrors())
            {
                return Fail<TResultValue, IExtendedError<TType>>(NotificationAutoMapper.Map<TModel, TType>(notification, mapper));
            }
            return Ok<TResultValue, IExtendedError<TType>>(resultValue);
        }

        public static IErrorResult<TResultValue, IExtendedError<TType>> CreateResult<TResultValue, TType>(TResultValue resultValue, INotification<IExtendedError<TType>> notification)
        {
            if (notification.HasErrors())
            {
                return Fail<TResultValue, IExtendedError<TType>>(notification);
            }
            return Ok<TResultValue, IExtendedError<TType>>(resultValue);
        }
    }

    public class ErrorResult<TError> : ErrorResult, IErrorResult<TError> where TError : IError
    {
        protected internal ErrorResult(bool success) : this(success, new Notification<TError>())
        {
        }

        protected internal ErrorResult(bool success, INotification<TError> notification) : base(success)
        {
            Notification = notification;
        }

        public INotification<TError> Notification { get; }
    }

    public class ErrorResult<TResultValue, TError> : ErrorResult<TError>, IErrorResult<TResultValue, TError> where TError : IError
    {
        protected internal ErrorResult(TResultValue resultValue, bool success) : this(resultValue, success, new Notification<TError>())
        {
        }

        protected internal ErrorResult(TResultValue resultValue, bool success, INotification<TError> notification) : base(success, notification)
        {
            ResultValue = resultValue;
        }

        public TResultValue ResultValue { get; }
    }
}

using AutoMapper;
using CrossTools.ResultHandling.Implementation;
using CrossTools.ResultHandling.Interface;

namespace CrossTools.ExtensionTools
{
    public static class NotificationAutoMapper
    {
        public static INotification<IExtendedError<TTo>> Map<TFrom, TTo>(INotification<IExtendedError<TFrom>> modelNotification, IMapper mapper)
        {
            var notification = new Notification<IExtendedError<TTo>>();

            var errors = modelNotification?.GetErrors();
            if (errors is null || !errors.Any()) return notification;

            var sourceDestinationDictionary = mapper.GetIdentifiers<TFrom, TTo>(errors.Select(e => e.Identifier).ToList());

            foreach (var error in modelNotification.GetErrors())
            {
                var identifier = sourceDestinationDictionary[error.Identifier]; // Exception if not found
                if (typeof(TTo).Name == identifier)
                {
                    notification.Add(new ExtendedError<TTo>(error.ValidationError));
                }
                else
                {
                    notification.Add(new ExtendedError<TTo>(error.ValidationError, identifier));
                }
            }
            return notification;
        }
    }
}

using CrossTools.ResultHandling.Interface;

namespace CrossTools.ExtensionTools
{
    public interface INotificationMapper<TFrom, TTo>
    {
        INotification<IExtendedError> Map(INotification<IExtendedError> modelNotification);
        INotification<IExtendedError<TTo>> Map(INotification<IExtendedError<TFrom>> modelNotification);
    }
}

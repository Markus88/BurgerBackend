using CrossTools.ResultHandling.Interface;

namespace CrossTools.ExtensionTools.Validation
{
    public interface IModelValidationService
    {
        INotification<IExtendedError<TType>> Validate<TType>(object subject);
    }
}

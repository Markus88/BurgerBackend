using CrossTools.ResultHandling.Interface.Validation;

namespace CrossTools.ResultHandling.Interface
{
    public interface IError
    {
        string Description { get; }
        ValidationError ValidationError { get; }
        string Reason { get; }
    }
}
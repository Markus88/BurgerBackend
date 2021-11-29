namespace CrossTools.ResultHandling.Interface
{
    public interface IErrorResult : IResult
    {
    }

    public interface IErrorResult<TError> : IErrorResult where TError : IError
    {
        INotification<TError> Notification { get; }
    }

    public interface IErrorResult<TResultValue, TError> : IErrorResult<TError> where TError : IError
    {
        TResultValue ResultValue { get; }
    }
}
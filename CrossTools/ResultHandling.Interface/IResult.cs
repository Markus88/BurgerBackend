namespace CrossTools.ResultHandling.Interface
{
    public interface IResult
    {
        bool Success { get; }
    }

    public interface IResultValue<out TResultValue> : IResult
    {
        TResultValue Value { get; }
    }
}
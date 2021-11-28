namespace CrossTools.ResultHandling.Interface
{
    public interface IExtendedError : IError
    {
        string Identifier { get; }
    }

    public interface IExtendedError<TType> : IExtendedError
    {
    }
}
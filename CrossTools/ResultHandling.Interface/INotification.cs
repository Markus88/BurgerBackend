namespace CrossTools.ResultHandling.Interface
{
    public interface INotification<TError> where TError : IError
    {
        void Add(TError error);
        void Merge(INotification<TError> notification);
        IReadOnlyList<TError> GetErrors();
        TError GetFirstError();
        bool HasErrors();
    }
}
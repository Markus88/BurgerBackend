using CrossTools.ResultHandling.Interface;
using Newtonsoft.Json;

namespace CrossTools.ResultHandling.Implementation
{
    public class Notification<TError> : INotification<TError> where TError : IError
    {
        [JsonProperty]
        private readonly List<TError> _errors = new List<TError>();

        public Notification()
        {
        }

        public Notification(TError error)
        {
            _errors.Add(error);
        }

        public void Merge(INotification<TError> notification)
        {
            foreach (var error in notification.GetErrors())
            {
                _errors.Add(error);
            }
        }

        public void Add(TError error)
        {
            _errors.Add(error);
        }

        public IReadOnlyList<TError> GetErrors()
        {
            return _errors;
        }

        public TError GetFirstError()
        {
            return _errors.FirstOrDefault();
        }

        public bool HasErrors()
        {
            return _errors.Any();
        }
    }
}
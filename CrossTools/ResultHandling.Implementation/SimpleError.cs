using CrossTools.ResultHandling.Interface;
using CrossTools.ResultHandling.Interface.Validation;
using Newtonsoft.Json;

namespace CrossTools.ResultHandling.Implementation
{
    public class SimpleError : ISimpleError
    {
        public SimpleError(ValidationError validationError)
        {
            ValidationError = validationError;
            Description = validationError.Message;
        }

        [JsonIgnore]
        public ValidationError ValidationError { get; }
        public string Reason => ValidationError?.Reason;
        public string Description { get; }
    }
}

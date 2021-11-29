using CrossTools.ResultHandling.Interface.Validation.Status;

namespace CrossTools.ResultHandling.Interface.Validation.Error
{
    public class AlreadyExists : BadRequest
    {
        public AlreadyExists() : this(DefaultErrorMessage)
        {
        }

        public AlreadyExists(string message)
        {
            Message = message;
        }

        public static string DefaultErrorMessage => "Findes allerede.";
        public override string Reason => "AlreadyExists";
        public override string Message { get; }
    }
}
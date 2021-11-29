using CrossTools.ResultHandling.Interface.Validation.Status;

namespace CrossTools.ResultHandling.Interface.Validation.Error
{
    public class NotFound : BadRequest
    {
        public NotFound() : this(DefaultErrorMessage)
        {
        }

        public NotFound(string message)
        {
            Message = message;
        }

        public static string DefaultErrorMessage => "Ikke fundet.";

        // Reason is used as key and should never be changed.
        public override string Reason => "NotFound";
        public override string Message { get; }
    }
}

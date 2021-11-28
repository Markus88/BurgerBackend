using CrossTools.ResultHandling.Interface.Validation.Status;

namespace CrossTools.ResultHandling.Interface.Validation.Error
{
    public class IsNull : BadRequest
    {
        public IsNull() : this(DefaultErrorMessage)
        {
        }

        public IsNull(string message)
        {
            Message = message;
        }

        public static string DefaultErrorMessage => "Må ikke være 'null'.";

        public override string Reason => "IsNull";
        public override string Message { get; }
    }
}

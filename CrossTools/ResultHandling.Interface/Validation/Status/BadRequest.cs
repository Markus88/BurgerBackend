namespace CrossTools.ResultHandling.Interface.Validation.Status
{
    public abstract class BadRequest : ValidationError
    {
        public sealed override int Priority => 5;
    }
}

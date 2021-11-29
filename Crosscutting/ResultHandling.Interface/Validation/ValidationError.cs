namespace CrossTools.ResultHandling.Interface.Validation
{
    public abstract class ValidationError : ValueObject
    {
        public abstract string Reason { get; }
        public abstract int Priority { get; }
        public abstract string Message { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Reason;
        }

        public override string ToString()
        {
            return Reason;
        }
    }
}
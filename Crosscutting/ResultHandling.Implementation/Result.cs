using CrossTools.ResultHandling.Interface;
using System.Text.Json.Serialization;

namespace CrossTools.ResultHandling.Implementation
{
    public class Result : IResult
    {
        protected Result(bool success)
        {
            Success = success;
        }

        [JsonIgnore]
        public bool Success { get; }
    }

    public class ResultValue<TResultValue> : Result, IResultValue<TResultValue>
    {
        protected internal ResultValue(TResultValue value, bool success) : base(success)
        {
            Value = value;
        }

        public TResultValue Value { get; }
    }
}

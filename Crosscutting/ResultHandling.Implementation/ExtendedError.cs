using CrossTools.ResultHandling.Interface;
using CrossTools.ResultHandling.Interface.Validation;
using System.Reflection;
using System.Text.Json.Serialization;

namespace CrossTools.ResultHandling.Implementation
{
    public class ExtendedError : IExtendedError
    {
        public ExtendedError(ValidationError validationError, string identifier)
        {
            ValidationError = validationError;
            Identifier = identifier;
            Description = validationError.Message;
        }

        [JsonIgnore]
        public ValidationError ValidationError { get; }
        public string Reason => ValidationError?.Reason;
        public string Identifier { get; }
        public string Description { get; }
    }

    public class ExtendedError<TType> : IExtendedError<TType>
    {
        public ExtendedError(ValidationError validationError)
        {
            ValidationError = validationError;
            Identifier = typeof(TType).Name;
            Description = validationError.Message;
        }

        public ExtendedError(ValidationError validationError, string identifier)
        {
            if (!typeof(TType).Name.Equals(identifier) && !PropertyExists(identifier))
            {
                throw new InvalidOperationException($"Property field {identifier} does not exist in type {typeof(TType)}.");
            }

            ValidationError = validationError;
            Identifier = identifier;
            Description = validationError.Message;
        }

        [JsonIgnore]
        public ValidationError ValidationError { get; }
        public string Reason => ValidationError?.Reason;
        public string Identifier { get; }
        public string Description { get; }

        private bool PropertyExists(string identifier)
        {
            var propertyParts = identifier.Split('.');

            var checkType = typeof(TType);

            foreach (var propertyPart in propertyParts)
            {
                var member = GetMemberInfo(checkType, propertyPart);

                if (member is null)
                {
                    return false;
                }
                else
                {
                    checkType = member.GetUnderlyingType();
                }
            }

            return true;
        }

        private MemberInfo GetMemberInfo(Type type, string identifier)
        {
            var member = (MemberInfo)type.GetProperty(identifier) ?? type.GetField(identifier);

            if (member is object || !type.IsInterface) return member;

            var baseInterfaces = type.GetInterfaces();
            foreach (var baseInterface in baseInterfaces)
            {
                member = GetMemberInfo(baseInterface, identifier);
                if (member is object) return member;
            }

            return member;
        }
    }
}

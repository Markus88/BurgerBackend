using System.Reflection;

namespace CrossTools.ResultHandling.Interface.Validation
{
    public static class MemberInfoExtension
    {
        public static Type GetUnderlyingType(this MemberInfo memberInfo)
        {
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Constructor:
                    return ((ConstructorInfo)memberInfo).DeclaringType;
                case MemberTypes.Event:
                    return ((EventInfo)memberInfo).EventHandlerType;
                case MemberTypes.Field:
                    return ((FieldInfo)memberInfo).FieldType;
                case MemberTypes.Property:
                    return ((PropertyInfo)memberInfo).PropertyType;
                default:
                    throw new ArgumentException("Input MemberInfo is not supported.");
            }
        }
    }
}

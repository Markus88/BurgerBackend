using AutoMapper;

namespace CrossTools.ExtensionTools
{
    public static class AutoMapperExtension
    {
        public static IDictionary<string, string> GetIdentifiers<TSource, TDestination>(this IMapper mapper, IList<string> sourceProperties)
        {
            return GetDestinationProperties<TSource, TDestination>(mapper, sourceProperties);
        }

        private static IDictionary<string, string> GetDestinationProperties<TSource, TDestination>(IMapper mapper, IList<string> sourceProperties)
        {
            if (sourceProperties.Count == 0) throw new ArgumentException("Empty list is not allowed", nameof(sourceProperties));

            var properties = new Dictionary<string, string>();

            var typeMap = GetTypeMap<TSource, TDestination>(mapper);

            if (sourceProperties.Count == 1)
            {
                return GetFirstProperty<TSource>(sourceProperties, properties, typeMap);
            }

            return GetAllProperties(typeMap);
        }

        private static TypeMap GetTypeMap<TSource, TDestination>(IMapper mapper)
        {
            var configurationProvider = mapper.ConfigurationProvider;

            var typeMap = configurationProvider.FindTypeMapFor<TSource, TDestination>();
            if (typeMap is null)
            {
                throw new InvalidOperationException($"TypeMap was not found for {typeof(TSource).Name} -> {typeof(TDestination).Name}");
            }

            return typeMap;
        }

        private static IDictionary<string, string> GetFirstProperty<TSource>(IList<string> sourceProperties, Dictionary<string, string> properties, TypeMap typeMap)
        {
            var sourceProperty = sourceProperties.First();

            var propertyMap = typeMap.PropertyMaps.FirstOrDefault(p => p.SourceMember.Name == sourceProperty);
            if (propertyMap is null)
            {
                if (typeMap.Types.SourceType.Name == sourceProperty)
                {
                    // If the source property is the name of the source object, use the destination object name
                    properties.Add(sourceProperty, typeMap.Types.DestinationType.Name);
                    return properties;
                }
                else
                {
                    // If the source property does not have a PropertyMap, use the destination object name
                    properties.Add(sourceProperty, typeMap.Types.DestinationType.Name);
                    return properties;
                }
            }

            properties.Add(sourceProperty, propertyMap.DestinationMember.Name);
            return properties;
        }

        private static IDictionary<string, string> GetAllProperties(TypeMap typeMap)
        {
            var propertyMapping = typeMap.PropertyMaps.ToDictionary(p => p.SourceMember.Name, p => p.DestinationMember.Name);
            propertyMapping.Add(typeMap.Types.SourceType.Name, typeMap.DestinationType.Name);

            return propertyMapping;
        }
    }
}

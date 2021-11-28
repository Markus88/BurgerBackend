using Microsoft.AspNetCore.Mvc.Routing;

namespace Burger_Backend.Infrastrukture
{
    // https://github.com/dotnet/aspnetcore/blob/release/3.1/src/Mvc/Mvc.Core/src/RouteAttribute.cs
    /// <summary>
    /// Implementation of RouteAttribute that adds API version to the beginning of the route.
    /// If <see cref="RouteVersion"/> is not specified, the default value is <see cref="RouteVersion.V1"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class VersionRouteAttribute : Attribute, IRouteTemplateProvider
    {
        private string _template;
        private int? _order;

        public VersionRouteAttribute(string template)
        {
            Template = template ?? throw new ArgumentNullException(nameof(template));
        }

        /// <inheritdoc />
        public string Template
        {
            get => $"{_routeVersionDictionary[RouteVersion]}/{_template}";
            private set => _template = value;
        }

        /// <summary>
        /// Gets the route order. The order determines the order of route execution. Routes with a lower order
        /// value are tried first. If an action defines a route by providing an <see cref="IRouteTemplateProvider"/>
        /// with a non <c>null</c> order, that order is used instead of this value. If neither the action nor the
        /// controller defines an order, a default value of 0 is used.
        /// </summary>
        public int Order
        {
            get => _order ?? 0;
            set => _order = value;
        }

        /// <inheritdoc />
        int? IRouteTemplateProvider.Order => _order;

        /// <inheritdoc />
        public string Name { get; set; }

        /// <summary>
        /// Adds version to the beginning of the route.
        /// Default value is <see cref="RouteVersion.V1"/>.
        /// </summary>
        public RouteVersion RouteVersion { get; set; } = RouteVersion.V1;

        private static readonly Dictionary<RouteVersion, string> _routeVersionDictionary = new Dictionary<RouteVersion, string>
    {
      {RouteVersion.V1, "v1"},
      {RouteVersion.V2, "v2"},
      {RouteVersion.V3, "v3"},
      {RouteVersion.V4, "v4"},
      {RouteVersion.V5, "v5"},
      {RouteVersion.V6, "v6"},
      {RouteVersion.V7, "v7"},
      {RouteVersion.V8, "v8"},
      {RouteVersion.V9, "v9"},
      {RouteVersion.V10, "v10"}
    };
    }

    public enum RouteVersion
    {
        V1 = 1,
        V2 = 2,
        V3 = 3,
        V4 = 4,
        V5 = 5,
        V6 = 6,
        V7 = 7,
        V8 = 8,
        V9 = 9,
        V10 = 10
    }
}
using Newtonsoft.Json.Serialization;

namespace SlackHooks.Serialization.Resolvers
{
    /// <summary>
    /// Lower Case Contract Resolver
    /// </summary>
    public class LowerCaseContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// Resolve Property Name.
        /// Returns the name of the property, converted to lower-case.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The converted property name.</returns>
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
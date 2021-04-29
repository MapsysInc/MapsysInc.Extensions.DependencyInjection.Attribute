namespace MapsysInc.Extensions.DependencyInjection.AttributeRegistration
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Query from https://stackoverflow.com/a/607216
    /// </summary>
    public static class AssemblyDependancyBuilder
    {
        public static void AddAssemblyAttributes(this IServiceCollection services)
        {
            var typesWithMyAttribute =
    // Note the AsParallel here, this will parallelize everything after.
    from a in AppDomain.CurrentDomain.GetAssemblies().AsParallel()
    from t in a.GetTypes()
    let attributes = t.GetCustomAttributes(typeof(LifetimeAttribute), true)
    where attributes != null && attributes.Length > 0
    select new { Type = t, Attributes = attributes.Cast<LifetimeAttribute>() };
            foreach (var type in typesWithMyAttribute)
            {
                var attr = type.Type.CustomAttributes.FirstOrDefault(x => (typeof(LifetimeAttribute).IsAssignableFrom(x.AttributeType)));

                Type serviceType = type.Type;
                CustomAttributeNamedArgument parm = attr.NamedArguments.FirstOrDefault(y => y.MemberName == nameof(LifetimeAttribute.ServiceType));
                if (parm.TypedValue.Value != null && parm.TypedValue.Value.GetType() == typeof(Type))
                {
                    serviceType = parm.TypedValue.Value as Type;
                }
                var attrInstance = Activator.CreateInstance(type.Attributes.First().GetType()) as LifetimeAttribute;
                services.Add(new ServiceDescriptor(serviceType, type.Type, attrInstance.ServiceLifetime));


            }
        }
    }
}

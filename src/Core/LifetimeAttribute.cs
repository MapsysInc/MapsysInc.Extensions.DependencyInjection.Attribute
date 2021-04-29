namespace MapsysInc.Extensions.DependencyInjection.AttributeRegistration
{
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public abstract class LifetimeAttribute : Attribute
    {
        protected LifetimeAttribute(ServiceLifetime serviceLifetime)
        {
            ServiceLifetime = serviceLifetime;
        }

        public ServiceLifetime ServiceLifetime { get; }

        public Type ServiceType { get; set; }
    }
}
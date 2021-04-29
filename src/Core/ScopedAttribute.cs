namespace MapsysInc.Extensions.DependencyInjection.AttributeRegistration
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public sealed class ScopedAttribute : LifetimeAttribute
    {
        public ScopedAttribute() : base(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Scoped)
        {
        }

    }
}
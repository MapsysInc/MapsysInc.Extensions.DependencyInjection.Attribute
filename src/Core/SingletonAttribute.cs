namespace MapsysInc.Extensions.DependencyInjection.AttributeRegistration
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public sealed class SingletonAttribute : LifetimeAttribute
    {
        public SingletonAttribute() : base(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton)
        {
        }

    }
}

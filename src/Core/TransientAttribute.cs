namespace MapsysInc.Extensions.DependencyInjection.AttributeRegistration
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public sealed class TransientAttribute : LifetimeAttribute
    {
        public TransientAttribute() : base(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Transient)
        {
        }
    }

}

using LightInject;
using LightInject.Microsoft.DependencyInjection;

namespace Synnotech_BplusZ.WebApi.Infrastucture
{
    public static class DependencyInjectionContainer
    {
        public static ServiceContainer Instance { get; } = new ServiceContainer(ContainerOptions.Default.WithMicrosoftSettings());
    }
}

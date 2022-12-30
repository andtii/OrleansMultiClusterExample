namespace OrleansMultiClusterExample.Cluster1
{
    public class OrleansClientServiceProviderFactory : IServiceProviderFactory<IServiceCollection>
    {
        public IServiceProvider ServiceProvider { get; private set; }
        public IServiceProvider CreateServiceProvider(IServiceCollection containerBuilder)
        {
            var serviceProvider = containerBuilder.BuildServiceProvider();
            ServiceProvider = serviceProvider;
            return serviceProvider;
        }

        IServiceCollection IServiceProviderFactory<IServiceCollection>.CreateBuilder(IServiceCollection services)
        {
            return services == null ? new ServiceCollection() : services;
        }
    }

}

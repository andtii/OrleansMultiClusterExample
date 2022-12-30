using OrleansMultiClusterExample.Shared;

namespace OrleansMultiClusterExample.Cluster1.Grains
{
    public class Cluster1Grain : ICluster1Grain
    {
        private readonly IClusterClient _orleansClient;

        public Cluster1Grain(OrleansClientServiceProviderFactory factory)
        {
            _orleansClient = factory.ServiceProvider.GetRequiredService<IClusterClient>();
            
        }

        public Task<string> CallCluster2UsingClient()
        {
            var cluster2Grain = _orleansClient.GetGrain<ICluster2Grain>("");
            return cluster2Grain.ReturnValueToCluster1();
        }
    }
}
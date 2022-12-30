using OrleansMultiClusterExample.Shared;

namespace OrleansMultiClusterExample.Cluster2.Grains
{
    public class Cluster2Grain : ICluster2Grain
    {
        public Task<string> ReturnValueToCluster1()
        {
            return Task.FromResult("Hello from Cluster2");
        }
    }
}
namespace OrleansMultiClusterExample.Shared
{
    public interface ICluster2Grain : IGrainWithStringKey
    {
        public Task<string> ReturnValueToCluster1();

    }
}
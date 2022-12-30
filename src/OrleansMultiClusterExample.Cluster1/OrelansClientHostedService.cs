using OrleansMultiClusterExample.Shared;

namespace OrleansMultiClusterExample.Cluster1
{
    public class OrleansClientHostedService : BackgroundService
    {
        private readonly IClusterClient _orleansClient;

        public OrleansClientHostedService(IClusterClient orleansClient)
        {
            _orleansClient = orleansClient;

           //Here is the null ISSUE!!!
           var test = _orleansClient.GetGrain<ICluster2Grain>("");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var command = Console.ReadLine();
            }

            return Task.CompletedTask;
        }
    }
}

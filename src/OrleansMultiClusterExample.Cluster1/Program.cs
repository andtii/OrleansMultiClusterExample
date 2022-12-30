
using Orleans;
using Orleans.Runtime;
using Orleans.Hosting;
using Orleans.Configuration;
using OrleansMultiClusterExample.Cluster1.Grains;
using OrleansMultiClusterExample.Cluster1;

var builder = WebApplication.CreateBuilder(args);


//Create and setup the client host to call cluster 2 from cluster 1
var customProvider = new OrleansClientServiceProviderFactory();
var clientBuilder = new HostBuilder()
    .ConfigureServices((services) =>
    {
        services.AddHostedService<OrleansClientHostedService>();
    })
     .UseOrleansClient((clientBuilder) =>
     {
         clientBuilder.Configure((Action<ClusterOptions>)(options =>
         {
             options.ClusterId = "cluster2";
             options.ServiceId = "cluster2";
         }));

         clientBuilder.UseRedisClustering(options => options.ConnectionString = $"keydb:6379");

     })
    .Build();


builder.Host.UseOrleans((ctx, siloBuilder) =>
 {
     siloBuilder.UseRedisClustering(options => options.ConnectionString = $"localhost:6379")

       .Configure((Action<ClusterOptions>)(options =>
       {
             options.ClusterId = $"cluster1";
             options.ServiceId = "cluster1";
         }));

 });

builder.Services.AddSingleton<OrleansClientServiceProviderFactory>();

var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("/cluster1", (IClusterClient cluster1Client) =>
{
    return cluster1Client.GetGrain<ICluster1Grain>("").CallCluster2UsingClient();
});

await Task.WhenAll(clientBuilder.RunAsync(), app.RunAsync());

using Orleans.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseOrleans((ctx, siloBuilder) =>
{
    siloBuilder.UseRedisClustering(options => options.ConnectionString = $"localhost:6379")

      .Configure((Action<ClusterOptions>)(options =>
      {
          options.ClusterId = $"cluster2";
          options.ServiceId = "cluster2";
      }));

});
var app = builder.Build();
app.UseHttpsRedirection();
app.Run();

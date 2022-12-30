using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrleansMultiClusterExample.Cluster1.Grains
{
    public interface ICluster1Grain : IGrainWithStringKey
    {
        public Task<string> CallCluster2UsingClient();

    }
}

# Microsoft Orleans Multi Cluster grains example

Demonstrates having 2 different Orleans clusters and supports having grains in Cluster1 to call Cluster2 grains. Since Orleans does not support having a client in the same host this example is using a seperate hostbuilder to create the client and then it makes it available in the second host using a "client" built service provider injected to the second host.

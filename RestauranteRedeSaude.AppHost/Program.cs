var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.RestauranteRedeSaude_ApiService>("apiservice");

builder.AddProject<Projects.RestauranteRedeSaude_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.RestauranteRedeSaude_ApiService>("apiservice");

builder.AddProject<Projects.RestauranteRedeSaude_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.AddProject<Projects.RestauranteRedeSaudeFornecedores>("restauranteredesaudefornecedores");

builder.AddProject<Projects.RestauranteRedeSaudeEstoque>("restauranteredesaudeestoque");

builder.AddProject<Projects.RestauranteRedeSaudeFuncionarios>("restauranteredesaudefuncionarios");

builder.AddProject<Projects.RestauranteRedeSaudePrato>("restauranteredesaudeprato");




builder.Build().Run();

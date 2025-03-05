var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.eCiliation_Web>("eciliation-web");

builder.Build().Run();

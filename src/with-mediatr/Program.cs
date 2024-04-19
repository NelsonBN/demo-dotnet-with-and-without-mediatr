using Demo.Infrastructure;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddSingleton<IProductsRepository, ProductsRepository>();

var app = builder.Build();

app.MapProductsEndpoints();

app.Run();

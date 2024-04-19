using Demo.Infrastructure;
using Demo.UseCases;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddSingleton<IProductsRepository, ProductsRepository>();

builder.Services
    .AddTransient<AddProductUseCase>()
    .AddTransient<DeleteProductUseCase>()
    .AddTransient<GetProductUseCase>()
    .AddTransient<GetProductsUseCase>()
    .AddTransient<UpdateProductUseCase>();

var app = builder.Build();

app.MapProductsEndpoints();

app.Run();

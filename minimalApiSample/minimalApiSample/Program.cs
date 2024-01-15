using minimalApiSample;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//burada IoC içerisine kaydettiğiniz ProductService instance'i, minimal api'nin fonksiyonlarında (get, post vb), parametre olarak kullanılmalıdır. 
builder.Services.AddScoped<ProductService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/products", async (ProductService productService) =>
{

    return await productService.GetProductsAsync();
});

app.MapGet("/products/search/{name}", async (string name, ProductService productService) => await productService.SearchAsync(name));


app.MapGet("/products/details/{id}", async (int id, ProductService productService) =>
{

    return await productService.GetProductDetails(id);

});

app.MapPost("/products", async (Product product, ProductService productService) =>
{

    await productService.CreateProduct(product);
    return Results.Created($"/products/details/{product.Id}", product.Id);

});



app.Run();


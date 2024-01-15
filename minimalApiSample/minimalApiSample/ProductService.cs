namespace minimalApiSample
{
    public record Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }

    }
    public class ProductService
    {
        List<Product> products = new()
        {
            new() { Id = 1, Name="Product A", Description="Description of A", Price=1},
            new() { Id = 2, Name="Product B", Description="Description of B", Price=1},
            new() { Id = 3, Name="Product C", Description="Description of C", Price=1},

        };

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await Task.FromResult(products);
        }

        public async Task<IEnumerable<Product>> SearchAsync(string name)
        {
            return await Task.FromResult(products.Where(p => p.Name.Contains(name)));

        }

        public async Task<Product> GetProductDetails(int id) => await Task.FromResult(products.FirstOrDefault(p => p.Id == id));

        public Task CreateProduct(Product product)
        {
            products.Add(product);
            return Task.CompletedTask;
        }

    }
}

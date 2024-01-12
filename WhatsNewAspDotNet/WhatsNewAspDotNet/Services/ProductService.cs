namespace WhatsNewAspDotNet.Services
{
    public class ProductService : IProductService
    {

        private List<Product> products = new List<Product>
        {
            new(){ Name = "A"},
            new(){ Name = "B"},
            new(){ Name = "C"},

        };
        public List<Product> GetProducts()
        {
            return products;
        }
    }

    public class Product
    {
        public string Name { get; set; }
    }
}

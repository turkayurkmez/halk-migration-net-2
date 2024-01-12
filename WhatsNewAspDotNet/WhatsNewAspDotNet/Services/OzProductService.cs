namespace WhatsNewAspDotNet.Services
{
    public class OzProductService : IProductService
    {

        private List<Product> products = new List<Product>
        {
            new(){ Name = "X"},
            new(){ Name = "Y"},
            new(){ Name = "Z"},

        };
        public List<Product> GetProducts()
        {
            return products;
        }
    }


}

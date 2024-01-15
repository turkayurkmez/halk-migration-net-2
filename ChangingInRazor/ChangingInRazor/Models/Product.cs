namespace ChangingInRazor.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductService
    {
        public List<Product> GetProducts() => new()
        {
            new (){ Id=1, Name="A", Price=1, Description="A"},
            new (){ Id=2, Name="B", Price=1, Description="A"},
            new (){ Id=3, Name="C", Price=1, Description="A"},
            new (){ Id=4, Name="D", Price=1, Description="A"},
            new (){ Id=5, Name="E", Price=1, Description="A"},
            new (){ Id=6, Name="F", Price=1, Description="A"},
            new (){ Id=7, Name="G", Price=1, Description="A"},
            new (){ Id=8, Name="H", Price=1, Description="A"},
            new (){ Id=9, Name="I", Price=1, Description="A"},
            new (){ Id=10, Name="J", Price=1, Description="A"},

        };


    }
}

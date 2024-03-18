using e_shop.Models.Product;
namespace e_shop.Brokers.Storages
{
    internal class MemoryBroker : IStorageBroker<Product>
    {
        static List<Product> products = new List<Product>
        {
            new Product {Name = "Banana"},
            new Product {Name = "Ananas"},
            new Product {Name = "Apple"},
            new Product {Name = "Orange"}
        };
        static List<Product> cardProducts = new List<Product>();
        public Product Add(Product product)
        {
            products.Add(product);
            return product;
        }
        public List<Product> GetAllCard()
        {
            return cardProducts;
        }
        public Product AddToCard(Product product)
        {
            cardProducts.Add(product);
            return product;
        }
        public List<Product> GetAll()
        {
            return products;
        }
    }
}

//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
using e_shop.Brokers.Storages;
using e_shop.Models.Product;

namespace e_shop.Services.Storage
{
    internal class ProductService : IProductService
    {
        private readonly MemoryBroker storageBroker;
        public ProductService()
        {
            storageBroker = new MemoryBroker();
        }
        public List<Product> GetProducts()
        {
            return storageBroker.GetAll();
        }
        public List<Product> GetAllCard()
        {
            return storageBroker.GetAllCard();
        }
        public void AddToCard(Product product)
        {
            storageBroker.AddToCard(product);
        }

    }
}

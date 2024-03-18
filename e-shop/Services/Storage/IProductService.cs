//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
using e_shop.Models.Product;

namespace e_shop.Services.Storage
{
    internal interface IProductService
    {
        List<Product> GetProducts();
        void AddToCard(Product product);
    }
}

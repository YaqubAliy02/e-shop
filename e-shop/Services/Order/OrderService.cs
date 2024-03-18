//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
using e_shop.Models.Product;

namespace e_shop.Services.Order
{
    internal class OrderService
    {
        private IList<Product> lineItems;
        private IShipping shipping;

        public OrderService(IList<Product> products) => lineItems = products;

        public int GetTotal() => lineItems.Count;
        public double GetTotalWeight() => lineItems.Sum(x => x.Weight);
        public void SetShippingType(IShipping shippingType) => shipping = shippingType;

        public double GetShippingCost()
        {
            return shipping.GetCost(this);
        }
        public DateTimeOffset GetShippingDate() => DateTime.Now;


    }
}

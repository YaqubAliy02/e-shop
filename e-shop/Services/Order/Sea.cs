//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
namespace e_shop.Services.Order
{
    internal class Sea : IShipping
    {
        public double GetCost(OrderService order)
        {
            if (order.GetTotal() < 100)
            {
                return 0;
            }
            return Math.Max(15, order.GetTotalWeight() * 4);
        }
        public DateTimeOffset GetDate()
        {
            return DateTimeOffset.Now.AddDays(5);
        }
    }
}

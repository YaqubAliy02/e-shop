//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
namespace e_shop.Services.Order
{
    internal class Ground : IShipping
    {
        public double GetCost(OrderService order)
        {
            if (order.GetTotal() < 100)
            {
                return 0;
            }
            return Math.Max(10, order.GetTotalWeight() * 2);
        }
        public DateTimeOffset GetDate()
        {
            return DateTimeOffset.Now.AddDays(7);
        }
    }
}

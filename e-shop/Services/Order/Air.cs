//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
namespace e_shop.Services.Order
{
    internal class Air : IShipping
    {
        public double GetCost(OrderService order)
        {
            if (order.GetTotal() < 100)
            {
                return 0;
            }
            return Math.Max(20, order.GetTotalWeight() * 3);
        }
        public DateTimeOffset GetDate()
        {
            return DateTimeOffset.Now.AddDays(8);
        }
    }
}

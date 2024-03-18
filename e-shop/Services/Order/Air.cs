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
                return 0; // The program doesn't enter and return only zero (0) to Cost. we have to write logic there.
            }
            return Math.Max(20, order.GetTotalWeight() * 3);
        }
        public DateTimeOffset GetDate()
        {
            return DateTimeOffset.Now.AddDays(8);
        }
    }
}

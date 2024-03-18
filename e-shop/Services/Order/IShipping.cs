//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
namespace e_shop.Services.Order
{
    internal interface IShipping
    {
        double GetCost(OrderService order);

    }
}

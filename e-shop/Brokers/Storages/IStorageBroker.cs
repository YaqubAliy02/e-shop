﻿//----------------------------------------
// Tarteeb School (c) All rights reserved |
//----------------------------------------
using e_shop.Models.Auth;

namespace e_shop.Brokers.Storages
{
    internal interface IStorageBroker<T> where T : class
    {
        T Add(T credential);
        List<T> GetAll();

    }
}

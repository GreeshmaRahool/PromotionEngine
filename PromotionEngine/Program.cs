using System;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var cart = new Cart();

            cart.Add(new CartItem { Sku = "A", Value = 50.0M }, 6);
            cart.Add(new CartItem { Sku = "B", Value = 30.0M }, 3);
            cart.Add(new CartItem { Sku = "C", Value = 20.0M }, 2);
            cart.Add(new CartItem { Sku = "D", Value = 15.0M }, 3);
        }
    }
}

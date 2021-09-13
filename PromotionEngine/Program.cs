using System;
using System.Collections.Generic;

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
            var promotion = new Promotions()
            {
                Rules = new List<IRule>() {
                    new DiscountSkuCount("A", 3, 20),
                    new CombinationDiscount() {
                        ComboSku = new Tuple<string,string>("C","D"),
                        ComboDiscountPrice = 30.0M
                    }
                }
            };

            var totalDiscount = promotion.ApplyPromotions(cart);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--------");
            Console.WriteLine("Your cart total is: " + cart.CartTotal);
            Console.WriteLine("Your discounts are: " + totalDiscount);
            Console.WriteLine("Final Prices is: " + (cart.CartTotal - totalDiscount));
        }
    }
}

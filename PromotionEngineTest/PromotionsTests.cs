using NUnit.Framework;
using PromotionEngine;
using System;

namespace PromotionEngineTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CountDiscount()
        {
            Cart cart = new Cart();
            cart.Add(new CartItem { Sku = "A", Value = 50.0M }, 6);

            var discount = new DiscountSkuCount("A", 3, 20);
            var discountAmount = discount.ProcessDiscount(cart);

            Assert.True(discountAmount == 40.0M);
        }

        [Test]
        public void ComboDiscount()
        {
            Cart cart = new Cart();
            cart.Add(new CartItem { Sku = "C", Value = 20.0M }, 2);
            cart.Add(new CartItem { Sku = "D", Value = 15.0M }, 3);

            var discount = new CombinationDiscount()
            {
                ComboSku = new Tuple<string, string>("C", "D"),
                ComboDiscountPrice = 30.0M
            };

            var discountAmount = discount.ProcessDiscount(cart);
            Assert.True(discountAmount == 10.0M);
        }
    }
}
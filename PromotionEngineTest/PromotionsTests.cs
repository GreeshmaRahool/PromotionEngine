using NUnit.Framework;
using PromotionEngine;
using System;
using System.Collections.Generic;

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

        [Test]
        public void TotalDiscount()
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
            Assert.True(totalDiscount == 50.0M);
        }
    }
}
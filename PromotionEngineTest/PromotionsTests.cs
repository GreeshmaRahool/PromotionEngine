using NUnit.Framework;
using PromotionEngine;

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
    }
}
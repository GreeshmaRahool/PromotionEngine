using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public interface IRule
    {
        decimal ProcessDiscount(Cart cart);
    }

    public class DiscountSkuCount : IRule
    {

        string Sku;
        int Count;
        int Discount;

        public DiscountSkuCount(string sku, int count, int discount)
        {
            this.Sku = sku;
            this.Count = count;
            this.Discount = discount;
        }

        public decimal ProcessDiscount(Cart cart)
        {
            var skuItems = cart.FilterSku(this.Sku);
            if (skuItems.Count >= this.Count)
            {
                decimal discount = (skuItems.Count / this.Count) * this.Discount;
                // DEBUG:
                Console.WriteLine("SKU " + this.Sku + " discount " + discount);
                return discount;
            }
            return 0;
        }
    }

}

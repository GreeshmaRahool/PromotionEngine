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
    public class CombinationDiscount : IRule
    {

        public Tuple<string, string> ComboSku { get; set; }
        public decimal ComboDiscountPrice = 0;

        public decimal ProcessDiscount(Cart cart)
        {
            var sku1 = cart.FilterSku(this.ComboSku.Item1);
            var sku2 = cart.FilterSku(this.ComboSku.Item2);

            if (sku1.Count >= 1 && sku2.Count >= 1)
            {
                int comboCount = Math.Min(sku1.Count, sku2.Count);
                decimal discount = (sku1.First().Value + sku2.First().Value - ComboDiscountPrice) * comboCount;

                // DEBUG:
                Console.WriteLine("Offer Count is " + discount);
                return discount;
            }
            else
            {
                // DEBUG:
                Console.WriteLine("Coudldn't find any combos of " + ComboSku.Item1 + " and " + ComboSku.Item2);
            }
            return 0M;
        }
    }
}

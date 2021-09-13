using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class Promotions
    {
        public List<IRule> Rules { get; set; }
        public decimal ApplyPromotions(Cart cart)
        {
            decimal totalDiscount = Rules.Sum(rule => rule.ProcessDiscount(cart));
            Console.WriteLine("Total Discount is: " + totalDiscount);
            return totalDiscount;
        }
    }
}

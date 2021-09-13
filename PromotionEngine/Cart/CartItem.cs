using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class CartItem
    {
        public string Sku { get; set; }
        public double Value { get; set; }

        public override string ToString()
        {
            return "SKU: " + Sku + " " + "Value: " + Value;
        }
    }
}

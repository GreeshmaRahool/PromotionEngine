using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Cart
{
    public class Cart
    {
        List<CartItem> Items = new List<CartItem>();

        public void Add(CartItem item, int count = 1)
        {
            for (int i = 0; i < count; i++)
            {
                Items.Add(item);
            }
        }

        public void Clear()
        {
            Items.Clear();
        }

        public override string ToString()
        {
            Dictionary<string, int> summary = new Dictionary<string, int>();

            foreach (var item in Items)
            {
                int value = 0;
                if (summary.TryGetValue(item.Sku, out value))
                {
                    value++;
                }
                summary.Add(item.Sku, value);
            }

            string ret = "Your Cart\n";
            foreach (var sku in summary)
            {
                ret += "SKU: " + sku.Key + " - " + sku.Value;
            }

            ret += "Total Items: " + summary.Keys.Count;
            return ret;
        }

        public List<CartItem> FilterSku(string Sku)
        {
            IEnumerable<CartItem> query = Items.Where(item => item.Sku == Sku);
            return query.ToList();
        }

        public double CartTotal
        {
            get
            {
                return Items.Sum(item => item.Value);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Supermarket
{
    public class PriceRule
    {
        public char Item { get; set; }
        public double Price { get; set; }

        public int? DiscountAmont { get; set; }
        public double? DiscountPrice { get; set; }
        public PriceRule(char item, double price, int? discountAmont=null, double? discountPrice=null)
        {
            Item = item;
            Price = price;
            DiscountAmont = discountAmont;
            DiscountPrice = discountPrice;
        }
    }
}

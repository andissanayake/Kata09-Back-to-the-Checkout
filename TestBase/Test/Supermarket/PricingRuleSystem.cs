using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Supermarket
{
    public interface IPricingSystem
    {
        void AddProduct(char product);
        double GetTotal();
        void Clean();
    }
    public abstract class BasePricingSystem : IPricingSystem
    {
        protected readonly List<PriceRule> _priceRules;

        public  BasePricingSystem(List<PriceRule> priceRules)
        {
            _priceRules = priceRules;
        }

        public abstract void AddProduct(char product);

        public abstract void Clean();

        public abstract double GetTotal();
    }

    public class SimplePricingSystem : BasePricingSystem
    {
        private readonly List<char> products;
        public SimplePricingSystem(List<PriceRule> priceRules) : base(priceRules)
        {
            products = new List<char>();
        }

        public override void AddProduct(char product)
        {
            products.Add(product);
        }

        public override void Clean()
        {
            products?.Clear();
        }

        public override double GetTotal()
        {
            var productGroup = products.GroupBy(p => p).Select(pg => new { product = pg.Key, count = pg.Count() });
            return
                (from p in productGroup
                 join pl in _priceRules
                 on p.product equals pl.Item
                 select p.count * pl.Price).Sum();
        }
    }
    public class BuyMorePricingSystem: BasePricingSystem
    {
        private readonly List<char> products;
        public BuyMorePricingSystem(List<PriceRule> priceRules) : base(priceRules) {
            products = new List<char>();
        }

        public override void AddProduct(char product)
        {
            products.Add(product);
        }

        public override void Clean()
        {
            products?.Clear();
        }

        public override double GetTotal()
        {
            var productGroup = products.GroupBy(p => p).Select(pg => new { product = pg.Key, count = pg.Count() });
            return
                (from p in productGroup
                 join pl in _priceRules
                 on p.product equals pl.Item
                 select p.count * pl.Price).Sum();
        }

        private double GetPrice(int count,PriceRule priceRule)
        {
            if(priceRule.DiscountAmont != null && priceRule.DiscountAmont != null)
            {
                return ((count % priceRule.DiscountAmont * priceRule.Price) +
                    (count / priceRule.DiscountAmont * priceRule.Price)) ?? 0;
            }
            else
            {
                return count * priceRule.Price;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Supermarket
{
    public class Checkout
    {
        private readonly IPricingSystem _pricingSystem;
        public Checkout(string pricingSystem, List<PriceRule> priceRules)
        {
            _pricingSystem = Get(pricingSystem, priceRules);
        }
        public IPricingSystem Get(string pricingSystem,List<PriceRule> priceRules)
        {
           switch (pricingSystem)
            {
                case "BuyMorePricingSystem":
                    return new BuyMorePricingSystem(priceRules);
                case "SimplePricingSystem":
                    return new SimplePricingSystem(priceRules);
                default:
                    throw new ArgumentException("no pricing system");
            }
        }
        public void Scan(string products)
        {
            foreach(var c in products.ToCharArray())
            {
                _pricingSystem.AddProduct(c);
            }
            Console.WriteLine(_pricingSystem.GetTotal());
        }
        public double GetTotal()
        {
            return _pricingSystem.GetTotal();
        }
        public void Clean()
        {
            _pricingSystem.Clean();
        }
    }
}

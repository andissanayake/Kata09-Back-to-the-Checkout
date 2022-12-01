using Test.Supermarket;

var priceRules = new List<PriceRule>() {new PriceRule('A',50,3,50),new PriceRule('B',30,2,45), new PriceRule('C', 20), new PriceRule('D', 15) };
var checkout = new Checkout("BuyMorePricingSystem", priceRules);

checkout.Scan("");
checkout.Scan("A");
checkout.Scan("AB");
checkout.Scan("CDBA");
Console.ReadKey();



using System.Collections.Generic;
using Test.Supermarket;
using Xunit;

namespace Tester
{
    public class UnitTest
    {
        Checkout checkout;
        public UnitTest()
        {
            var priceRules = new List<PriceRule>() { new PriceRule('A', 50, 3, 50), new PriceRule('B', 30, 2, 45), new PriceRule('C', 20), new PriceRule('D', 15) };
            checkout = new Checkout("BuyMorePricingSystem", priceRules);

        }

        [Fact]
        public void Empty()
        {
            checkout.Clean();
            checkout.Scan("");
            checkout.GetTotal().Equals(0);
        }
        [Fact]
        public void A()
        {
            checkout.Clean();
            checkout.Scan("A");
            checkout.GetTotal().Equals(50);
        }

        [Fact]
        public void AB()
        {
            checkout.Clean();
            checkout.Scan("AB");
            checkout.GetTotal().Equals(80);
        }

        [Fact]
        public void CDBA()
        {
            checkout.Clean();
            checkout.Scan("CDBA");
            checkout.GetTotal().Equals(115);
        }


        [Fact]
        public void AA()
        {
            checkout.Clean();
            checkout.Scan("AA");
            checkout.GetTotal().Equals(100);
        }

        [Fact]
        public void AAA()
        {
            checkout.Clean();
            checkout.Scan("AAA");
            checkout.GetTotal().Equals(130);
        }

        [Fact]
        public void AAAA()
        {
            checkout.Clean();
            checkout.Scan("AAAA");
            checkout.GetTotal().Equals(180);
        }

        [Fact]
        public void AAAAA()
        {
            checkout.Clean();
            checkout.Scan("AAAAA");
            checkout.GetTotal().Equals(230);
        }

        [Fact]
        public void AAAAAA()
        {
            checkout.Clean();
            checkout.Scan("AAAAAA");
            checkout.GetTotal().Equals(260);
        }

        [Fact]
        public void AAAB()
        {
            checkout.Clean();
            checkout.Scan("AAAB");
            checkout.GetTotal().Equals(160);
        }

        [Fact]
        public void AAABB()
        {
            checkout.Clean();
            checkout.Scan("AAABB");
            checkout.GetTotal().Equals(175);
        }

        [Fact]
        public void AAABBD()
        {
            checkout.Clean();
            checkout.Scan("AAABBD");
            checkout.GetTotal().Equals(190);
        }

        [Fact]
        public void DABABA()
        {
            checkout.Clean();
            checkout.Scan("DABABA");
            checkout.GetTotal().Equals(190);
        }

        [Fact]
        public void TestIncremental()
        {
            checkout.Clean();
            checkout.Scan("A");
            checkout.GetTotal().Equals(50);
            checkout.Scan("B");
            checkout.GetTotal().Equals(80);
            checkout.Scan("A");
            checkout.GetTotal().Equals(130);
            checkout.Scan("A");
            checkout.GetTotal().Equals(160);
            checkout.Scan("B");
            checkout.GetTotal().Equals(175);
        }
    }
}
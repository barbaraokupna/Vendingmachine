using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
namespace VendingMachineUnitTest
{
    [TestClass]
    public class CoffeTests
    {
        [TestMethod]
        public void TestMethodDefault()
        {
            // nothing set 
            IBeverage coffee = new Coffee();
            double expectedCost = 1.75;
            string expectedDesc = "Coffee";
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - all default");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - all default");
        }

        [TestMethod]
        public void TestMethodSize()
        {
            // nothing set 
            IBeverage coffee = new Coffee();
            coffee.Size = SIZE_ENUM.SMALL;

            double expectedCost = 1.75;
            string expectedDesc = "Coffee";
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - size");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - size");


            coffee.Size = SIZE_ENUM.MEDIUM;
            expectedCost = 2.00;
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - size");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - size");



            coffee.Size = SIZE_ENUM.LARGE;
            expectedCost = 2.25;
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - size");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - size");

        }


        [TestMethod]
        public void TestMethodCream()
        {
            // nothing set 
            IBeverage coffee = new Coffee();
            coffee.Size = SIZE_ENUM.SMALL;
            coffee.AddExtra(new Cream());

            double expectedCost = 1.75 + 0.50;
            string expectedDesc = "Coffee, Cream";
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - size + cream");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - size + cream");


            coffee.Size = SIZE_ENUM.MEDIUM;
            expectedCost = 2.00 + 0.50;
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - size + cream");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - size + cream");



            coffee.Size = SIZE_ENUM.LARGE;
            expectedCost = 2.25 + 0.50;
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - size + cream");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - size + cream");

        }
        [TestMethod]
        public void TestMethodSugar()
        {
            // nothing set 
            IBeverage coffee = new Coffee();
            coffee.Size = SIZE_ENUM.SMALL;
            coffee.AddExtra(new Sugar());

            double expectedCost = 1.75 + 0.25;
            string expectedDesc = "Coffee, Sugar";
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - size + sugar");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - size + sugar");

            coffee.Size = SIZE_ENUM.MEDIUM;
            expectedCost = 2.00 + 0.25;
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - size + sugar");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - size + sugar");

            coffee.Size = SIZE_ENUM.LARGE;
            expectedCost = 2.25 + 0.25;
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - size + sugar");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - size + sugar");

        }
        [TestMethod]
        public void TestMethodSugarCream()
        {
            // nothing set 
            IBeverage coffee = new Coffee();
            coffee.Size = SIZE_ENUM.SMALL;
            coffee.AddExtra(new Sugar());
            coffee.AddExtra(new Cream());

            double expectedCost = 1.75 + 0.25 + .50;
            string expectedDesc = "Coffee, Sugar, Cream";
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - size + sugar cream");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - size + sugar cream");

            coffee.Size = SIZE_ENUM.MEDIUM;
            expectedCost = 2.00 + 0.25 + .50;
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - size + sugar cream");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - size + sugar cream");

            coffee.Size = SIZE_ENUM.LARGE;
            expectedCost = 2.25 + 0.25 + .50;
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - size + sugar cream");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - size + cream");

        }
        [TestMethod]
        public void TestMethodSugarCreamMax()
        {
            // nothing set 
            IBeverage coffee = new Coffee();
            coffee.Size = SIZE_ENUM.SMALL;
            coffee.AddExtra(new Sugar());
            coffee.AddExtra(new Cream());
            coffee.AddExtra(new Sugar());
            coffee.AddExtra(new Cream());
            coffee.AddExtra(new Cream());
            coffee.AddExtra(new Sugar());


            double expectedCost = 1.75 + 3 * 0.25 + 3 * .50;
            string expectedDesc = "Coffee, Sugar, Cream, Sugar, Cream, Cream, Sugar";
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - size + sugar cream");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - size + sugar cream");

            coffee.Size = SIZE_ENUM.MEDIUM;
            expectedCost = 2.00 + 3 * 0.25 + 3 * .50;
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - size + sugar cream");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - size + sugar cream");

            coffee.Size = SIZE_ENUM.LARGE;
            expectedCost = 2.25 + 3 * 0.25 + 3 * .50;
            Assert.AreEqual(expectedCost, coffee.TotalCost, "Coffee:cost - size + sugar cream");
            Assert.AreEqual(expectedDesc, coffee.BevDescription, "Coffee:desc - size + cream");

        }
    }
}

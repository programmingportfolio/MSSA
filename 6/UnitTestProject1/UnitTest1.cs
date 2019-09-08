using BisectionAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var random = new Random();
            string number = "0";
            number.ShouldBe(Test.Index(random, 1));
        }

        [TestMethod]
        public void TestMethod2()
        {
            var random = new Random();
            string number = "10";
            number.ShouldBe(Test.Index2(random, 10));
        }

        [TestMethod]
        public void TestMethod3()
        {
            var random = new Random();
            string number = "01";
            number.ShouldBe(Test.Index(random, 1));
        }

        [TestMethod]
        public void TestMethod4()
        {
            var random = new Random();
                string number = "910";
            number.ShouldBe(Test.Index2(random, 9));
        }
    }
}

using System;
using Calc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestSum()
        {
            var calc = new Calculator();
            var result = calc.Sum(2, 3);
            Assert.IsTrue(result == 5);
        }

        public void TestDivide()
        {
            var calc = new Calculator();
            
            Assert.IsTrue(calc.Divide(6, 2) == 3);
            Assert.IsNull(calc.Divide(6, 0));
        }
    }
}

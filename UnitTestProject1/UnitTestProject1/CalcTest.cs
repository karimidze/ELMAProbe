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
        [TestMethod]
        public void TestDivide()
        {
            var calc = new Calculator();
            Assert.IsTrue(calc.Divide(6, 2) == 3);
            Assert.IsNull(calc.Divide(6, 0));
        }

        [TestMethod]
        public void TestSubtr()
        {
            var calc = new Calculator();
            var result = calc.Subtr(2, 3);
            Assert.IsTrue(result == -1);
        }

        [TestMethod]
        public void TestMult()
        {
            var calc = new Calculator();
            var result = calc.Mult(744, 2);
            Assert.IsTrue(result == 1488);
        }

        [TestMethod]
        public void TestExp()
        {
            var calc = new Calculator();
            var result = calc.Exp(3, 3);
            Assert.IsTrue(result == 27);
        }

        [TestMethod]
        public void TestFact()
        {
            var calc = new Calculator();
            var result = calc.Fact(3);
            Assert.IsTrue(result == 6);
        }

        [TestMethod]
        public void TestSqrt()
        {
            var calc = new Calculator();
            var result = calc.Sqrt(9);
            Assert.IsTrue(result == 3);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalcLib;

namespace MyClassTest
{
    [TestClass]
    public class MyCalcTest
    {
        [TestMethod]
        public void TestSumm()
        {
            //arrange
            int x = 10;
            int y = 20;
            int exepted = 30;

            //act
            main c = new main();
            int actual = c.Summ(x, y);

            Assert.AreEqual(exepted, actual);
        }

        [TestMethod]
        public void TestDel()
        {
            //arrange
            int x = 20;
            int y = 10;
            int exepted = 2;

            //act
            main c = new main();
            int actual = c.del(x, y);

            Assert.AreEqual(exepted, actual);
        }

        [TestMethod]
        public void TestMinus()
        {
            //arrange
            int x = 20;
            int y = 10;
            int exepted = 10;

            //act
            main c = new main();
            int actual = c.minus(x, y);

            Assert.AreEqual(exepted, actual);
        }

        [TestMethod]
        public void TestMultiply()
        {
            //arrange
            int x = 10;
            int y = 10;
            int exepted = 100;

            //act
            main c = new main();
            int actual = c.multi(x, y);

            Assert.AreEqual(exepted, actual);
        }

        [TestMethod]
        public void TestSqr()
        {
            //arrange
            int x = 4;
            int exepted = 2;

            //act
            main c = new main();
            int actual = c.sqr(x);

            Assert.AreEqual(exepted, actual);
        }

        [TestMethod]
        public void TestXTwo()
        {
            //arrange
            int x = 2;
            int exepted = 4;

            //act
            main c = new main();
            int actual = c.xtwo(x);

            Assert.AreEqual(exepted, actual);
        }
    }
}

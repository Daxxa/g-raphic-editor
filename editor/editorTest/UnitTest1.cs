using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using editor;
using System.Drawing;
namespace editorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Form1 m = new Form1();
            Color expectedColor = Color.Black;   
            Color actualColor = m.getColor();   
            Assert.AreEqual(expectedColor,actualColor);
            Color expectedBack = Color.White;
            Color actualBack = m.getColorGround();
            Assert.AreEqual(expectedBack, actualBack);
            bool expectedresult = true;
            bool actualresult = m.getResult();
            Assert.AreEqual(expectedresult, actualresult);
            int expectedx = 500;
            int expectedy= 250;
            int[] actual = m.getResult1();
            Assert.AreEqual(expectedx, actual[0]);
            Assert.AreEqual(expectedy, actual[1]);
        }
    }
}

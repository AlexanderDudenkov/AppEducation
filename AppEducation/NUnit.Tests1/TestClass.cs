using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Throws<Exception>(() => { throw new Exception(); });
            Assert.Pass("Your first passing test");
        }
        
        [TestCase("string 1", "1")]
        [TestCase("string 2", "2")]
        [TestCase("string 3", "3")]
        [TestCase("string 4", "4")]
        public void TestString(string data, string exp)
        {
            object
            var actString = data.Split(' ')[1];

            Assert.AreEqual(exp, actString);
        }
    }
}

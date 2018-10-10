using AppEducation;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.Tests1
{
    [TestFixture]
    public class TestClass
    {
        private ICollect<int> subject;

        [SetUp]
        public void BeforeTestSuit()
        {
            subject = new Mock<ICollect<int>>(MockBehavior.Strict).Object;
        }

        [Test]
        public void AddItemToCollection()
        {
            subject.Add(1);
            subject.Add(5);
            subject.Add(int.MinValue);
            subject.Add(int.MaxValue);

            var collectAct = new List<int>();
            collectAct.Add(subject.GetItem(0));
            collectAct.Add(subject.GetItem(2));
            collectAct.Add(subject.GetItem(int.MinValue));
            collectAct.Add(subject.GetItem(int.MaxValue));

            CollectionAssert.AreEquivalent(new List<int> { 1, 2, int.MinValue, int.MaxValue }, collectAct);
        }

        [TestCase(int.MaxValue, int.MaxValue)]
        [TestCase(int.MinValue, int.MinValue)]
        [TestCase(1, 5)]
        [TestCase(0, 1)]
        public void GetItemFromCollection(int index, int exp)
        {
            subject.SetItem(index, exp);
            var item = subject.GetItem(index);
            Assert.AreEqual(exp, item);
        }

        [TestCase(int.MaxValue, int.MaxValue)]
        [TestCase(int.MinValue, int.MinValue)]
        [TestCase(1, 5)]
        [TestCase(0, 1)]
        public void DeleteItemFromCollection(int index, int exp)
        {
            subject.SetItem(index, exp);
            Assert.IsTrue(subject.Del(exp));
        }

        [TestCase(int.MaxValue, int.MaxValue)]
        [TestCase(int.MinValue, int.MinValue)]
        [TestCase(1, 5)]
        [TestCase(0, 1)]
        public void SetItemToCollection(int index, int exp)
        {
            Assert.IsTrue(subject.SetItem(index, exp));
        }


        [Test]
        public void ReverseItemsInCollection()
        {
            subject.SetItem(0, 1);
            subject.SetItem(1, 5);
            subject.SetItem(int.MinValue, int.MinValue);
            subject.SetItem(int.MaxValue, int.MaxValue);

            subject.Reverse();

            var collectExp = new List<int>();
            collectExp.Insert(0, int.MaxValue);
            collectExp.Insert(1, int.MinValue);
            collectExp.Insert(int.MinValue, 5);
            collectExp.Insert(int.MaxValue, 1);

            var collectTemp = new List<int>();
            collectTemp.Insert(0, subject.GetItem(0));
            collectTemp.Insert(1, subject.GetItem(1));
            collectTemp.Insert(int.MinValue, subject.GetItem(int.MinValue));
            collectTemp.Insert(int.MaxValue, subject.GetItem(int.MaxValue));

            CollectionAssert.AreEqual(collectExp, collectTemp);
        }
    }
}

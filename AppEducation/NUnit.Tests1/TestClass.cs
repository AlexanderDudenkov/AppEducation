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


        // TODO: Add tests for Add(..) for 1, 2, 3 cases
        [Test]
        public void Add_1_ItemToCollection()
        {
            subject.Add(1);

            var collectAct = new List<int>();
            collectAct.Add(subject.GetItem(0));

            CollectionAssert.AreEquivalent(new List<int> { 1 }, collectAct);
        }

        [Test]
        public void Add_2_ItemsToCollection()
        {
            subject.Add(1);
            subject.Add(10);

            var collectAct = new List<int>();
            collectAct.Add(subject.GetItem(0));
            collectAct.Add(subject.GetItem(1));

            CollectionAssert.AreEquivalent(new List<int> { 1, 10 }, collectAct);
        }

        [Test]
        public void Add_3_ItemsToCollection()
        {
            subject.Add(1);
            subject.Add(10);
            subject.Add(1000);

            var collectAct = new List<int>();
            collectAct.Add(subject.GetItem(0));
            collectAct.Add(subject.GetItem(1));
            collectAct.Add(subject.GetItem(2));

            CollectionAssert.AreEquivalent(new List<int> { 1, 10, 1000 }, collectAct);
        }

        [Test]
        public void Add_4_ItemsToCollection()
        {
            subject.Add(1);
            subject.Add(5);
            subject.Add(int.MinValue);
            subject.Add(int.MaxValue);

            var collectAct = new List<int>();
            collectAct.Add(subject.GetItem(0));
            collectAct.Add(subject.GetItem(2));
            collectAct.Add(subject.GetItem(1));
            collectAct.Add(subject.GetItem(3));

            CollectionAssert.AreEquivalent(new List<int> { 1, 5, int.MinValue, int.MaxValue }, collectAct);
        }

        [TestCase(3, int.MaxValue)]
        [TestCase(2, int.MinValue)]
        [TestCase(1, 5)]
        [TestCase(0, 1)]
        public void GetItemFromCollection(int index, int exp)
        {
            subject.Add(exp);
            subject.Add(exp);
            subject.Add(exp);
            subject.Add(exp);

            var item = subject.GetItem(index);
            Assert.AreEqual(exp, item);
        }

        [Test]
        public void GetItemFromCollectionIfIndexNotExist()
        {
            subject.Add(0);
            subject.Add(10);
            subject.Add(1000);

            var item = subject.GetItem(3);
            Assert.IsNull(item);
        }

        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        [TestCase(5)]
        [TestCase(1)]
        public void DeleteItemFromCollection(int exp)
        {
            subject.Add(exp);
            Assert.IsTrue(subject.Del(exp));
        }

        // TODO: Del for false

        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        [TestCase(5)]
        [TestCase(1)]
        public void DeleteItemFromCollectionIfItemNotExist(int exp)
        {
            subject.Add(0);
            Assert.IsFalse(subject.Del(exp));
        }

        [TestCase(1, 1000)]
        [TestCase(1, 100)]
        [TestCase(0, 1)]
        public void SetItemToCollection(int index, int exp)
        {
            subject.Add(0);
            subject.Add(0);
            subject.Add(0);

            Assert.IsTrue(subject.SetItem(index, exp));
        }

        //  TODO: For false
        [TestCase(10, 1000)]
        [TestCase(-1, 100)]
        [TestCase(3, 1)]
        public void SetItemToCollectionIfIndexNotExist(int index, int exp)
        {
            subject.Add(0);
            subject.Add(0);
            subject.Add(0);

            Assert.IsFalse(subject.SetItem(index, exp));
        }


        // TODO: Need tast cases for 0, 1, 3 and more items count
        [Test]
        public void ReverseItemsInEmptyCollection()
        {
            subject.Reverse();

            var collectExp = new List<int>();

            var collectTemp = new List<int>();
            collectTemp.Add(subject.GetItem(0));

            CollectionAssert.AreEqual(collectExp, collectTemp);
        }

        [Test]
        public void Reverse_1_ItemInCollection()
        {
            subject.Add(1);

            subject.Reverse();

            var collectExp = new List<int>();
            collectExp.Add(1);

            var collectTemp = new List<int>();
            collectTemp.Add(subject.GetItem(0));

            CollectionAssert.AreEqual(collectExp, collectTemp);
        }

        [Test]
        public void Reverse_2_ItemsInCollection()
        {
            subject.Add(1);
            subject.Add(5);

            subject.Reverse();

            var collectExp = new List<int>();
            collectExp.Add(5);
            collectExp.Add(1);

            var collectTemp = new List<int>();
            collectTemp.Add(subject.GetItem(0));
            collectTemp.Add(subject.GetItem(1));

            CollectionAssert.AreEqual(collectExp, collectTemp);
        }

        [Test]
        public void Reverse_3_ItemsInCollection()
        {
            subject.Add(1);
            subject.Add(5);
            subject.Add(10);

            subject.Reverse();

            var collectExp = new List<int>();
            collectExp.Add(10);
            collectExp.Add(5);
            collectExp.Add(1);

            var collectTemp = new List<int>();
            collectTemp.Add(subject.GetItem(0));
            collectTemp.Add(subject.GetItem(1));
            collectTemp.Add(subject.GetItem(2));

            CollectionAssert.AreEqual(collectExp, collectTemp);
        }

        [Test]
        public void Reverse_4_ItemsInCollection()
        {
            subject.Add(1);
            subject.Add(5);
            subject.Add(int.MinValue);
            subject.Add(int.MaxValue);

            subject.Reverse();

            var collectExp = new List<int>();
            collectExp.Add(int.MaxValue);
            collectExp.Add(int.MinValue);
            collectExp.Add(5);
            collectExp.Add(1);

            var collectTemp = new List<int>();
            collectTemp.Add(subject.GetItem(0));
            collectTemp.Add(subject.GetItem(1));
            collectTemp.Add(subject.GetItem(2));
            collectTemp.Add(subject.GetItem(3));

            CollectionAssert.AreEqual(collectExp, collectTemp);
        }


    }
}

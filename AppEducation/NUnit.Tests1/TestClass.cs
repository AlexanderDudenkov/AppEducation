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
            //subject = new Mock<ICollect<int>>(MockBehavior.Strict).Object;
            subject = new CollectInt();
        }

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
            collectAct.Add(subject.GetItem(2));
            collectAct.Add(subject.GetItem(1));
            collectAct.Add(subject.GetItem(0));

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

        [TestCase(3, int.MaxValue, 5)]
        [TestCase(2, int.MinValue, 6)]
        [TestCase(1, 5, 2)]
        [TestCase(0, 1, 2)]
        public void GetItemFromCollection(int index, int exp, int count)
        {
            var item = CreateCollect(subject, index, exp, count).GetItem(index);
            Assert.AreEqual(exp, item);
        }

        private ICollect<int> CreateCollect(ICollect<int> collect, int index, int exp, int count)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < count; i++)
            {
                if (i == index)
                {
                    collect.Add(exp);
                }
                else
                {
                    collect.Add(rnd.Next(int.MaxValue));
                }
            }
            return collect;
        }

        [Test]
        public void GetItemFromCollectionIfIndexNotExist()
        {
            subject.Add(0);
            subject.Add(10);
            subject.Add(1000);

            Assert.Throws<ArgumentOutOfRangeException>(() => subject.GetItem(3));

        }

        [TestCase(0, int.MaxValue, 2)]
        [TestCase(10, int.MinValue, 30)]
        [TestCase(5, 20, 10)]
        [TestCase(1, 10, 2)]
        public void DeleteItemFromCollection(int index, int exp, int coun)
        {
            Assert.IsTrue(CreateCollect(subject, index, exp, coun).Del(exp));
            //Assert.AreNotEqual(exp, subject.GetItem(index));
        }


        public void DeleteItemFromCollectionIfItemNotExist()
        {
            CreateCollect(subject, 2, 5, 5).Del(6);
            Assert.Throws<ArgumentOutOfRangeException>(() => { throw new Exception(); });
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
            Assert.AreEqual(exp, subject.GetItem(index));
        }


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

        [Test]
        public void ReverseItemsInEmptyCollection()
        {
            var expColl = subject.Reverse();
            Assert.AreEqual(subject, expColl);
            Assert.DoesNotThrow(() => subject.Reverse());
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

        [TearDown]
        public void Aftertestsuit()
        {
            subject = null;
        }
    }
}

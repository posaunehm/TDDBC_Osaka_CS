using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TDDBCOsaka;

namespace TDDOsakaTest
{
    [TestFixture]
    public class VendingMachineTest
    {
        VendorMachine venderMachine = null;

        [SetUp]
        public void VenderMachineSetup()
        {
            venderMachine = new VendorMachine();
        }


        [Test]
        public void お金を投入して金額を確認する()
        {
            var insertedList = new List<Money>{ 
                new Money(1000), new Money(500), new Money(100),new Money(50), new Money(10)};

            insertedList.ForEach(_ => venderMachine.InsertMoney(_));

            Assert.AreEqual(1660, venderMachine.Money);
        }

        [Test]
        public void お金を投入_複数回_を確認()
        {
            var insertedList = new List<Money>{ 
                new Money(1000), new Money(100), new Money(10)};
            var insertedList2 = new List<Money>{ 
                new Money(500),new Money(50)};
            insertedList.ForEach(_ => venderMachine.InsertMoney(_));
            insertedList2.ForEach(_ => venderMachine.InsertMoney(_));

            Assert.AreEqual(1660, venderMachine.Money);
        }

        [TestCase(10000)]
        [TestCase(5000)]
        [TestCase(5)]
        [TestCase(1)]
        public void お金を入れる_異常系(int input)
        {
            var insertedMoney = new Money(input);
            
            Assert.Throws(typeof(ArgumentException),
                () => venderMachine.InsertMoney(insertedMoney));

        }



        [TestCase(1000,true)]
        [TestCase(500,true)]
        [TestCase(100,false)]
        [TestCase(50,false)]
        [TestCase(10,false)]
        public void お金を入れる_正常系(int input, bool expected)
        {
            var insertedMoney = new Money(input);

            bool ret = venderMachine.InsertMoney(insertedMoney);

            Assert.AreEqual(expected, ret);
            Assert.AreEqual(input, venderMachine.Money);
        }

        [Test]
        public void コーラが買えるかどうかのテスト_複数お金を入れた時()
        {
            var insertedMoney =new List<Money>{new Money(10),new Money(10),new Money(100)};

            var ret = insertedMoney.Select(_ => venderMachine.InsertMoney(_)).ToList();

            Assert.AreEqual(true, ret.Last());
        }

        [Test]
        public void 払い戻しの確認()
        {
            var insertedMoney = new Money(100);

            venderMachine.InsertMoney(insertedMoney);

            int ret = venderMachine.PayBack();

            Assert.AreEqual(0, venderMachine.Money);
            Assert.AreEqual(100, ret);

        }

        [Test]
        public void ジュースの在庫確認()
        {
            JuiceStock ret = venderMachine.JuiceStock;

            Assert.AreEqual(ret.Name, "コーラ");
            Assert.AreEqual(ret.Price, 120);
            Assert.AreEqual(ret.Stock, 5);
        }


        [Test]
        public void 購入操作の確認()
        {
            venderMachine.InsertMoney(new Money(1000));

            Tuple<Juice, int> ret = venderMachine.Buy();

            Assert.AreEqual("コーラ", ret.Item1.Name);
            Assert.AreEqual(880, ret.Item2);
            Assert.AreEqual(0, venderMachine.Money);
            Assert.AreEqual(4, venderMachine.JuiceStock.Stock);
            Assert.AreEqual(120, venderMachine.Earning);
        }

        [Test]
        public void 在庫切れの確認()
        {
            for (int i = 0; i < 5; i++)
            {
                venderMachine.InsertMoney(new Money(1000));
                venderMachine.Buy();
            }

            var ret1 = venderMachine.InsertMoney(new Money(1000));
            var ret2 = venderMachine.Buy();

            Assert.AreEqual(false, ret1);
            Assert.AreEqual(null, ret2.Item1);
            Assert.AreEqual(1000, ret2.Item2);

        }
    }
}

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
        [Test]
        public void お金を投入して金額を確認する()
        {
            var venderMachine = new VendorMachine();
            var insertedList = new List<Money>{ 
                new Money(1000), new Money(500), new Money(100),new Money(50), new Money(10)};

            insertedList.ForEach(_ => venderMachine.InsertMoney(_));

            Assert.AreEqual(1660, venderMachine.Money);
        }

        [Test]
        public void お金を投入_複数回_を確認()
        {
            var venderMachine = new VendorMachine();
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
            var venderMachine = new VendorMachine();
            var insertedMoney = new Money(input);

            int ret = venderMachine.InsertMoney(insertedMoney);

            Assert.AreEqual(input, ret);
            Assert.AreEqual(0, venderMachine.Money);
        }



        [TestCase(1000,0)]
        [TestCase(500,0)]
        [TestCase(100,0)]
        [TestCase(50,0)]
        [TestCase(10,0)]
        public void お金を入れる_正常系(int input, int expected)
        {
            var venderMachine = new VendorMachine();
            var insertedMoney = new Money(input);

            int ret = venderMachine.InsertMoney(insertedMoney);

            Assert.AreEqual(expected, ret);
            Assert.AreEqual(input, venderMachine.Money);
        }


    }
}

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

        [Test]
        public void お金を入れる10000円()
        {
            var venerMachine = new VendorMachine();
            var insertedMoney = new Money(10000);


            int ret = venerMachine.InsertMoney(insertedMoney);

            Assert.AreEqual(10000, ret);
        }
    }
}

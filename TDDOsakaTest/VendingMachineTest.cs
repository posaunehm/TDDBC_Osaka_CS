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
            venderMachine.InsertMoney(insertedList);

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
            venderMachine.InsertMoney(insertedList);
            venderMachine.InsertMoney(insertedList2);

            Assert.AreEqual(1660, venderMachine.Money);
        }
    }
}

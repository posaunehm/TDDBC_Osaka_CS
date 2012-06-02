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
            venderMachine.InsertMoney(1, 1, 1, 1, 1);

            Assert.AreEqual(1660, venderMachine.Money);
        }

        [Test]
        public void お金を投入_複数回_を確認()
        {
            var venderMachine = new VendorMachine();
            venderMachine.InsertMoney(1, 0, 1, 0, 1);
            venderMachine.InsertMoney(0, 1, 0, 1, 0);

            Assert.AreEqual(1660, venderMachine.Money);
        }
    }
}

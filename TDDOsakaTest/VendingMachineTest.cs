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
        [TestCase]
        public void お金を投入して金額を確認する()
        {
            var venderMachine = new VendorMachine();
            venderMachine.InsertMoney(100);

            Assert.AreEqual(100, venderMachine.Money);
        }
    }
}

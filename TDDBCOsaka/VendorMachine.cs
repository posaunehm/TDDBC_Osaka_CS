using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDBCOsaka
{
    public class VendorMachine
    {
        public int Money { get; private set; }

        public int InsertMoney(Money money) {
            Money += money.Amount;

            return money.Amount;
        }
    }
}

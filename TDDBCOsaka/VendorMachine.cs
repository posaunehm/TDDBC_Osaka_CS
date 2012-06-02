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

            if (10 <= money.Amount && money.Amount <=  1000)
            {
                Money += money.Amount;
                return 0;
            }
            else
            {
                return money.Amount;
            }
        }
    }
}

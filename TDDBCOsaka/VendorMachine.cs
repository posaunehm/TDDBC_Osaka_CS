using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDBCOsaka
{
    public class VendorMachine
    {
        public int Money { get; private set; }

        public int InsertMoney(List<Money> insertedList)
        {
            int money = 0;
            Money += insertedList.Sum(_ => _.Amount);

            return money;
        }

        public int InsertMoney(Money money) {
            Money += money.Amount;

            return money.Amount;
        }
    }
}

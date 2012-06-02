using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDBCOsaka
{
    public class VendorMachine
    {
        public int Money { get; private set; }

        public void InsertMoney(List<Money> insertedList)
        {
            Money += insertedList.Sum(_ => _.Amount);
        }
    }
}

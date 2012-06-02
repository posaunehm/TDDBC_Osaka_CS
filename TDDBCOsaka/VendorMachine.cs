using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDBCOsaka
{
    public class VendorMachine
    {
        public VendorMachine()
        {
            JuiceStock = new JuiceStock { Name = "コーラ", Price = 120, Stock = 5 };
        }

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



        public int PayBack()
        {
            int tmp = Money;

            Money = 0;

            return tmp;
        }

        public JuiceStock JuiceStock { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDBCOsaka
{
    public class VendorMachine
    {
        
        public void InsertMoney(int num1000, int num500, int num100, int num50, int num10)
        {
            Money += (1000 * num1000);
            Money += (500 * num500);
            Money += (100 * num100);
            Money += (50 * num50);
            Money += (10 * num10);
  
        }

        public int Money { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDBCOsaka
{
    public class VendorMachine
    {
        
        public void InsertMoney(int p)
        {
            Money += p;    
        }

        public int Money { get; set; }
    }
}

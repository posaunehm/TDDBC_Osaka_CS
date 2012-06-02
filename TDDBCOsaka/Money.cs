using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDDBCOsaka
{
    public class Money
    {
        private int amount;

        public Money(int amount)
        {
            this.amount = amount;
        }

        public int Amount
        {
            get
            {
                return amount;
            }
        }
    }
}

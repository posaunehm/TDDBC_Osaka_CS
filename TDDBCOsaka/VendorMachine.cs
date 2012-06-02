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

        public bool InsertMoney(Money money)
        {

            if (10 <= money.Amount && money.Amount <= 1000)
            {
                Money += money.Amount;
                return (JuiceStock.Price <= this.Money) && JuiceStock.Stock > 0;
            }
            else
            {
                throw new ArgumentException();


            }
        }



        public int PayBack()
        {
            int tmp = Money;

            Money = 0;

            return tmp;
        }

        public JuiceStock JuiceStock { get; set; }

        public Tuple<Juice, int> Buy()
        {
            if (this.JuiceStock.Stock > 0)
            {
                var tmp = Money - this.JuiceStock.Price;
                Money = 0;
                this.JuiceStock.Stock--;
                Earning += this.JuiceStock.Price;
                return new Tuple<Juice, int>(
                   new Juice { Name = this.JuiceStock.Name },
                   tmp
                );
            }
            else
            {
                return new Tuple<Juice, int>(
                    null,
                    this.Money
                    );
            }
        }

        public int Earning { get; set; }
    }
}

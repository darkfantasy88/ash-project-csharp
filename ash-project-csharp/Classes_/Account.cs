using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ash_project_csharp.Classes_
{
    public class Account
    {
        private double _balance = 0.0;

        public Account()
        {

        }
        public Account(double _openningBal=100.5)
        {
            _balance = _openningBal;
        }
        public void DepositTrans(double _amount)
        {
            _balance += _amount;
        }

        public void WithdrawlTrans(double _amount)
        {
            _balance -= _amount;
        }

        public double BalanceInquiry()
        {
            return _balance;
        }

    }
}

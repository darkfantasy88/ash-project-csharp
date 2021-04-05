using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ash_project_csharp
{
    public abstract class Account
    {
        private int custID_;
        private string actType_;
        private string _actno;
        private double _balance = 0.0;
        public double Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        
        public string AccountNumber
        {
            get => _actno;
            set
            {
                _actno = value;
            }
        }

        public int CxID { get => custID_; set { custID_ = value; } }

        public string AccountType
        {
            get => actType_;
            set
            {
                actType_ = value;
            }
        }
        public Account()
        {
            
        }
       
        public virtual double BalanceEnquiry()
        {
            return _balance;
        }

        public virtual void Withdrawl(double _amount)
        {
            if (_balance > 0)
            {
                _balance -= _amount;
            }
        }

        public void Deposit(double _amount)
        {
            _balance += _amount;
            Data_Helper.DataSetHelper.CxDeposit(this, _amount);

        }
    }
}

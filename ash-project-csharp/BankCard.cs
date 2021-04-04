using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ash_project_csharp
{
    public  class BankCard
    {
        protected Random rnd = new Random();

        private string _pin;
        private string _cardno;
        private bool _isLocked = false;
        private int custID_;
        private DateTime expiration;
        public int CxID { get => custID_; set { custID_ = value; } }

        public DateTime ExpirationDate
        {
            get => expiration;
            set
            {
                expiration = value;
            }
        }
        public string CardNumber
        {
            get { return _cardno; }
            set { _cardno = value; }
        }

        public string CardPin
        {
            get { return _pin; }
            set { _pin = value; }
        }
        public BankCard()
        {
                        
        }

        public void LockCard()
        {
            if (!_isLocked)
            {
                _isLocked = true;
            }
        }
        public void UnLockCard()
        {
            if (_isLocked)
            {
                _isLocked = false;
            }
        }

    }
}

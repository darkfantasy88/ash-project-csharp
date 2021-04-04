using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ash_project_csharp
{
    public class TransactionLog
    {
        private DateTime transDate;
        private int custID_;
        private string transDetails;

        public string TransactionDetails
        {
            get => transDetails;
            set
            {
                transDetails = value;
            }
        }

        public int CxID { get => custID_; set { custID_ = value; } }
        public DateTime TransactionDate
        {
            get => transDate;
            set
            {
                transDate = value;
            }
        }
        
    }
}

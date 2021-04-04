using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ash_project_csharp
{
    public class Customer
    {
        private string fname_;
        private string lname_;
        private int custID_;
        private string address_;
        private string phoneNo_;
        private string email_;
        private DateTime dob_;
        private string TRN_;

        public int CxID { get => custID_; set { custID_ = value; } }
        public string FirstName { get { return fname_; } set { fname_ = value; } }
        public string LastName { get { return lname_; } set { lname_ = value; } }

        public string Address { get => address_; set { address_ = value; } }

        public string PhoneNo { get => phoneNo_; set { phoneNo_ = value; } }

        public string Email { get => email_; set { email_ = value; } }

        public DateTime DOB { get => dob_; set { dob_ = value; } }

        public string TRN { get => TRN_; set { TRN_ = value; } }

        public DateTime DateCreated
        {
            get; set;
        }
       
        public Customer()
        {

        }

    

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ash_project_csharp
{
    public class SavingsAccount:Account
    {
        private double interestRate_ = 0.005;
        private DateTime dateCreated_;
        public double InterestRate
        {
            get => interestRate_;
        }

        public DateTime DateCreated
        {
            get => dateCreated_;
            set
            {
                dateCreated_ = value;
            }
        }

        public override double BalanceEnquiry()
        {
            var bal_with_interest = Balance + CalculateInterest();
            return bal_with_interest;
        }

        private double CalculateInterest()
        {
            try
            {
                double interest_ = 0.0;
                var time_existed = DateTime.Now - DateCreated;
                var total_months = time_existed.Days / 30;
                interest_ = Balance * InterestRate * total_months;
                return interest_;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

            }
        }
    }
}

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
        public double InterestRate
        {
            get => interestRate_;
        }


        public double CalculateInterest(Customer cx)
        {
            try
            {
                double interest_ = 0.0;
                var time_existed = DateTime.Now - cx.DateCreated;
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

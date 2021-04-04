using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ash_project_csharp
{
    public class CheckingAccount:Account
    {
        private double overdraft_ = 0.0;
        private double creditLimit_ = 20000.00;
        private bool hasOverdraft = false;

        public bool HasOverDraft
        {
            get => hasOverdraft;
            set
            {
                hasOverdraft = value;
            }
        }
        public double CreditLimit
        {
            get => creditLimit_;
            set
            {
                creditLimit_ = value;
            }
        }
        public override void Withdrawl(double _amount)
        {
            if (Balance > 0)
            {
                Balance -= _amount;
            }
            else
            {
                if (hasOverdraft)
                {


                    if (overdraft_ >= creditLimit_)
                    {
                        throw new Exception("Balance has reached credit limit");
                    }
                    else
                    {
                        overdraft_ = Balance - (_amount + 100);
                        Balance = overdraft_ ;
                    }
                }
                else
                {
                    throw new Exception("Transaction Cannot Be Completed As Amount Exceeds Available Balance");

                }
            }

            
        }
    }
}

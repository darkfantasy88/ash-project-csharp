using ash_project_csharp.Classes_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ash_project_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(5000);

            Console.WriteLine("{0:c}",account.BalanceInquiry());
            account.WithdrawlTrans(3000);
            Console.WriteLine("{0:c}", account.BalanceInquiry());
            account.DepositTrans(1500);
            Console.WriteLine("{0:c}", account.BalanceInquiry());
            Console.Read();
        }
    }
}

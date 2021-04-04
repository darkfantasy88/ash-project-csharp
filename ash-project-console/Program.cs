using ash_project_csharp;
using ash_project_csharp.Data_Helper;
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
            Menu();
            Console.Read();
        }

        static void Menu()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("**********************************");
            Console.WriteLine("\n1. Login With Customer ID\n\n2. Login With Account Number\n\n3. Register New Account\n");
            Console.WriteLine("**********************************");
            Console.WriteLine("**********************************");
            var menu_option=Console.ReadKey(true);

            MenuToOptions(menu_option.Key);
        }

        static void MenuToOptions(ConsoleKey seleted_option)
        {
            switch (seleted_option)
            {
                case ConsoleKey.NumPad1:LoginID();break;
                case ConsoleKey.NumPad2: LoginAct(); break;
                case ConsoleKey.NumPad3:RegisterCx();break;
                case ConsoleKey.D1: LoginID(); break;
                case ConsoleKey.D2: LoginAct(); break;
                case ConsoleKey.D3: RegisterCx(); break;
                default:
                    break;
            }
        }

        private static void RegisterCx()
        {
            
        }

        static void LoginID()
        {
            try
            {
                bool notfound_ = true;
                
                while (notfound_)
                {
                    Console.Clear();
                    Console.WriteLine("Login With Customer ID");
                    Console.WriteLine("----------------------");
                    Console.Write("Enter ID: ");
                    var input_ = Console.ReadLine();
                    if (input_ != string.Empty)
                    {
                        var cxID = Convert.ToInt32(input_);
                        var customer_ = DataSetHelper.FindCx(cxID);
                        notfound_ = false;
                        BankMenu(customer_);
                    }
                    input_ = string.Empty;
                }
               
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.Read();
                LoginID();
            }
       
           
        }

        static void LoginAct()
        {

        }

        private static void BankMenu(Customer customer_)
        {
            try
            {
                Console.Clear();
                var accounts_=DataSetHelper.FindCxAccounts(customer_);
                Console.WriteLine("Welcome {0} {1}\n",customer_.FirstName,customer_.LastName);
                if (accounts_.Count > 1)
                {
                    for (int i = 0; i < accounts_.Count; i++)
                    {
                        if(accounts_[i].GetType() == typeof(CheckingAccount))
                        {
                            Console.WriteLine("Checking Balance ({0}): {1:c}",accounts_[i].AccountNumber,accounts_[i].Balance);
                        }
                        else
                        {
                            var balance_=accounts_[i].Balance + ((SavingsAccount)accounts_[i]).CalculateInterest(customer_);
                            Console.WriteLine("Savings Balance ({0}): {1:c}",accounts_[i].AccountNumber,balance_);
                            Console.Write("\tSavings Account Interest: {0:c}", ((SavingsAccount)accounts_[i]).CalculateInterest(customer_));

                        }
                    }
                }
                else if(accounts_.Count==0)
                {
                    Console.WriteLine("No Account Exist");
                }
                else
                {
                    if (accounts_[0].GetType() == typeof(CheckingAccount))
                    {
                        Console.WriteLine("Checking Balance ({0}): {1:c}", accounts_[0].AccountNumber, accounts_[0].Balance);
                    }
                    else
                    {
                        var balance_ = accounts_[0].Balance + ((SavingsAccount)accounts_[0]).CalculateInterest(customer_);
                        Console.WriteLine("Savings Balance ({0}): {1:c}", accounts_[0].AccountNumber, balance_);
                        Console.Write("\tSavings Account Interest: {0:c}", ((SavingsAccount)accounts_[0]).CalculateInterest(customer_));

                    }
                }
                Console.WriteLine("");
                Console.WriteLine("1. Withdraw\t 2. Deposit \t3. Back To Main Menu");
                var menu_option = Console.ReadKey(true);
                BankMenuOption(menu_option.Key,accounts_);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.Write(ex.Message);
                Console.Read();
                BankMenu(customer_);
            }
        }

        private static void BankMenuOption(ConsoleKey menu_option, List<Account> accounts_)
        {
            switch (menu_option)
            {
              
                case ConsoleKey.D1:WithdrawScreen(accounts_);
                    break;
                case ConsoleKey.D2:DepositScreen(accounts_);
                    break;
                case ConsoleKey.D3:Menu();
                    break;
                case ConsoleKey.NumPad1:
                    break;
                case ConsoleKey.NumPad2:
                    break;
                case ConsoleKey.NumPad3:
                    break;
                default:
                    break;
            }
        }

        private static void DepositScreen(List<Account> accounts_)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("After Deposit You Will Be Taken Back To Prev Screen");
                Console.WriteLine();
                Console.Write("Accounts:");
                Console.WriteLine();

                for (int i = 0; i < accounts_.Count; i++)
                {
                    Console.Write("{0}.{1}",i,accounts_[i].AccountNumber);

                }
                Console.WriteLine("Select Account To Make Deposit To: ");
                var selection_ = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Amount To Deposit:");
                var amount_ = Convert.ToDouble(Console.ReadLine());
                accounts_[selection_ ].Deposit(amount_);
                BankMenu(DataSetHelper.FindCx(accounts_[selection_].CxID));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private static void WithdrawScreen(List<Account> accounts_)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("After Deposit You Will Be Taken Back To Prev Screen");
                Console.WriteLine();
                Console.Write("Accounts:");
                Console.WriteLine();

                for (int i = 0; i < accounts_.Count; i++)
                {
                    Console.Write("{0}.{1}\t", i , accounts_[i].AccountNumber);

                }
                Console.WriteLine("\nSelect Account To Make Withdrawl From: ");
                var selection_ = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Amount To Withdraw:");
                var amount_ = Convert.ToDouble(Console.ReadLine());
                accounts_[selection_ ].Withdrawl(amount_);
                BankMenu(DataSetHelper.FindCx(accounts_[selection_ ].CxID));

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}

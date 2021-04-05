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

        // Main Menu
        static void Menu()
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("**********************************");
            Console.WriteLine("\n1. Login With Customer ID\n\n2. Login With Account Number\n\n" +
                "3. Register New Account\n\n4. Reports\n");
            Console.WriteLine("**********************************");
            Console.WriteLine("**********************************");
            var menu_option=Console.ReadKey(true);

            MenuToOptions(menu_option.Key);
        }

        //Navigation For Option Selected From Menu
        static void MenuToOptions(ConsoleKey seleted_option)
        {
            switch (seleted_option)
            {
                case ConsoleKey.NumPad1:LoginID();break;
                case ConsoleKey.NumPad2: LoginAct(); break;
                case ConsoleKey.NumPad3:RegisterCx();break;
                case ConsoleKey.NumPad4:CxReport() ; break;

                case ConsoleKey.D1: LoginID(); break;
                case ConsoleKey.D2: LoginAct(); break;
                case ConsoleKey.D3: RegisterCx(); break;
                case ConsoleKey.D4: CxReport(); break;

                default:
                    break;
            }
        }

        //Register New Cx
        private static void RegisterCx()
        {
            try
            {
                Customer cx = new Customer();
                Console.Clear();
                Console.WriteLine("Welcome To ......");
                Console.WriteLine("Complete Below Form To Create Account. (* Marks Must Have) ");
                Console.WriteLine("----------------------");
                Console.Write("* First Name: ");
                cx.FirstName = Console.ReadLine().Trim();
                Console.WriteLine();
                Console.Write("* Last Name: ");
                cx.LastName = Console.ReadLine().Trim();
                Console.WriteLine();
                Console.Write("* Addess: ");
                cx.Address = Console.ReadLine().Trim();
                Console.WriteLine();
                Console.Write("Email: ");
                cx.Email = Console.ReadLine().Trim();
                Console.WriteLine();
                Console.Write("Phone Number: ");
                cx.PhoneNo = Console.ReadLine().Trim();
                Console.WriteLine();
                Console.Write("TRN: ");
                cx.TRN = Console.ReadLine().Trim();
                Console.WriteLine();
                Console.WriteLine("Date of birth");
                Console.Write("Month: ");
                var month = Console.ReadLine().Trim();
                Console.WriteLine();
                Console.Write("Day: ");
                var date = Console.ReadLine().Trim();
                Console.WriteLine();
                Console.Write("Year: ");
                var year = Console.ReadLine().Trim();
                Console.WriteLine();
                cx.DOB = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(date));
                DataSetHelper.InsertCx(cx);
                Console.WriteLine($"Congrats {cx.FirstName} your are now have a login use {cx.CxID} on next screen");
                Console.Read();
                LoginID();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.Read();
                RegisterCx();
            }
        }

        private static void CreateAcct(Customer customer_)
        {
            try
            {
                Account act_=null;
                Console.Clear();
                Console.Write("Pick Type Of Account To Create: 1. Savings \t2. Checking ");
                var selection_ = Console.ReadLine().Trim();
                switch (selection_)
                {
                    case "1":act_ = new SavingsAccount();break;
                    case "2":act_ = new CheckingAccount();break;
                }
                DataSetHelper.InsertCx(customer_, act_);
                Console.WriteLine();
                Console.WriteLine($"{customer_.FirstName} new Account Has Been Created With Account Number: {act_.AccountNumber}");
                Console.Read();
                BankMenu(customer_);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.Read();
                RegisterCx();
            }
        }

        private static void CxReport()
        {
            try
            {
                bool notfound_ = true;

                while (notfound_)
                {
                    Console.Clear();
                    Console.WriteLine("Report Based On Customer");
                    Console.WriteLine("----------------------");
                    Console.Write("Customer ID: ");
                    var input_ = Console.ReadLine();
                    if (input_ != string.Empty)
                    {
                        var cxID = Convert.ToInt32(input_);
                        var customer_ = DataSetHelper.FindCx(cxID);
                        notfound_ = false;
                        PrintReport(customer_);
                    }
                    input_ = string.Empty;
                }
                Menu();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.Read();
                CxReport();
            }
        }

        private static void PrintReport(Customer customer_)
        {
            try
            {
                Console.Clear();
                var transactions_=DataSetHelper.FindCxTransactions(customer_);
                for (int i = 0; i < transactions_.Count; i++)
                {
                    Console.WriteLine("{0}=>\t{1}",transactions_[i].TransactionDate,transactions_[i].TransactionDetails);
                }

                Console.WriteLine();
                Console.WriteLine("Press Enter To Move Back To Menu");
                Console.Read();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.Read();
            }
        }

        //Log In & View All Accounts
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
        //Log Into Single Account
        static void LoginAct()
        {
            try
            {
                bool notfound_ = true;

                while (notfound_)
                {
                    Console.Clear();
                    Console.WriteLine("Login With Account Nmber");
                    Console.WriteLine("----------------------");
                    Console.Write("Accont Number: ");
                    var input_ = Console.ReadLine();
                    if (input_ != string.Empty)
                    {
                        var actNo_ = input_.Trim();
                        var account_ = DataSetHelper.FindAccount(actNo_);
                        notfound_ = false;
                        ActMenu(account_);
                    }
                    input_ = string.Empty;
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.Read();
                LoginAct();
            }
        }

        //Menu For Single Account
        private static void ActMenu(Account account_)
        {
            Console.Clear();
            var customer_ = DataSetHelper.FindCx(account_.CxID);
            Console.WriteLine("Welcome {0} {1}\n", customer_.FirstName, customer_.LastName);
            if (account_.GetType() == typeof(CheckingAccount))
            {
                Console.WriteLine("Checking Balance ({0}): {1:c}", account_.AccountNumber, account_.Balance);

            }
            else
            {
                Console.WriteLine("Savings Balance ({0}): {1:c}", account_.AccountNumber, account_.BalanceEnquiry());

            }

            Console.WriteLine("");
            Console.WriteLine("1. Withdraw\t 2. Deposit \t3. Back To Main Menu");
            var menu_option = Console.ReadKey(true);
            BankMenuOption(menu_option.Key, account_);
        }

        //Menu For All Accounts
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

                            Console.WriteLine("Savings Balance ({0}): {1:c}",accounts_[i].AccountNumber,accounts_[i].BalanceEnquiry());

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
                        Console.WriteLine("Savings Balance ({0}): {1:c}", accounts_[0].AccountNumber, accounts_[0].BalanceEnquiry());

                    }
                }
                Console.WriteLine("");
                if(accounts_.Count > 0)
                {
                    Console.WriteLine("1. Withdraw\t 2. Deposit \t3. Back To Main Menu \t4.Create New Account");
                }
                else
                {
                    Console.WriteLine("1.Back To Main Menu \t2.Create New Account");
                }
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

        //Menu Navigation To Do Account Transactions (Deposit, Withdraw)
        private static void BankMenuOption(ConsoleKey menu_option, List<Account> accounts_)
        {
            if (accounts_.Count > 0)
            {
                switch (menu_option)
                {

                    case ConsoleKey.D1:
                        WithdrawScreen(accounts_);
                        break;
                    case ConsoleKey.D2:
                        DepositScreen(accounts_);
                        break;
                    case ConsoleKey.D3:
                        Console.Clear(); Menu();
                        break;
                    case ConsoleKey.D4:
                        CreateAcct(DataSetHelper.FindCx(accounts_[0].CxID));
                        break;
                    case ConsoleKey.NumPad1:
                        WithdrawScreen(accounts_);

                        break;
                    case ConsoleKey.NumPad2:
                        DepositScreen(accounts_);

                        break;
                    case ConsoleKey.NumPad3:
                        Console.Clear(); Menu();
                        break;
                    case ConsoleKey.NumPad4:
                        CreateAcct(DataSetHelper.FindCx(accounts_[0].CxID));
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (menu_option)
                {

                    case ConsoleKey.D1:Console.Clear();
                        Menu();
                        break;
                    case ConsoleKey.D2:
                        CreateAcct(DataSetHelper.FindCx(accounts_[0].CxID));
                        break;
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        Menu();
                        break;
                    case ConsoleKey.NumPad2:
                        CreateAcct(DataSetHelper.FindCx(accounts_[0].CxID));

                        break;
                    case ConsoleKey.NumPad3:
                        break;
                    default:
                        break;
                }
            }
        }
        
        private static void BankMenuOption(ConsoleKey menu_option, Account accounts_)
        {
            switch (menu_option)
            {

                case ConsoleKey.D1:
                    WithdrawScreen(accounts_);
                    break;
                case ConsoleKey.D2:
                    DepositScreen(accounts_);
                    break;
                case ConsoleKey.D3:
                    Console.Clear(); Menu();
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
        //

        //Deposit To Multiple Accounts
        private static void DepositScreen(List<Account> accounts_)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("After Deposit You Will Be Taken Back To Prev Screen");
                Console.WriteLine();
                Console.Write("Accounts:\t");

                for (int i = 0; i < accounts_.Count; i++)
                {
                    Console.Write("{0}.{1}\t",i+1,accounts_[i].AccountNumber);

                }
                Console.WriteLine();
                Console.Write("Select Account To Make Deposit To: ");
                var selection_ = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Enter Amount To Deposit:");
                var amount_ = Convert.ToDouble(Console.ReadLine());
                accounts_[selection_-1 ].Deposit(amount_);
                BankMenu(DataSetHelper.FindCx(accounts_[selection_-1].CxID));
            }
            catch (Exception ex)
            {
                Console.WriteLine();

                Console.WriteLine(ex.Message);
                Console.Read();
                DepositScreen(accounts_);
            }
        }

        //Deposit To Single Account
        private static void DepositScreen(Account accounts_)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("After Deposit You Will Be Taken Back To Prev Screen");
                Console.WriteLine();
                Console.Write("Enter Amount To Deposit:");
                var amount_ = Convert.ToDouble(Console.ReadLine());
                accounts_.Deposit(amount_);
                ActMenu(accounts_);
            }
            catch (Exception ex)
            {
                Console.WriteLine();

                Console.WriteLine(ex.Message);
                Console.Read();
                DepositScreen(accounts_);
            }
        }

        //Withdraw From Multiple Accounts
        private static void WithdrawScreen(List<Account> accounts_)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("After Withdrawl You Will Be Taken Back To Prev Screen");
                Console.WriteLine();
                Console.Write("Accounts:\t");

                for (int i = 0; i < accounts_.Count; i++)
                {
                    Console.Write("{0}.{1}\t", i+1, accounts_[i].AccountNumber);

                }
                Console.WriteLine();
                Console.WriteLine("\nSelect Account To Make Withdrawl From: ");
                var selection_ = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Enter Amount To Withdraw:");
                var amount_ = Convert.ToDouble(Console.ReadLine());
                accounts_[selection_ -1].Withdrawl(amount_);
                BankMenu(DataSetHelper.FindCx(accounts_[selection_ -1].CxID));

            }
            catch (Exception ex)
            {

                Console.WriteLine();

                Console.WriteLine(ex.Message);
                Console.Read();
                WithdrawScreen(accounts_);
            }
        }
        
        //Withdraw From A Sngle Account
        private static void WithdrawScreen(Account accounts_)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("After Withdrawl You Will Be Taken Back To Prev Screen");
                Console.WriteLine();
                Console.WriteLine("Enter Amount To Withdraw:");
                var amount_ = Convert.ToDouble(Console.ReadLine());
                accounts_.Withdrawl(amount_);
                ActMenu(accounts_);

            }
            catch (Exception ex)
            {
                Console.WriteLine();

                Console.WriteLine(ex.Message);
                Console.Read();
                WithdrawScreen(accounts_);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ash_project_csharp.Data_Helper
{
    public static class DataSetHelper
    {
        private static List<Customer> cxList = new List<Customer>()
        {
            new Customer()
            {
                CxID=1,
                FirstName="Ashley",
                LastName="Johnson",
                DOB=new DateTime(1999,09,01),
                Address="10 Woolwich Dr, Vineyard Town",
                PhoneNo=null,
                Email="ashjohnson08@gmail.com",
                TRN="985634217"
                
            },
            new Customer()
                {
                    CxID=2,
                    TRN = "123456789",
                    Address = "28 Potters Row, Kingston 16",
                    FirstName = "Rohan",
                    LastName = "Cooper",
                    DOB = new DateTime(1999, 08, 08),
                    Email = "rohancooper99@gmail.com",
                    PhoneNo = "8765546375"
            },
            new Customer()
                {   
                    CxID=3,
                    TRN = "562132789",
                    Address = "2a Pedro Close, Kingston 16",
                    FirstName = "Trevaughn",
                    LastName = "Wright",
                    DOB = new DateTime(1997, 07, 28),
                    Email = "tw@wrightholdings.com",
                    PhoneNo = "8763145962"
               }
        };

        private static List<Account> bankActs = new List<Account>()
        {
            new CheckingAccount()
            {
                CxID=1,
                AccountNumber="789456",
                Balance=500000.00,
                HasOverDraft=true,
                CreditLimit=10000,
                AccountType="Checking",

            },
            new SavingsAccount()
            {
                CxID=1,
                AccountNumber="423145",
                Balance=13500.00,
                AccountType="Savings",
                DateCreated=new DateTime(2021,01,23)

            },
             new CheckingAccount()
            {
                CxID=2,
                AccountNumber="264554",
                Balance=800000.00,
                HasOverDraft=true,
                CreditLimit=10000,
                AccountType="Checking"
            },
            new SavingsAccount()
            {
                CxID=3,
                AccountNumber="547721",
                Balance=20000.00,
                AccountType="Savings",
                DateCreated=new DateTime(2021,04,01)
            }
        };

        private static List<TransactionLog> transactionLogs = new List<TransactionLog>()
        {
            new TransactionLog()
            {
                CxID=1,
                TransactionDate=new DateTime(2020,12,03),
                TransactionDetails="Ashley Succesfully Created A New Checking Account"
            },
            new TransactionLog()
            {
                CxID=1,
                TransactionDate=new DateTime(2020,12,07),
                TransactionDetails="A Deposit of $500000 was made"
            },
            new TransactionLog()
            {
                CxID=1,
                TransactionDate=new DateTime(2021,01,23),
                TransactionDetails="Ashley Succesfully Created A New Savings Account"
            },
            new TransactionLog()
            {
                CxID=1,
                TransactionDate=new DateTime(2021,02,01),
                TransactionDetails="A Deposit of $13500 was made"
            },
            new TransactionLog()
            {
                CxID=2,
                TransactionDate=new DateTime(2021,03,03),
                TransactionDetails="Rohan Succesfully Created A New Checking Account"
            },
            new TransactionLog()
            {
                CxID=2,
                TransactionDate=new DateTime(2021,03,13),
                TransactionDetails="A Deposit of $1000000 was made"
            },
            new TransactionLog()
            {
                CxID=2,
                TransactionDate=new DateTime(2021,03,25),
                TransactionDetails="A Withdrawl of $200000 was made"
            },
            new TransactionLog()
            {
                CxID=3,
                TransactionDate=new DateTime(2021,04,01),
                TransactionDetails="Trevaughn Successfully Created A New Savings Account"
            }
        };
        

        private static  void RecordTransaction(string details,int cxID)
        {
            try
            {
                transactionLogs.Add(new TransactionLog() { TransactionDate = DateTime.Now, CxID = cxID, TransactionDetails = details });         
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public static void InsertCx(Customer cx)
        {
            try
            {
                cx.CxID = cxList.Count + 1;
                cxList.Add(cx);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }
        public static void InsertCx(Customer cx,Account account)
        {
            try
            {
                //cx.CxID = cxList.Count + 1;
                //cxList.Add(cx);
                account.AccountNumber = AccountNoGenerator();
                account.CxID = cx.CxID;
                RecordTransaction($"{cx.FirstName} Successfully Created A Account", cx.CxID);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
            
        }
        private static string AccountNoGenerator()
        {
            Random rnd = new Random();
            var actno_=rnd.Next(111111, 999999);
            for (int i = 0; i < bankActs.Count; i++)
            {
                if (bankActs[i].AccountNumber != Convert.ToString(actno_))
                {
                    return Convert.ToString(actno_);
                }
                else
                {
                    actno_ = rnd.Next(111111, 999999);
                }
            }
            return Convert.ToString(actno_);


        }
        public static Customer FindCx(int cxID)
        {
            try
            {
                Customer customer_=null;
                for (int i = 0; i < cxList.Count; i++)
                {
                    if (cxList[i].CxID == cxID)
                    {
                        customer_ = cxList[i];
                    }
                    else if (cxID > cxList.Count)
                    {
                        throw new Exception("Customer Does Not Exist");
                    }
                }

                return customer_;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static List<Account> FindCxAccounts(Customer cx)
        {
            try
            {
                List<Account> cxActs=new List<Account>();
                for (int i = 0; i < bankActs.Count; i++)
                {
                    if (bankActs[i].CxID == cx.CxID)
                    {
                        cxActs.Add(bankActs[i]);
                    }
                }

                return cxActs;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static Account FindAccount(string actNo_)
        {
            try
            {
                var act_ = bankActs.Find(x => x.AccountNumber == actNo_);

                return act_;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public static List<TransactionLog> FindCxTransactions(Customer cx)
        {
            try
            {
                List<TransactionLog> cxActs = new List<TransactionLog>();
                for (int i = 0; i < transactionLogs.Count; i++)
                {
                    if (transactionLogs[i].CxID == cx.CxID)
                    {
                        cxActs.Add(transactionLogs[i]);
                    }
                }

                return cxActs;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static void CxWithdrawl(Account account,double amount_)
        {
            try
            {
                var act_=bankActs.Find(x => x == account);

                RecordTransaction(string.Format("Withdrawl of {0:c} from account {1}", amount_, act_.AccountNumber), act_.CxID);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static void CxDeposit(Account account, double amount_)
        {
            try
            {
                var act_ = bankActs.Find(x => x == account);

                RecordTransaction(string.Format("Deposit of {0:c} to account {1}", amount_, act_.AccountNumber), act_.CxID);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static void CxOverdraft(Account account, double amount_)
        {
            try
            {
                var act_ = bankActs.Find(x => x == account);

                RecordTransaction(string.Format("Account {0} overdraft is {1} ", act_.AccountNumber,amount_), act_.CxID);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}

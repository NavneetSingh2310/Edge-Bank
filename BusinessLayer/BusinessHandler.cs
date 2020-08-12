using ApteanEdgeBank_Final;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;


namespace BusinessLayer
{
    public class BusinessHandler
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool user_login(string username, string password)
        {

            try
            {
                log.Info("Loging in!");
                DBCustomerLayer db = new DBCustomerLayer();
                return db.user_login(username, password);
            }
            finally { }

        }

        public bool AddCustomer(Customer customer)
        {
            try
            {
                log.Info("Adding Customer!");
                DBCustomerLayer db = new DBCustomerLayer();
                return db.AddCustomer(customer);
            }
            finally { }

        }

        public object getNextCustomerId()
        {
            try
            {
                log.Info("Getting next customer id");
                DBCustomerLayer db = new DBCustomerLayer();
                return db.getNextCustomerId();
            }
            finally { }
        }

        public ObservableCollection<Customer> getCustomerDetails(int id)
        {
            try
            {
                log.Info("Getting customer details");
                DBCustomerLayer db = new DBCustomerLayer();
                return db.getCustomerDetails(id);
            }
            finally { }
        }

        public bool updateCustomer(int id, string name, DateTime date)
        {
            try
            {
                log.Info("Updating customer with customer id: " + id + " name: " + name);
                return new DBCustomerLayer().updateCustomer(id, name, date);
            }
            finally { }
        }

        public int getAccountId()
        {
            try
            {
                log.Info("Getting account id from DBAccountLayer");
                return new DBAccountLayer().getAccountId();
            }
            finally { }
        }

        public bool AddAccountToDatabase(Account account)
        {
            try
            {
                log.Info("Adding account to database with account id: " + account.Account_id);
                return new DBAccountLayer().AddAccountToDatabase(account);
            }
            finally { }
        }

        public DataTable getAccountDetails(int id)
        {
            try
            {
                log.Info("Getting account details from DBAccountLayer");
                return new DBAccountLayer().getAccountDetails(id);
            }
            finally { }
        }

        public DataTable getAllAccountsOfCustomer(int id)
        {
            try
            {
                log.Info("Getting all accounts of customer details from DBAccountLayer");
                return new DBAccountLayer().getAllAccountsOfCustomer(id);
            }
            finally { }
        }

        public bool CloseOrReopenAccount(int id, string status)
        {
            try
            {
                log.Info("closing or reopening started: " + status);
                return new DBAccountLayer().CloseOrReopenAccount(id, status);
            }
            finally { }
        }

        public bool AccountDeposit(int cid, int aid, double amount)
        {
            try
            {
                log.Info("Account Deposit started. Account_id: " + aid + " Amount: " + amount);
                return new DBAccountLayer().AccountDeposit(cid, aid, amount);
            }
            finally { }
        }

        public bool AccountWithdraw(int cid, int aid, double amount)
        {
            try
            {
                log.Info("Account withdraw started: Customer_Id: " + cid + " Account_Id: " + aid + " Amount: " + amount);
                return new DBAccountLayer().AccountWithdraw(cid, aid, amount);
            }
            finally { }
        }

        public double getAccountBalance(int customer_id, int account_id)
        {
            try
            {
                log.Info("Get account balance started: Customer_Id: " + customer_id + " Account_Id: " + account_id);
                return new DBAccountLayer().getAccountBalance(customer_id, account_id);
            }
            finally { }
        }

        public bool AddLiabilityAccountToDB(Liability account)
        {
            try
            {
                log.Info("Add Liability Account To DB started");
                return new DBLiabilityLayer().AddLiabilityAccountToDB(account);
            }
            finally { }
        }

        public int getLiabilityAccountId()
        {
            try
            {
                log.Info("Get liability account id started");
                return new DBLiabilityLayer().getAccountId();
            }
            finally { }
        }

        public DataTable getLiabilityAccountDetails(int id)
        {
            try
            {
                log.Info(" Get liability account details started");
                return new DBLiabilityLayer().getAccountDetails(id);
            }
            finally { }
        }

        public DataTable getAllLiabilityAccountsOfCustomer(int id)
        {
            try
            {
                log.Info(" Get all liability accounts of a customer started");
                return new DBLiabilityLayer().getAllAccountsOfCustomer(id);
            }
            finally { }
        }

        public int getLiabilityAccountIdByCustomerId(int cid)
        {
            try
            {
                log.Info("Get liabiity account id by customer id  started");
                return new DBLiabilityLayer().getAccountIdByCustomerId(cid);
            }
            finally { }
        }

        public bool issueLoan(int aid, double amount)
        {
            try
            {
                log.Info(" Issue loan started");
                return new DBLiabilityLayer().issueLoan(aid, amount);
            }
            finally { }
        }

        public bool RepayLoan(int id, double amount)
        {
            try
            {
                log.Info("Repay loan started");
                return new DBLiabilityLayer().RepayLoan(id, amount);
            }
            finally { }
        }

        public DataTable getGernalAccountDetails()
        {
            try
            {
                log.Info("Get general account details started");
                return new DBLiabilityLayer().getGernalAccountDetails();
            }
            finally { }
        }

        public bool AddGeneralAccount(Bank bank)
        {
            try
            {
                log.Info("Add general account started");
                return new DBAccountLayer().AddGeneralAccount(bank);
            }
            finally { }
        }

        public void updateGeneralAccount(double amount, char mode)
        {
            try
            {
                log.Info("Update general account started");
                new DBLiabilityLayer().updateGeneralAccount(amount, mode);
            }
            finally { }
        }

        public double getGeneralAccountBalance()
        {
            try
            {
                log.Info("Get general account balance started");
                return new DBLiabilityLayer().getGeneralAccountBalance();
            }
            finally { }
        }

        public int getGeneralAccountId()
        {
            try
            {
                log.Info("Get general account id started");
                return new DBLiabilityLayer().getGeneralAccountId();
            }
            finally { }
        }

        public DataTable getAccountLogs(int aid)
        {
            try
            {
                log.Info(" Get account logs started");
                return new DBAccountLayer().getAccountLogs(aid);
            }
            finally { }
        }

        public DataTable getAllAccountLogs()
        {
            try
            {
                log.Info("Get all account logs started");
                return new DBAccountLayer().getAllAccountLogs();
            }
            finally { }
        }

        public double getAccountBalanceById(int aid)
        {
            try
            {
                log.Info("Get account balance by id started");
                return new DBAccountLayer().getAccountBalanceById(aid);
            }
            finally { }
        }

        public List<Account> getAllAccountsOfCustomerList(int id)
        {
            try
            {
                DBAccountLayer db = new DBAccountLayer();
                return db.getAllAccountsOfCustomerList(id);
            }
            finally { }
        }
    }
}

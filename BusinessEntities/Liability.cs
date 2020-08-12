using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Liability
    {
        private int account_id;
        private int customer_id;
        private string account_type;
        private double balance;

        public Liability(int aid,int cid,string type,double bal)
        {
            account_id = aid;
            customer_id = cid;
            account_type = type;
            balance = bal;
        }

        public Liability()
        {

        }
        #region Methods
        public int getId() { return account_id; }
        public int getCustomerId() { return customer_id; }
        public string getAccountType() { return account_type; }

        public double getBalance() { return balance; }
        #endregion

    }
}

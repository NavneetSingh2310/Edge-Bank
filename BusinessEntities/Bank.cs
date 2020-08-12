using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class Bank
    {
        private string name = "Aptean Edge Bank";
        private int account_id;
        private string IFSC_Code;
        private double balance;
        private string account_type="bank";
        public Bank()
        {
                
        }

        public Bank(int account_id,string code,double bal)
        {
            this.account_id = account_id;
            this.IFSC_Code = code;
            balance = bal;
         
        }

        public string getName()
        {
            return name;
        }
        public string geCode()
        {
            return IFSC_Code;
        }
        public string getAccountType()
        {
            return account_type;
        }
        public int getAccountId()
        {
            return account_id;
        }
        public double getBalance()
        {
            return balance;
        }
    }
}

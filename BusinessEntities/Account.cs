using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{    
        public class Account
         {
        
       
            #region Member
            public int  Account_id;
            public int customer_id;
            public DateTime Date_Opened;
            public double Balance;
            public  string Account_type;
            bool isActive;

        #endregion Member

        #region Constructors
        public Account()
        {

        }
            public Account(int customer_id,int id, DateTime openDate, string type,double balance)
            {
                this.customer_id = customer_id;
                Account_id = id;
                Date_Opened = openDate;
                Account_type = type;
                isActive = true;
                Balance = balance;


            }
            #endregion Constructors

            #region Methods

          
            

            public double getBalance()
            {
                return Balance;
            }

            public bool getStatus()
            {
                return isActive;
            }

            public int getAccountId()
            {
                return Account_id;
            }
            public void setBalance(double amount)
            {
                Balance = amount;
            }
            public void setStatus(bool status)
            {
                isActive = status;
            }

            public string getAccountType()
            {
                return Account_type;
            }
            #endregion
        }
    }


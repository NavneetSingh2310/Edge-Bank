using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class Customer
    {
        #region Member
       public   int Customer_id;
        public string Customer_name;
       public DateTime dateOfJoining;
     
        #endregion Members

        #region Constructors
        public Customer()
        {

        }
        public Customer(int Customer_id, string Customer_name, DateTime dateOfJoining)
        {
            this.dateOfJoining = dateOfJoining;
            this.Customer_id = Customer_id;
            this.Customer_name = Customer_name;
        }
        #endregion Constructors

        #region Methods
        public int getCustomerId()
        {
            return Customer_id;
        }
        public string getCustomerName()
        {
            return Customer_name;
        }
        public DateTime getCustomerDateOfJoining()
        {
            return dateOfJoining;
        }

       
        public void setCustomerName(string name)
        {
            Customer_name = name;
        }
        #endregion


    }
}

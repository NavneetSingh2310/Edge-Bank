using BusinessEntities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApteanEdgeBank_Final
{
   public class DBLiabilityLayer
    {
        #region Members
        public SqlConnection connection = null;
        string connectionString = "Data Source=.;Initial Catalog='ApteanEdgeBank';Integrated Security=True";
        #endregion

        #region Constructor
        public DBLiabilityLayer()
        {
            try
            {
                if (connection == null)
                {
                    connectionString = "Data Source=.;Initial Catalog='ApteanEdgeBank';Integrated Security=True";
                    connection = new SqlConnection(connectionString);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        #endregion

        public bool AddLiabilityAccountToDB(Liability account)
        {
            try
            {
                if (!isAccountTypeExists(account))
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                   
                    var sql = "insert into liabilityAccount values(@aid,@cid,@type,@balance)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@aid", account.getId());
                    cmd.Parameters.AddWithValue("@cid", account.getCustomerId());
                    cmd.Parameters.AddWithValue("@type", account.getAccountType());
                    cmd.Parameters.AddWithValue("@balance", account.getBalance());
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("This type account already exists");
                   
                }

            }
            
            finally
            {
                connection.Close();
            }
            return true;
        }

        public bool isAccountTypeExists(Liability account)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                using (SqlCommand cmd = new SqlCommand("select account_id from liabilityAccount where account_type=@atype and customer_id=@cid", connection))
                {
                    cmd.Parameters.AddWithValue("@atype", account.getAccountType());
                    cmd.Parameters.AddWithValue("@cid", account.getCustomerId());
                    var id = cmd.ExecuteScalar();
                    connection.Close();
                    if (id == null)
                        return false;
                }
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return true;
        }

        public int getAccountId()
        {
            int id = 0;
            int count = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                var sql1 = "select count(*) from liabilityAccount";
                SqlCommand cmd1 = new SqlCommand(sql1, connection);
                count = Convert.ToInt32(cmd1.ExecuteScalar());
                if (count == 0)
                {
                    id = 9800;
                }
                else
                {
                    var sql = "select MAX(account_id) from liabilityAccount";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }
               

            }
            
            finally
            {
                connection.Close();
            }
            return id;
        }

        public DataTable getAccountDetails(int id)
        {
            DataTable _datatable = new DataTable();
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from liabilityAccount where account_id=" + id, connection))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(_datatable);
                }
            }
          
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return _datatable;
        }

        public DataTable getAllAccountsOfCustomer(int id)
        {
            DataTable _datatable = new DataTable();
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from liabilityAccount where customer_id=" + id, connection))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(_datatable);
                }
            }
            
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return _datatable;
        }

        public int getAccountIdByCustomerId(int cid)
        {
            int id = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                var sql = "select account_id from liabilityAccount where customer_id=" + cid;
                SqlCommand cmd = new SqlCommand(sql, connection);
                id = Convert.ToInt32(cmd.ExecuteScalar());


            }
           finally
            {
                connection.Close();
            }
            return id;
        }

        public double getGeneralAccountBalance()
        {
            double balance = 0.0f;
            int count = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                var sql1 = "select count(*) from bank";
                SqlCommand cmd1 = new SqlCommand(sql1, connection);
                count = Convert.ToInt32(cmd1.ExecuteScalar());
                if (count == 0) { throw new Exception("There is no bank account"); }
                else
                {
                    var sql = "select SUM(balance) from bank";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    balance = Convert.ToDouble(cmd.ExecuteScalar());
                }


            }
           
            finally
            {
                connection.Close();
            }
            return balance;
        }

        public double getLiabilityAccountBalance(int aid)
        {

            double balance = 0.0f;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                var sql = "select balance from liabilityAccount where account_id=" + aid;
                SqlCommand cmd = new SqlCommand(sql, connection);
                balance = Convert.ToDouble(cmd.ExecuteScalar());


            }
            finally
            {
                connection.Close();
            }
            return balance;
        }

        public bool issueLoan(int aid, double amount)
        {
            try
            {

                double balance = getGeneralAccountBalance();
                connection = new SqlConnection(connectionString);
                connection.Open();
                if (balance - amount >= 5000)
                {
                    balance -= amount;
                }
                else
                {
                    throw new Exception("Not Appropriate balance");

                }

                using (SqlCommand cmd = new SqlCommand("update bank set balance=" + balance + " where account_type='bank'", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("update liabilityAccount set balance+=" + amount + " where account_id=" + aid, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand("insert into accountLogs values(@aid,@mode,@amount,@datetime)", connection))
                {
                    cmd.Parameters.AddWithValue("@aid", aid);
                    cmd.Parameters.AddWithValue("@mode", "Loan Taken");
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@datetime", DateAndTime.Now);
                    cmd.ExecuteNonQuery();

                }
                using (SqlCommand cmd = new SqlCommand("insert into accountLogs values(@aid,@mode,@amount,@datetime)", connection))
                {
                    connection.Close();
                    int id = getGeneralAccountId();
                    connection.Open();
                    cmd.Parameters.AddWithValue("@aid", id);
                    cmd.Parameters.AddWithValue("@mode", "Loan Given");
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@datetime", DateAndTime.Now);
                    cmd.ExecuteNonQuery();

                }


            }
          
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return true;
        }

        public bool RepayLoan(int aid, double amount)
        {
            try
            {

                double balance = getLiabilityAccountBalance(aid);
                connection = new SqlConnection(connectionString);
                connection.Open();
                if (balance - amount >= 0)
                {
                    balance -= amount;
                }
                else
                {
                    throw new Exception("Not Appropriate balance");

                }

                using (SqlCommand cmd = new SqlCommand("update bank set balance+=" + amount + " where account_type='bank'", connection))
                {
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("update liabilityAccount set balance=" + balance + " where account_id=" + aid, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                using (SqlCommand cmd = new SqlCommand("insert into accountLogs values(@aid,@mode,@amount,@datetime)", connection))
                {
                    cmd.Parameters.AddWithValue("@aid", aid);
                    cmd.Parameters.AddWithValue("@mode", "RepayMade");
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@datetime", DateAndTime.Now);
                    cmd.ExecuteNonQuery();

                }

                using (SqlCommand cmd = new SqlCommand("insert into accountLogs values(@aid,@mode,@amount,@datetime)", connection))
                {
                    connection.Close();
                    int id = getGeneralAccountId();
                    connection.Open();
                    cmd.Parameters.AddWithValue("@aid", id);
                    cmd.Parameters.AddWithValue("@mode", "RepayTaken");
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@datetime", DateAndTime.Now);
                    cmd.ExecuteNonQuery();

                }


            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return true;
        }

        public int getGeneralAccountId()
        {
            int id = 0;
            int count = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                var sql1 = "select count(*) from bank";
                SqlCommand cmd1 = new SqlCommand(sql1, connection);
                count = Convert.ToInt32(cmd1.ExecuteScalar());
                if (count == 0) { throw new Exception("There is no bank account"); }
                   else {
                    var sql = "select account_id from bank where account_type='bank'";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                }


            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                connection.Close();
            }
            return id;
        }

        public void updateGeneralAccount(double amount, char choice)
        {
            try
            {
                double balance = getGeneralAccountBalance();
                connection = new SqlConnection(connectionString);
                connection.Open();
                if (choice == 'd')
                {
                    using (SqlCommand cmd = new SqlCommand("update bank set balance+=" + amount + " where account_type='bank'", connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("insert into accountLogs values(@aid,@mode,@amount,@datetime)", connection))
                    {
                       
                        int id = getGeneralAccountId();
                        connection.Open();
                        cmd.Parameters.AddWithValue("@aid", id);
                        cmd.Parameters.AddWithValue("@mode", "Deposit");
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@datetime", DateAndTime.Now);
                        cmd.ExecuteNonQuery();

                    }

                }
                else if (choice == 'w')
                {

                    if (balance - amount >= 5000)
                    {
                        using (SqlCommand cmd = new SqlCommand("update bank set balance-=" + amount + " where account_type='bank'", connection))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd = new SqlCommand("insert into accountLogs values(@aid,@mode,@amount,@datetime)", connection))
                        {
                           
                            int id = getGeneralAccountId();
                            connection.Open();
                            cmd.Parameters.AddWithValue("@aid", id);
                            cmd.Parameters.AddWithValue("@mode", "Withdraw");
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("@datetime", DateAndTime.Now);
                            cmd.ExecuteNonQuery();

                        }

                    }
                    else
                    {

                        throw new Exception("Not sufficient balance");
                    }
                }
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        public DataTable getGernalAccountDetails()
        {
            DataTable _datatable = new DataTable();
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from bank where account_type='bank'", connection))
                {
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(_datatable);
                }
            }

            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return _datatable;
        }
    }
}

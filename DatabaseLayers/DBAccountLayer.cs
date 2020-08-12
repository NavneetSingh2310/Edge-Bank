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
   public class DBAccountLayer
    {
        #region Members
        public SqlConnection connection = null;
        string connectionString = "Data Source=.;Initial Catalog='ApteanEdgeBank';Integrated Security=True";
        
        #endregion

        #region Constructor
        public DBAccountLayer()
        {
            try
            {
                if (connection == null)
                {
                    connectionString = "Data Source=.;Initial Catalog='ApteanEdgeBank';Integrated Security=True";
                    connection = new SqlConnection(connectionString);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
        #endregion

        #region Methods
        public void closeConnection()
        {
            connection.Close();
            connection.Dispose();
        }

        public bool AddAccountToDatabase(Account account)
        {
            try
            {
                if (!isAccountTypeExists(account))
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    var sql = "insert into account values(@aid,@atype,@balance,@opening,@cid,@status)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@aid", account.Account_id);
                    cmd.Parameters.AddWithValue("@atype", account.Account_type);
                    cmd.Parameters.AddWithValue("@balance", account.Balance);
                    cmd.Parameters.AddWithValue("@opening", account.Date_Opened);
                    cmd.Parameters.AddWithValue("@cid", account.customer_id);
                    cmd.Parameters.AddWithValue("@status", 1);
                    cmd.ExecuteNonQuery();
                }
               

            }
           finally
            {
                connection.Close();
            }
            return true;
        }

        public bool isAccountTypeExists(Account account)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            int id = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand("select account_id from account where account_type=@atype and customer_id=@cid", connection))
                {
                    cmd.Parameters.AddWithValue("@atype", account.Account_type);
                    cmd.Parameters.AddWithValue("@cid", account.customer_id);
                    id = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();
                   
                }
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            if (id == 0) return false;
            throw new Exception("This account type already exixts");
        }

        public bool isAccountTypeExists(int aid,int cid)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            try
            {
                using (SqlCommand cmd = new SqlCommand("select account_id from account where account_id=@aid and customer_id=@cid", connection))
                {
                    cmd.Parameters.AddWithValue("@aid", aid);
                    cmd.Parameters.AddWithValue("@cid", cid);
                    var id = cmd.ExecuteScalar();
                    connection.Close();
                    if (id == null)
                        throw new Exception("Customer-Account combination does not exists");
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
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                var sql = "select count(*) from account";
                SqlCommand cmd = new SqlCommand(sql, connection);
                id = Convert.ToInt32(cmd.ExecuteScalar());

            }
            
            finally
            {
                connection.Close();
            }
            return id;
        }

        public bool CloseOrReopenAccount(int account_int, string status)
        {
            
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                if (status.Equals("close"))
                {
                    using (SqlCommand cmd = new SqlCommand("update account set account_status=0 where account_id=" + account_int, connection))
                    {
                        cmd.ExecuteNonQuery();

                    }
                }
                else if (status.Equals("reopen"))
                {
                    using (SqlCommand cmd = new SqlCommand("update account set account_status=1 where account_id=" + account_int, connection))
                    {
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return true;
        }
        public DataTable getAccountDetails(int id)
        {
            DataTable _datatable = new DataTable();
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from account where account_id=" + id, connection))
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
                using (SqlCommand cmd = new SqlCommand("select * from account where customer_id=" + id, connection))
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

        public string getAccountType(int aid)
        {
            string type = "";
            try
            {

                connection = new SqlConnection(connectionString);
                connection.Open();
                var sql = "select account_type from account where account_id=" + aid;
                SqlCommand cmd = new SqlCommand(sql, connection);
                type = cmd.ExecuteScalar().ToString();

            }
           
            finally
            {
                connection.Close();
            }
            return type;

        }

        public double getAccountBalance(int cid, int aid)
        {
            double balance = 0.0f;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                var sql = "select balance from account where account_id=" + aid + " and customer_id=" + cid;
                SqlCommand cmd = new SqlCommand(sql, connection);
                balance = Convert.ToDouble(cmd.ExecuteScalar());
                if (balance == 0)
                {
                    throw new Exception("Customer-account combination is wrong");
                }

            }
           
            finally
            {
                connection.Close();
            }
            return balance;
        }

        public double getAccountBalanceById(int aid)
        {
            double balance = 0.0f;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                var sql = "select balance from account where account_id=" + aid;
                SqlCommand cmd = new SqlCommand(sql, connection);
                balance = Convert.ToDouble(cmd.ExecuteScalar());
                if (balance == 0)
                {
                    throw new Exception("Account Does not exists.");
                }

            }
           finally
            {
                connection.Close();
            }
            return balance;
        }

        public int isOpen(int aid)
        {
            int status = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                using(SqlCommand cmd=new SqlCommand("select account_status from account where account_id=" + aid, connection))
                {
                    status = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return status;
        }
        public bool AccountDeposit(int cid, int aid, double amount)
        {
            
            try
            {
                connection = new SqlConnection(connectionString);

                if (isAccountTypeExists(aid, cid))
                {
                    if (isOpen(aid) == 1)
                    {

                        string account_type = getAccountType(aid);
                        double balance = getAccountBalance(cid, aid);
                        if (balance == 0) return false;

                        if (account_type.Equals("Chequing            "))
                        {

                            balance += amount;
                        }
                        else if (account_type.Equals("Taxfree             "))
                        {
                            if (balance + amount < 5000)
                            {

                                balance += amount;
                            }
                            else
                            {
                                throw new Exception("Can not exceed Max Limit of $5000");

                            }
                        }

                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand("update account set balance=@b where account_id=@id", connection))
                        {
                            cmd.Parameters.AddWithValue("@b", balance);
                            cmd.Parameters.AddWithValue("@id", aid);
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("insert into accountLogs values(@aid,@mode,@amount,@datetime)", connection))
                        {
                            cmd.Parameters.AddWithValue("@aid", aid);
                            cmd.Parameters.AddWithValue("@mode", "Deposit");
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("@datetime", DateAndTime.Now);
                            cmd.ExecuteNonQuery();

                        }
                    }
                    else
                    {
                        throw new Exception("Account is closed");
                    }
                }
                
            }

            finally
            {
                connection.Close();
                connection.Dispose();
            }
            
            return true;
        }

        public bool AccountWithdraw(int cid, int aid, double amount)
        {
            try
            {
                if (isAccountTypeExists(aid, cid))
                {
                    if (isOpen(aid) == 1)
                    {
                        connection = new SqlConnection(connectionString);
                        double balance = getAccountBalance(cid, aid);
                        if (balance == 0) return false;
                        if ((balance - amount) > 500)
                        {
                            balance -= amount;
                        }
                        else
                        {
                            throw new Exception("Not appropriate balance\nRemianing balance is =" + balance.ToString());

                        }

                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand("update account set balance=@b where account_id=@id", connection))
                        {
                            cmd.Parameters.AddWithValue("@b", balance);
                            cmd.Parameters.AddWithValue("@id", aid);
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand("insert into accountLogs values(@aid,@mode,@amount,@datetime)", connection))
                        {
                            cmd.Parameters.AddWithValue("@aid", aid);
                            cmd.Parameters.AddWithValue("@mode", "Withdraw");
                            cmd.Parameters.AddWithValue("@amount", amount);
                            cmd.Parameters.AddWithValue("@datetime", DateAndTime.Now);
                            cmd.ExecuteNonQuery();

                        }
                    }
                }
            }

            finally
            {
                connection.Close();
                connection.Dispose();
            }
          
            return true;

        }

        public bool AddGeneralAccount(Bank bank)
        {
            try
            {
                
                if (!isGeneralAccountExists())
                {

                    string connectionString = "Data Source=.;Initial Catalog='ApteanEdgeBank';Integrated Security=True";
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    var sql = "insert into bank values(@name,@code,@id,@balance,@type)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@name", bank.getName());
                    cmd.Parameters.AddWithValue("@type", bank.getAccountType());
                    cmd.Parameters.AddWithValue("@code", bank.geCode());
                    cmd.Parameters.AddWithValue("@id", bank.getAccountId());
                    cmd.Parameters.AddWithValue("@balance", bank.getBalance());
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("Cannot create more than one General account");
                   
                }

            }
           finally
            {
                connection.Close();
            }
            return true;
        }

        public bool isGeneralAccountExists()
        {
            try {
               
                connection = new SqlConnection(connectionString);
                connection.Open();
            int count = 0;
            
                using (SqlCommand cmd = new SqlCommand("select count(*) from bank", connection))
                {

                    count = Convert.ToInt32(cmd.ExecuteScalar());
                    connection.Close();
                    if (count > 0)
                    {
                        return true;
                    }
                }
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return false ;
        }

        public DataTable getAccountLogs(int aid)
        {
            DataTable _datatable = new DataTable();
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from accountLogs where account_id=" + aid+" order by datetime desc", connection))
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

        public DataTable getAllAccountLogs()
        {
            DataTable _datatable = new DataTable();
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select * from accountLogs order by account_id", connection))
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

        public List<Account> getAllAccountsOfCustomerList(int id)
        {
            List<Account> accounts = new List<Account>();
            try
            {
               
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from account where customer_id=@_id", connection);
                cmd.Parameters.AddWithValue("@_id", id);
                using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        accounts.Add(new Account
                        {
                            Account_id = dr.GetInt32(dr.GetOrdinal("account_id")),
                            Account_type = dr.GetString(dr.GetOrdinal("account_type")),
                            
                        });
                    }
                }
                connection.Close();
                connection.Dispose();
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return accounts;
        }
        #endregion
    }
}

using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApteanEdgeBank_Final
{
    public class DBCustomerLayer
    {
        #region Members
        public SqlConnection connection = null;
        string connectionString = null;
        #endregion

        #region Constructor
        public DBCustomerLayer()
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
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Methods
        public bool user_login(string textBox1, string textBox2)
        {
            int flag = 0;

            SqlCommand command;
            string sql = null;
            SqlDataReader dataReader;



            sql = "Select * from user_info";
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    if (textBox1 == dataReader.GetValue(0).ToString().Trim() && textBox2 == dataReader.GetValue(1).ToString().Trim())
                    {
                        
                        flag = 1;
                        break;
                    }
                }
               
                dataReader.Close();
                command.Dispose();
                connection.Close();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            if (flag == 0) return false;
            return true;
        }

        public bool AddCustomer(Customer customer)
        {
            try
            {
                connection.Open();
                var sql = "insert into customer values(@v1,@v2,@v3)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@v1", customer.getCustomerId());
                cmd.Parameters.AddWithValue("@v2", customer.getCustomerName());
                cmd.Parameters.AddWithValue("@v3", customer.getCustomerDateOfJoining());
                cmd.ExecuteNonQuery();

            }
           finally
            {
                connection.Close();
            }
            return true;
        }

        public object getNextCustomerId()
        {
            int id = 0;
            try
            {
                connection.Open();
                var sql = "select count(*) from customer";
                SqlCommand cmd = new SqlCommand(sql, connection);
               id = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return id;

        }
        public void closeConnection()
        {
            connection.Close();
            connection.Dispose();
        }
       

        private ObservableCollection<Customer> _selectedCustomer = new ObservableCollection<Customer>();
        public ObservableCollection<Customer> getCustomerDetails(int _id)
        {

           
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select * from customer where id=@_id", connection);
                cmd.Parameters.AddWithValue("@_id", _id);
                using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        _selectedCustomer.Add(new Customer
                        {
                            Customer_id = dr.GetInt32(dr.GetOrdinal("id")),
                            Customer_name = dr.GetString(dr.GetOrdinal("name")),
                            dateOfJoining = dr.GetDateTime(dr.GetOrdinal("doj"))
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

            return _selectedCustomer;
        }

        public bool updateCustomer(int id,string name,DateTime doj)
        {
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("update customer set name=@name, doj=@doj where id=@id",connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@doj", doj);
                cmd.ExecuteNonQuery();

            }
           finally
            {
                connection.Close();
                connection.Dispose();
            }
            return true;
        }
        #endregion
    }
}

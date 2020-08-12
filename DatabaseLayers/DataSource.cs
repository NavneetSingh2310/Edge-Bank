using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApteanEdgeBank_Final
{
    
   public class DataSource
    {
        #region Members
        public static SqlConnection connection = null;
        string connectionString = null;
        private DataSet _dataSet;
        #endregion

        #region Constructor
        public DataSource()
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
            try
            {
                connection.Open();
                _dataSet = new DataSet();

                var cda = new SqlDataAdapter("Select * from customer", connection);
                cda.Fill(_dataSet, "customer");

            }
          
            finally
            {
                connection.Close();
            }
           
        }
        #endregion

        #region Methods

        public DataTable getCustomer()
        {
            var table = _dataSet.Tables["customer"];
            return table;
        }
        #endregion
    }
}

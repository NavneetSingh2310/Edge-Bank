using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntities;
using BusinessLayer;

namespace ApteanEdgeBank_Final
{
  
    public partial class CreateAccount : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CreateAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessHandler db = new BusinessHandler();
                int cust_id = int.Parse(numericUpDown1.Text);
                int account_id = db.getAccountId() + 1;
                double balance = double.Parse(numericUpDown3.Text);
                string account_type = getAccountType(comboBox1.Text);
                DateTime doopening = dateTimePicker1.Value;
                if (account_type.Equals("Taxfree") && balance > 5000)
                {
                    MessageBox.Show("For taxfree account type maximum balance limit is 5000");
                    return;
                }
                Account account = new Account(cust_id, account_id, doopening, account_type, balance);
                bool isSuccess = db.AddAccountToDatabase(account);
                if (isSuccess)
                {
                    MessageBox.Show("Account added");
                    numericUpDown1.Value = 0;
                    numericUpDown3.Value = 500;
                    comboBox1.Text = "";
                }
                numericUpDown1.Value = 0;
                numericUpDown3.Value = 500;
                comboBox1.Text =comboBox1.Text;
                int id = db.getAccountId() + 1;
                textBox1.Text = id.ToString();
                log.Error("Get account id ended");
                log.Error("Add account to db ended");
            }
            catch(SqlException ex)
            {
                 if (ex.Number == 547)
                {
                    log.Error(ex.Message);
                    MessageBox.Show("No such customer exist");
                }
                else
                {
                    log.Error(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }

        }
        

       public string getAccountType(string type)
        {
            switch (type)
            {
                case "Chequing Account": return "Chequing";
                case "Taxfree Account": return "Taxfree";
              
                    
            }
            return null;
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            try
            {
                BusinessHandler db = new BusinessHandler();
                int id = db.getAccountId() + 1;
                textBox1.Text = id.ToString();
                comboBox1.SelectedIndex = 0;
                log.Error("Get account id ended");
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}

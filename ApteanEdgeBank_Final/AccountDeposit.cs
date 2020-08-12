using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntities;



namespace ApteanEdgeBank_Final
{
    public partial class AccountDeposit : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AccountDeposit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.BusinessHandler db = new BusinessLayer.BusinessHandler();
                int customer_id = int.Parse(numericUpDown1.Text);
                comboBox1.DisplayMember = "Value";
                comboBox1.ValueMember = "Key";
                string value = (((KeyValuePair<int, string>)comboBox1.SelectedItem).Value);
                string[] input = value.Split('-');
                int account_id = int.Parse(input[0].Trim());
                double amount = double.Parse(numericUpDown3.Text);

                bool isSuccess = db.AccountDeposit(customer_id, account_id, amount);
                if (isSuccess)
                {
                    MessageBox.Show("Deposited");
                    numericUpDown1.Value = numericUpDown1.Minimum;
                   
                    numericUpDown3.Value = numericUpDown3.Minimum;
                }
                numericUpDown3.Value = numericUpDown3.Minimum;
                log.Info("Account Deposit ended");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
                
            }
        }

        private void AccountDeposit_Load(object sender, EventArgs e)
        {
           
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.BusinessHandler db = new BusinessLayer.BusinessHandler();
                List<Account> list = new List<Account>();


                list = db.getAllAccountsOfCustomerList(int.Parse(numericUpDown1.Text));
                if (list.Count == 0) { throw new Exception("No accounts linked to this customer"); }
                else
                {
                    Dictionary<int, string> item = new Dictionary<int, string>();
                    foreach (var account in list)
                    {
                        item.Add(account.Account_id, $"{account.Account_id}-{account.Account_type}".Trim());
                    }
                    comboBox1.DataSource = new BindingSource(item, null);
                    comboBox1.DisplayMember = "Value";
                    comboBox1.ValueMember = "Key";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

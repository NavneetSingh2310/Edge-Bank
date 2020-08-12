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
using BusinessLayer;
using Microsoft.VisualBasic.Logging;

namespace ApteanEdgeBank_Final
{
    public partial class AddCustomer : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AddCustomer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int cust_id = int.Parse(textBox1.Text);
                string cust_Name = textBox2.Text;
                DateTime date = dateTimePicker1.Value;
                Customer customer = new Customer(cust_id, cust_Name, date);
                BusinessHandler db = new BusinessHandler();
                bool isSuccessful = db.AddCustomer(customer);
                if (isSuccessful)
                {
                    MessageBox.Show("Customer Added Successfully");
                    textBox1.Clear();
                    textBox2.Clear();

                }
                log.Info("Add customer ended");

            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
            
        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            try
            {


                BusinessHandler db = new BusinessHandler();
                int id = Convert.ToInt32(db.getNextCustomerId());
                id++;
                textBox1.Text = id.ToString();
                log.Info("Get next customer id ended");
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddCustomer_Load(sender, e);
        }
    }
}

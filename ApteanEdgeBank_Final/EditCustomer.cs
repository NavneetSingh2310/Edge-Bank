using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace ApteanEdgeBank_Final
{
    public partial class EditCustomer : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public EditCustomer()
        {
            InitializeComponent();
        }

        private ObservableCollection<Customer> _selectedCustomer = new ObservableCollection<Customer>();
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessHandler db = new BusinessHandler();
               
                _selectedCustomer = db.getCustomerDetails(int.Parse(numericUpDown1.Text));
                if (_selectedCustomer.Count == 0)
                {
                    MessageBox.Show("No customer with corresponding id found.");
                    numericUpDown1.Value = 0;
                    textBox2.Clear();
                }
                else
                {

                    foreach (var c in _selectedCustomer)
                    {

                        textBox2.Text = c.Customer_name;
                        dateTimePicker1.Text = c.dateOfJoining.ToString();
                    }
                }
                log.Error("Get customer details ended");

            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateCustomer ucform = new UpdateCustomer(int.Parse(numericUpDown1.Text), textBox2.Text, dateTimePicker1.Value);
                ucform.Show();
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}

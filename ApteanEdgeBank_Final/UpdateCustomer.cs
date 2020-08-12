using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
namespace ApteanEdgeBank_Final
{
    public partial class UpdateCustomer : Form
    {
        private int id;
        private string name;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private DateTime doj;
        public UpdateCustomer(int id,string name,DateTime doj)
        {
            this.id = id;
            this.name = name;
            this.doj = doj;
            InitializeComponent();
        }

        private void UpdateCustomer_Load(object sender, EventArgs e)
        {
            textBox1.Text = id.ToString();
            textBox2.Text = name.Trim();
            dateTimePicker1.Text = doj.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BusinessHandler db = new BusinessHandler();
            bool isSuccess = db.updateCustomer(int.Parse(textBox1.Text), textBox2.Text,dateTimePicker1.Value);
            if (isSuccess)
            {
                MessageBox.Show("Customer details updated");
            }
            else
            {
                MessageBox.Show("Not updated");
            }
            log.Error("Update customer completed");
        }
    }
}

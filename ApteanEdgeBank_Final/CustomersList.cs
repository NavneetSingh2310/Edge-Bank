using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApteanEdgeBank_Final
{
    public partial class CustomersList : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public CustomersList()
        {
            InitializeComponent();
            
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CustomersList_Load(object sender, EventArgs e)
        {
            try
            {
                  BindingSource _customerBindingSource = new BindingSource();
                 DataSource _dataSource = new DataSource();

                 _customerBindingSource.DataSource = _dataSource.getCustomer();
                 dataGridView1.DataSource = _customerBindingSource;
                log.Error("Get customer ended");
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}

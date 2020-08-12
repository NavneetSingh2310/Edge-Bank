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
    public partial class ViewLiabilityAccountDetails : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ViewLiabilityAccountDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.BusinessHandler db = new BusinessLayer.BusinessHandler();
                dataGridView1.DataSource = db.getLiabilityAccountDetails(int.Parse(numericUpDown1.Text));
                log.Error("Get liability account details ended");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.BusinessHandler db = new BusinessLayer.BusinessHandler();
                dataGridView1.DataSource = db.getAllLiabilityAccountsOfCustomer(int.Parse(numericUpDown2.Text));
                log.Error("Get liability account of customer ended");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}

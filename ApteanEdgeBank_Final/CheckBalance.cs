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
    public partial class CheckBalance : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CheckBalance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int account_id = int.Parse(numericUpDown1.Text);
                BusinessLayer.BusinessHandler dbAccount = new BusinessLayer.BusinessHandler();
                double balance = dbAccount.getAccountBalanceById(account_id);
                label3.Text = "₹"+balance.ToString();
                log.Error("Get account balance by id ended");
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}

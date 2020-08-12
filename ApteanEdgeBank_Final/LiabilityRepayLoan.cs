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
    public partial class LiabilityRepayLoan : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LiabilityRepayLoan()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.BusinessHandler db = new BusinessLayer.BusinessHandler();
                int id = db.getLiabilityAccountIdByCustomerId(int.Parse(numericUpDown1.Text));
                if (id == 0)
                {
                    MessageBox.Show("No liability account linked to this customer");
                }
                else
                {
                    textBox1.Text = id.ToString();
                }
                log.Error("Get liability account by customer id completed");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.BusinessHandler db = new BusinessLayer.BusinessHandler();
                bool isSuccess = db.RepayLoan(int.Parse(textBox1.Text), double.Parse(numericUpDown2.Text));
                if (isSuccess)
                {
                    MessageBox.Show("Repayment Soccessfull");
                }
                log.Error("Repy loan ended");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                textBox1.Clear();
                numericUpDown2.Value = numericUpDown2.Minimum;
                numericUpDown1.Value = 0;
            }
        }
    }
}

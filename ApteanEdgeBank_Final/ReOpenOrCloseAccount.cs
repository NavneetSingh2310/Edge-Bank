using BusinessEntities;
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
    public partial class ReOpenOrCloseAccount : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ReOpenOrCloseAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.BusinessHandler db = new BusinessLayer.BusinessHandler();
                int account_id = int.Parse(numericUpDown1.Text);
                if (radioButton1.Checked)
                {
                    bool isSuccess = db.CloseOrReopenAccount(account_id, "close");
                    if (isSuccess)
                    {
                        log.Error("Account closed");
                        MessageBox.Show("Account Closed");
                    }
                }
                else if (radioButton2.Checked)
                {
                    bool isSuccess = db.CloseOrReopenAccount(account_id, "reopen");
                    if (isSuccess)
                    {
                        log.Error("Account re-open");
                        MessageBox.Show("Account re-open");
                    }
                }
                else
                {
                    
                    MessageBox.Show("Select option");
                }
                log.Error("Close or reopen account ended");

            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);

            }
        }
    }
}

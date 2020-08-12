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
   

    public partial class ViewAndUpdateBankAccountBalance : Form
    { private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ViewAndUpdateBankAccountBalance()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.BusinessHandler db = new BusinessLayer.BusinessHandler();
                if (textBox1.Text==string.Empty && textBox4.Text==string.Empty)
                    throw new Exception("All Fields Required");
                else
                {
                    if (radioButton1.Checked)
                    {
                        db.updateGeneralAccount(double.Parse(numericUpDown1.Text), 'd');
                        MessageBox.Show("Deposited");
                        db = new BusinessLayer.BusinessHandler();
                        textBox1.Text = db.getGeneralAccountBalance().ToString();
                        log.Error("Update general account balance ended");
                        log.Error("Update general account ended");
                    }
                    else if (radioButton2.Checked)
                    {
                        db.updateGeneralAccount(double.Parse(numericUpDown1.Text), 'w');
                        MessageBox.Show("Withdrawn");
                        db = new BusinessLayer.BusinessHandler();
                        textBox1.Text = db.getGeneralAccountBalance().ToString();
                        log.Error("Update general account balance ended");
                        log.Error("Update general account ended");
                    }
                    else
                    {
                        MessageBox.Show("Select Option");
                        db = new BusinessLayer.BusinessHandler();
                        textBox1.Text = db.getGeneralAccountBalance().ToString();
                        log.Error("Update general account balance ended");
                    }
                }
               

            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void ViewAndUpdateBankAccountBalance_Load(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.BusinessHandler db = new BusinessLayer.BusinessHandler();
                textBox1.Text = db.getGeneralAccountBalance().ToString();
                textBox4.Text = db.getGeneralAccountId().ToString();
                log.Error("Update general account balance ended");
                log.Error("Update general account id ended");
            }
            catch(Exception ex)
            {
                
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
                this.Close();

            }
        }
    }
}

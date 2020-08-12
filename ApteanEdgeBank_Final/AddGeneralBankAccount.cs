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
    public partial class AddGeneralBankAccount : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AddGeneralBankAccount()
        {
            InitializeComponent();
        }

        private void AddGeneralBankAccount_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text==string.Empty)
                {
                    throw new Exception("IFSC can not be null");
                }

                BusinessLayer.BusinessHandler db = new BusinessLayer.BusinessHandler();
                Bank bank = new Bank(int.Parse(numericUpDown2.Text), textBox4.Text, double.Parse(numericUpDown1.Text));
                bool isSucess = db.AddGeneralAccount(bank);
                if (isSucess)
                {
                    MessageBox.Show("Bank General Account Created");
                }
                log.Error("Add general account ended");
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}

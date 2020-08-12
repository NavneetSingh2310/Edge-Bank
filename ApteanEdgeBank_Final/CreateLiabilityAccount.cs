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
    public partial class CreateLiabilityAccount : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CreateLiabilityAccount()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               BusinessLayer.BusinessHandler db = new BusinessLayer.BusinessHandler();
                int account_id = db.getAccountId() + 1;
                Liability account = new Liability(int.Parse(textBox1.Text), int.Parse(numericUpDown1.Text), "liability", double.Parse(numericUpDown2.Text));

                bool isSuccess = db.AddLiabilityAccountToDB(account);

                if (isSuccess)
                {
                    MessageBox.Show("Liability Account Created");
                }
                log.Error("Add liability account to db completed");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

        private void CreateLiabilityAccount_Load(object sender, EventArgs e)
        {
            try
            {
                BusinessLayer.BusinessHandler db = new BusinessLayer.BusinessHandler();
                int account_id = db.getLiabilityAccountId() + 1;
                textBox1.Text = account_id.ToString();
                log.Error("Get liability account id completed");
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}

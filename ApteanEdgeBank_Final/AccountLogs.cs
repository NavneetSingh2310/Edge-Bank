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
    public partial class AccountLogs : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AccountLogs()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AccountLogs_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                BusinessLayer.BusinessHandler db = new BusinessLayer.BusinessHandler();
                dataGridView1.DataSource = db.getAccountLogs(int.Parse(numericUpDown1.Text));
                log.Info("Get account logs ended");
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}

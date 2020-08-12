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
    public partial class ViewAllAccountLogs : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ViewAllAccountLogs()
        {
            InitializeComponent();
        }

        private void ViewAllAccountLogs_Load(object sender, EventArgs e)
        {
            try
            {
               BusinessLayer.BusinessHandler db = new BusinessLayer.BusinessHandler();
                dataGridView1.DataSource = db.getAllAccountLogs();
                log.Error("Get all account logs ended");
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }

        }
    }
}

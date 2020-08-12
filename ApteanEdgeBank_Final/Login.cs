using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace ApteanEdgeBank_Final
{
    public partial class Login : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BusinessHandler db = new BusinessHandler();
                bool isSucessfull = db.user_login(textBox1.Text, textBox2.Text);
                if (isSucessfull == true)
                {
                    MessageBox.Show("Loged in");
                    HomePage homepage = new HomePage();
                    homepage.Show();
                    this.Hide();

                }
                else
                {
                    log.Error("Username password combination is wrong");
                    MessageBox.Show("Username password combination is wrong");
                }
                log.Error("Login ended");
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.ToString());
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Contact your Manager or Administrator or IT Cell");
        }
    }
}

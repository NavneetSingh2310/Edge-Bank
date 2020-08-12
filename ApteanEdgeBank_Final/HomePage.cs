using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApteanEdgeBank_Final
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string selected = e.Node.Text;
            switch (selected)
            {
                case "Create customer":
                    (new AddCustomer()).ShowDialog();
                    break;
                case "List all customers":(new CustomersList()).ShowDialog();
                    break;
                case "View and Edit customer":(new EditCustomer()).ShowDialog();
                    break;
                case "Create account":(new CreateAccount()).ShowDialog();
                    break;

                case "View account details":
                    (new ViewAccountDetails()).ShowDialog(); ;
                    
                    break;
                case "Close account":
                    (new ReOpenOrCloseAccount()).ShowDialog();
                    break;
                case "Reopen account":
                    (new ReOpenOrCloseAccount()).ShowDialog();
                    break;
                case "Create liability account":
                    (new CreateLiabilityAccount()).ShowDialog();
                    break;
                case "View liability account details":
                    (new ViewLiabilityAccountDetails()).ShowDialog();
                    break;
                case "Loan":
                    (new Liability_Loan()).ShowDialog();
                    break;
                case "Repay loan":
                    (new LiabilityRepayLoan()).ShowDialog();
                    break;
                case "Add Account":
                    (new AddGeneralBankAccount()).ShowDialog();
                    break;
                case "Update balance":
                    (new ViewAndUpdateBankAccountBalance()).ShowDialog();
                    break;
                case "Particular Account logs":
                    (new AccountLogs()).ShowDialog();
                    break;
                case "Check balance":
                    (new CheckBalance()).ShowDialog();
                    break;
                case "Deposit":
                    (new AccountDeposit()).ShowDialog();
                    break;
                case "Withdraw":
                    (new AccountWithdraw()).ShowDialog();
                    break;
                case "View General Account":(new viewGeneralAccount()).ShowDialog();
                    break;
                case "View All Account Logs":(new ViewAllAccountLogs()).ShowDialog();
                    break;
                    





            }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

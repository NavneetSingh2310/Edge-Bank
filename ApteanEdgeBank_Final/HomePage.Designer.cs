namespace ApteanEdgeBank_Final
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Home");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Create customer");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("List all customers");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("View and Edit customer");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Customer Management", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Create account");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("View account details");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Close account");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Reopen account");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Deposit");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Withdraw");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Account Management", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Create liability account");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("View liability account details");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Loan");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Repay loan");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Liability Account Management", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("View General Account");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Add Account");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Update balance");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("General Bank Account Management", new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19,
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Particular Account logs");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("View All Account Logs");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Check balance");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Activity Ledger", new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode23,
            treeNode24});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1145, 595);
            this.splitContainer1.SplitterDistance = 381;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.SystemColors.Window;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.ForeColor = System.Drawing.Color.Black;
            treeNode1.Name = "Node0";
            treeNode1.Text = "Home";
            treeNode2.Name = "Node5";
            treeNode2.Text = "Create customer";
            treeNode3.Name = "Node6";
            treeNode3.Text = "List all customers";
            treeNode4.Name = "Node7";
            treeNode4.Text = "View and Edit customer";
            treeNode5.Name = "Node3";
            treeNode5.Text = "Customer Management";
            treeNode6.Name = "Node9";
            treeNode6.Text = "Create account";
            treeNode7.Name = "Node11";
            treeNode7.Text = "View account details";
            treeNode8.Name = "Node12";
            treeNode8.Text = "Close account";
            treeNode9.Name = "Node13";
            treeNode9.Text = "Reopen account";
            treeNode10.Name = "Node0";
            treeNode10.Text = "Deposit";
            treeNode11.Name = "Node1";
            treeNode11.Text = "Withdraw";
            treeNode12.Name = "Node8";
            treeNode12.Text = "Account Management";
            treeNode13.Name = "Node15";
            treeNode13.Text = "Create liability account";
            treeNode14.Name = "Node1";
            treeNode14.Text = "View liability account details";
            treeNode15.Name = "Node16";
            treeNode15.Text = "Loan";
            treeNode16.Name = "Node17";
            treeNode16.Text = "Repay loan";
            treeNode17.Name = "Node14";
            treeNode17.Text = "Liability Account Management";
            treeNode18.Name = "Node0";
            treeNode18.Text = "View General Account";
            treeNode19.Name = "Node19";
            treeNode19.Text = "Add Account";
            treeNode20.Name = "Node25";
            treeNode20.Text = "Update balance";
            treeNode21.Name = "Node18";
            treeNode21.Text = "General Bank Account Management";
            treeNode22.Name = "Node22";
            treeNode22.Text = "Particular Account logs";
            treeNode23.Name = "Node1";
            treeNode23.Text = "View All Account Logs";
            treeNode24.Name = "Node23";
            treeNode24.Text = "Check balance";
            treeNode25.Name = "Node21";
            treeNode25.Text = "Activity Ledger";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode5,
            treeNode12,
            treeNode17,
            treeNode21,
            treeNode25});
            this.treeView1.Size = new System.Drawing.Size(381, 595);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 328);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bank Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Bank Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(303, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "AEB146023";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(303, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(216, 25);
            this.label8.TabIndex = 9;
            this.label8.Text = "Rajaji Nagar, Bengaluru";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(303, 125);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(248, 25);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.apteanedgebank.com";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bank Url:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Bank Location";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "IFSC Code:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(303, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Aptean Edge Bank";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(194, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(540, 68);
            this.label1.TabIndex = 2;
            this.label1.Text = "Aptean Edge Bank";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(30, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 595);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HomePage";
            this.Text = "Welcome to Aptean Edge Bank";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
    }
}
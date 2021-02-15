namespace OutlawHessDB
{
    partial class CustomerTransactionFrom
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
            this.lbxCustomer = new System.Windows.Forms.ListBox();
            this.lbxAccounts = new System.Windows.Forms.ListBox();
            this.lbxTransactions = new System.Windows.Forms.ListBox();
            this.btnCustTransactions = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.tssImageConnStatus = new System.Windows.Forms.ToolStrip();
            this.SuspendLayout();
            // 
            // lbxCustomer
            // 
            this.lbxCustomer.FormattingEnabled = true;
            this.lbxCustomer.Location = new System.Drawing.Point(13, 13);
            this.lbxCustomer.Name = "lbxCustomer";
            this.lbxCustomer.Size = new System.Drawing.Size(200, 420);
            this.lbxCustomer.TabIndex = 0;
            this.lbxCustomer.Click += new System.EventHandler(this.lbxCustomer_Click);
            // 
            // lbxAccounts
            // 
            this.lbxAccounts.FormattingEnabled = true;
            this.lbxAccounts.Location = new System.Drawing.Point(219, 12);
            this.lbxAccounts.Name = "lbxAccounts";
            this.lbxAccounts.Size = new System.Drawing.Size(200, 420);
            this.lbxAccounts.TabIndex = 1;
            this.lbxAccounts.Click += new System.EventHandler(this.lbxAccounts_Click);
            // 
            // lbxTransactions
            // 
            this.lbxTransactions.FormattingEnabled = true;
            this.lbxTransactions.Location = new System.Drawing.Point(425, 12);
            this.lbxTransactions.Name = "lbxTransactions";
            this.lbxTransactions.Size = new System.Drawing.Size(400, 420);
            this.lbxTransactions.TabIndex = 2;
            // 
            // btnCustTransactions
            // 
            this.btnCustTransactions.Location = new System.Drawing.Point(846, 12);
            this.btnCustTransactions.Name = "btnCustTransactions";
            this.btnCustTransactions.Size = new System.Drawing.Size(82, 38);
            this.btnCustTransactions.TabIndex = 21;
            this.btnCustTransactions.Text = "Back";
            this.btnCustTransactions.UseVisualStyleBackColor = true;
            this.btnCustTransactions.Click += new System.EventHandler(this.btnCustTransactions_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(846, 56);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(82, 38);
            this.btnMainMenu.TabIndex = 22;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // tssImageConnStatus
            // 
            this.tssImageConnStatus.AutoSize = false;
            this.tssImageConnStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tssImageConnStatus.Dock = System.Windows.Forms.DockStyle.None;
            this.tssImageConnStatus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tssImageConnStatus.Location = new System.Drawing.Point(892, 405);
            this.tssImageConnStatus.Name = "tssImageConnStatus";
            this.tssImageConnStatus.Size = new System.Drawing.Size(39, 36);
            this.tssImageConnStatus.Stretch = true;
            this.tssImageConnStatus.TabIndex = 24;
            this.tssImageConnStatus.Text = "toolStrip1";
            // 
            // CustomerTransactionFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 450);
            this.Controls.Add(this.tssImageConnStatus);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnCustTransactions);
            this.Controls.Add(this.lbxTransactions);
            this.Controls.Add(this.lbxAccounts);
            this.Controls.Add(this.lbxCustomer);
            this.Name = "CustomerTransactionFrom";
            this.Text = "CustomerTransactionFrom";
            this.Load += new System.EventHandler(this.CustomerTransactionFrom_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxCustomer;
        private System.Windows.Forms.ListBox lbxAccounts;
        private System.Windows.Forms.ListBox lbxTransactions;
        private System.Windows.Forms.Button btnCustTransactions;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.ToolStrip tssImageConnStatus;
    }
}
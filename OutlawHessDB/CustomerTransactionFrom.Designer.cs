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
            this.button1 = new System.Windows.Forms.Button();
            this.tssImageConnStatus = new System.Windows.Forms.ToolStrip();
            this.SuspendLayout();
            // 
            // lbxCustomer
            // 
            this.lbxCustomer.FormattingEnabled = true;
            this.lbxCustomer.Location = new System.Drawing.Point(13, 13);
            this.lbxCustomer.Name = "lbxCustomer";
            this.lbxCustomer.Size = new System.Drawing.Size(188, 420);
            this.lbxCustomer.TabIndex = 0;
            // 
            // lbxAccounts
            // 
            this.lbxAccounts.FormattingEnabled = true;
            this.lbxAccounts.Location = new System.Drawing.Point(207, 13);
            this.lbxAccounts.Name = "lbxAccounts";
            this.lbxAccounts.Size = new System.Drawing.Size(188, 420);
            this.lbxAccounts.TabIndex = 1;
            // 
            // lbxTransactions
            // 
            this.lbxTransactions.FormattingEnabled = true;
            this.lbxTransactions.Location = new System.Drawing.Point(401, 13);
            this.lbxTransactions.Name = "lbxTransactions";
            this.lbxTransactions.Size = new System.Drawing.Size(430, 420);
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
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(846, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 38);
            this.button1.TabIndex = 22;
            this.button1.Text = "Main Menu";
            this.button1.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip tssImageConnStatus;
    }
}
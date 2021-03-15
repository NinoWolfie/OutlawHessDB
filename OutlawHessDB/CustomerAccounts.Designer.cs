namespace OutlawHessDB
{
    partial class CustomerAccounts
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
            this.lblCustAccount = new System.Windows.Forms.Label();
            this.lbxCustAccounts = new System.Windows.Forms.ListBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.tssImageConnStatus = new System.Windows.Forms.ToolStrip();
            this.SuspendLayout();
            // 
            // lblCustAccount
            // 
            this.lblCustAccount.AutoSize = true;
            this.lblCustAccount.Location = new System.Drawing.Point(13, 13);
            this.lblCustAccount.Name = "lblCustAccount";
            this.lblCustAccount.Size = new System.Drawing.Size(99, 13);
            this.lblCustAccount.TabIndex = 0;
            this.lblCustAccount.Text = "Customer Accounts";
            // 
            // lbxCustAccounts
            // 
            this.lbxCustAccounts.FormattingEnabled = true;
            this.lbxCustAccounts.Location = new System.Drawing.Point(12, 41);
            this.lbxCustAccounts.Name = "lbxCustAccounts";
            this.lbxCustAccounts.Size = new System.Drawing.Size(260, 173);
            this.lbxCustAccounts.TabIndex = 1;
            this.lbxCustAccounts.Click += new System.EventHandler(this.lbxCustAccounts_Click);
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(114, 231);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(100, 20);
            this.txtBalance.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Balance:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(99, 274);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tssImageConnStatus
            // 
            this.tssImageConnStatus.AutoSize = false;
            this.tssImageConnStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tssImageConnStatus.Dock = System.Windows.Forms.DockStyle.None;
            this.tssImageConnStatus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tssImageConnStatus.Location = new System.Drawing.Point(236, 266);
            this.tssImageConnStatus.Name = "tssImageConnStatus";
            this.tssImageConnStatus.Size = new System.Drawing.Size(39, 36);
            this.tssImageConnStatus.Stretch = true;
            this.tssImageConnStatus.TabIndex = 14;
            this.tssImageConnStatus.Text = "toolStrip1";
            // 
            // CustomerAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.tssImageConnStatus);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.lbxCustAccounts);
            this.Controls.Add(this.lblCustAccount);
            this.Name = "CustomerAccounts";
            this.Text = "CustomerAccounts";
            this.Load += new System.EventHandler(this.CustomerAccounts_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustAccount;
        private System.Windows.Forms.ListBox lbxCustAccounts;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ToolStrip tssImageConnStatus;
    }
}
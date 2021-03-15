namespace OutlawHessDB
{
    partial class AllAccounts
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
            this.dgvAccounts = new System.Windows.Forms.DataGridView();
            this.tssImageConnStatus = new System.Windows.Forms.ToolStrip();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnBalAccruedCalc = new System.Windows.Forms.Button();
            this.btnAnnualInterest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAccounts
            // 
            this.dgvAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccounts.Location = new System.Drawing.Point(13, 13);
            this.dgvAccounts.MultiSelect = false;
            this.dgvAccounts.Name = "dgvAccounts";
            this.dgvAccounts.ReadOnly = true;
            this.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAccounts.Size = new System.Drawing.Size(765, 425);
            this.dgvAccounts.TabIndex = 0;
            // 
            // tssImageConnStatus
            // 
            this.tssImageConnStatus.AutoSize = false;
            this.tssImageConnStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tssImageConnStatus.Dock = System.Windows.Forms.DockStyle.None;
            this.tssImageConnStatus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tssImageConnStatus.Location = new System.Drawing.Point(876, 405);
            this.tssImageConnStatus.Name = "tssImageConnStatus";
            this.tssImageConnStatus.Size = new System.Drawing.Size(39, 36);
            this.tssImageConnStatus.Stretch = true;
            this.tssImageConnStatus.TabIndex = 15;
            this.tssImageConnStatus.Text = "toolStrip1";
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Location = new System.Drawing.Point(811, 136);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(82, 38);
            this.btnMainMenu.TabIndex = 17;
            this.btnMainMenu.Text = "Main Menu";
            this.btnMainMenu.UseVisualStyleBackColor = true;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnBalAccruedCalc
            // 
            this.btnBalAccruedCalc.Location = new System.Drawing.Point(811, 13);
            this.btnBalAccruedCalc.Name = "btnBalAccruedCalc";
            this.btnBalAccruedCalc.Size = new System.Drawing.Size(82, 61);
            this.btnBalAccruedCalc.TabIndex = 18;
            this.btnBalAccruedCalc.Text = "Overnight Accrued Balance Calculator";
            this.btnBalAccruedCalc.UseVisualStyleBackColor = true;
            this.btnBalAccruedCalc.Click += new System.EventHandler(this.btnBalAccruedCalc_Click);
            // 
            // btnAnnualInterest
            // 
            this.btnAnnualInterest.Location = new System.Drawing.Point(811, 80);
            this.btnAnnualInterest.Name = "btnAnnualInterest";
            this.btnAnnualInterest.Size = new System.Drawing.Size(82, 50);
            this.btnAnnualInterest.TabIndex = 19;
            this.btnAnnualInterest.Text = "Accrued Interest Deposit";
            this.btnAnnualInterest.UseVisualStyleBackColor = true;
            this.btnAnnualInterest.Click += new System.EventHandler(this.btnAnnualInterest_Click);
            // 
            // AllAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(924, 450);
            this.Controls.Add(this.btnAnnualInterest);
            this.Controls.Add(this.btnBalAccruedCalc);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.tssImageConnStatus);
            this.Controls.Add(this.dgvAccounts);
            this.Name = "AllAccounts";
            this.Text = "AllAccounts";
            this.Load += new System.EventHandler(this.AllAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccounts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAccounts;
        private System.Windows.Forms.ToolStrip tssImageConnStatus;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnBalAccruedCalc;
        private System.Windows.Forms.Button btnAnnualInterest;
    }
}
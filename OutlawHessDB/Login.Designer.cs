namespace OutlawHessDB
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmployeeNumber = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPasswordHelp = new System.Windows.Forms.Button();
            this.tssImageConnStatus = new System.Windows.Forms.ToolStrip();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // txtEmployeeNumber
            // 
            this.txtEmployeeNumber.Location = new System.Drawing.Point(133, 82);
            this.txtEmployeeNumber.Name = "txtEmployeeNumber";
            this.txtEmployeeNumber.Size = new System.Drawing.Size(100, 20);
            this.txtEmployeeNumber.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(133, 123);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 39);
            this.label3.TabIndex = 4;
            this.label3.Text = "Welcome to Outlaw Hess Data management system\r\n\r\nPlease log in";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(146, 158);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Having trouble logging in? Click here";
            // 
            // btnPasswordHelp
            // 
            this.btnPasswordHelp.Location = new System.Drawing.Point(133, 231);
            this.btnPasswordHelp.Name = "btnPasswordHelp";
            this.btnPasswordHelp.Size = new System.Drawing.Size(100, 23);
            this.btnPasswordHelp.TabIndex = 7;
            this.btnPasswordHelp.Text = "Password Help";
            this.btnPasswordHelp.UseVisualStyleBackColor = true;
            this.btnPasswordHelp.Click += new System.EventHandler(this.btnPasswordHelp_Click);
            // 
            // tssImageConnStatus
            // 
            this.tssImageConnStatus.AutoSize = false;
            this.tssImageConnStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tssImageConnStatus.Dock = System.Windows.Forms.DockStyle.None;
            this.tssImageConnStatus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tssImageConnStatus.Location = new System.Drawing.Point(286, 316);
            this.tssImageConnStatus.Name = "tssImageConnStatus";
            this.tssImageConnStatus.Size = new System.Drawing.Size(39, 36);
            this.tssImageConnStatus.Stretch = true;
            this.tssImageConnStatus.TabIndex = 8;
            this.tssImageConnStatus.Text = "toolStrip1";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 361);
            this.Controls.Add(this.tssImageConnStatus);
            this.Controls.Add(this.btnPasswordHelp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmployeeNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmployeeNumber;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPasswordHelp;
        private System.Windows.Forms.ToolStrip tssImageConnStatus;
    }
}
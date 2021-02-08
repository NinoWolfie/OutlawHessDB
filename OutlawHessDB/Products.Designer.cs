namespace OutlawHessDB
{
    partial class Products
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
            this.lbxProducts = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnOpen = new System.Windows.Forms.RadioButton();
            this.rbtnClosed = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tssImageConnStatus = new System.Windows.Forms.ToolStrip();
            this.txtInterestRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxProducts
            // 
            this.lbxProducts.FormattingEnabled = true;
            this.lbxProducts.Location = new System.Drawing.Point(12, 53);
            this.lbxProducts.Name = "lbxProducts";
            this.lbxProducts.Size = new System.Drawing.Size(260, 121);
            this.lbxProducts.TabIndex = 0;
            this.lbxProducts.Click += new System.EventHandler(this.lbxProducts_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Products";
            // 
            // rbtnOpen
            // 
            this.rbtnOpen.AutoSize = true;
            this.rbtnOpen.Location = new System.Drawing.Point(33, 192);
            this.rbtnOpen.Name = "rbtnOpen";
            this.rbtnOpen.Size = new System.Drawing.Size(51, 17);
            this.rbtnOpen.TabIndex = 2;
            this.rbtnOpen.TabStop = true;
            this.rbtnOpen.Text = "Open";
            this.rbtnOpen.UseVisualStyleBackColor = true;
            // 
            // rbtnClosed
            // 
            this.rbtnClosed.AutoSize = true;
            this.rbtnClosed.Location = new System.Drawing.Point(196, 192);
            this.rbtnClosed.Name = "rbtnClosed";
            this.rbtnClosed.Size = new System.Drawing.Size(57, 17);
            this.rbtnClosed.TabIndex = 3;
            this.rbtnClosed.TabStop = true;
            this.rbtnClosed.Text = "Closed";
            this.rbtnClosed.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(33, 290);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tssImageConnStatus
            // 
            this.tssImageConnStatus.AutoSize = false;
            this.tssImageConnStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tssImageConnStatus.Dock = System.Windows.Forms.DockStyle.None;
            this.tssImageConnStatus.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tssImageConnStatus.Location = new System.Drawing.Point(236, 316);
            this.tssImageConnStatus.Name = "tssImageConnStatus";
            this.tssImageConnStatus.Size = new System.Drawing.Size(39, 36);
            this.tssImageConnStatus.Stretch = true;
            this.tssImageConnStatus.TabIndex = 13;
            this.tssImageConnStatus.Text = "toolStrip1";
            // 
            // txtInterestRate
            // 
            this.txtInterestRate.Location = new System.Drawing.Point(33, 241);
            this.txtInterestRate.Name = "txtInterestRate";
            this.txtInterestRate.Size = new System.Drawing.Size(107, 20);
            this.txtInterestRate.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Interest rate";
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInterestRate);
            this.Controls.Add(this.tssImageConnStatus);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rbtnClosed);
            this.Controls.Add(this.rbtnOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxProducts);
            this.Name = "Products";
            this.Text = "Products";
            this.Load += new System.EventHandler(this.Products_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnOpen;
        private System.Windows.Forms.RadioButton rbtnClosed;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStrip tssImageConnStatus;
        private System.Windows.Forms.TextBox txtInterestRate;
        private System.Windows.Forms.Label label2;
    }
}
namespace MSAS
{
    partial class VarianceBreakdown
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
            this.txtVariance = new System.Windows.Forms.TextBox();
            this.txtTxtProb = new System.Windows.Forms.TextBox();
            this.txtUnrep = new System.Windows.Forms.TextBox();
            this.txtOtherFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtMisclass = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblComponent = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbComponent = new System.Windows.Forms.ComboBox();
            this.lblCash = new System.Windows.Forms.Label();
            this.txtGC = new System.Windows.Forms.TextBox();
            this.txtCharge = new System.Windows.Forms.TextBox();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.lblCharge = new System.Windows.Forms.Label();
            this.lblGC = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtVariance
            // 
            this.txtVariance.BackColor = System.Drawing.Color.White;
            this.txtVariance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVariance.Location = new System.Drawing.Point(141, 42);
            this.txtVariance.Margin = new System.Windows.Forms.Padding(2);
            this.txtVariance.Name = "txtVariance";
            this.txtVariance.ReadOnly = true;
            this.txtVariance.Size = new System.Drawing.Size(157, 26);
            this.txtVariance.TabIndex = 0;
            this.txtVariance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVariance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVariance_KeyPress);
            // 
            // txtTxtProb
            // 
            this.txtTxtProb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTxtProb.Location = new System.Drawing.Point(141, 75);
            this.txtTxtProb.Margin = new System.Windows.Forms.Padding(2);
            this.txtTxtProb.Name = "txtTxtProb";
            this.txtTxtProb.Size = new System.Drawing.Size(157, 26);
            this.txtTxtProb.TabIndex = 1;
            this.txtTxtProb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTxtProb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTxtProb_KeyPress);
            // 
            // txtUnrep
            // 
            this.txtUnrep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnrep.Location = new System.Drawing.Point(141, 219);
            this.txtUnrep.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnrep.Name = "txtUnrep";
            this.txtUnrep.Size = new System.Drawing.Size(157, 26);
            this.txtUnrep.TabIndex = 3;
            this.txtUnrep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnrep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnrep_KeyPress);
            // 
            // txtOtherFind
            // 
            this.txtOtherFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherFind.Location = new System.Drawing.Point(141, 248);
            this.txtOtherFind.Margin = new System.Windows.Forms.Padding(2);
            this.txtOtherFind.Name = "txtOtherFind";
            this.txtOtherFind.Size = new System.Drawing.Size(157, 26);
            this.txtOtherFind.TabIndex = 4;
            this.txtOtherFind.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOtherFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOtherFind_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 45);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Variance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Textfile Problem";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 223);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Unreported Sales";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 251);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Other Findings";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(123, 291);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(74, 41);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(186, 291);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 41);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtMisclass
            // 
            this.txtMisclass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMisclass.Location = new System.Drawing.Point(141, 105);
            this.txtMisclass.Margin = new System.Windows.Forms.Padding(2);
            this.txtMisclass.Name = "txtMisclass";
            this.txtMisclass.Size = new System.Drawing.Size(157, 26);
            this.txtMisclass.TabIndex = 2;
            this.txtMisclass.TabStop = false;
            this.txtMisclass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMisclass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMisclass_KeyPress);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(16, 7);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(59, 20);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "lblDate";
            // 
            // lblComponent
            // 
            this.lblComponent.AutoSize = true;
            this.lblComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComponent.Location = new System.Drawing.Point(196, 7);
            this.lblComponent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblComponent.Name = "lblComponent";
            this.lblComponent.Size = new System.Drawing.Size(107, 20);
            this.lblComponent.TabIndex = 8;
            this.lblComponent.Text = "lblComponent";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Misclassified:";
            // 
            // cmbComponent
            // 
            this.cmbComponent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmbComponent.FormattingEnabled = true;
            this.cmbComponent.Location = new System.Drawing.Point(39, 138);
            this.cmbComponent.Margin = new System.Windows.Forms.Padding(2);
            this.cmbComponent.Name = "cmbComponent";
            this.cmbComponent.Size = new System.Drawing.Size(36, 24);
            this.cmbComponent.TabIndex = 5;
            this.cmbComponent.Visible = false;
            // 
            // lblCash
            // 
            this.lblCash.AutoSize = true;
            this.lblCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCash.Location = new System.Drawing.Point(107, 141);
            this.lblCash.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(40, 17);
            this.lblCash.TabIndex = 10;
            this.lblCash.Text = "Cash";
            // 
            // txtGC
            // 
            this.txtGC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGC.Location = new System.Drawing.Point(156, 190);
            this.txtGC.Name = "txtGC";
            this.txtGC.Size = new System.Drawing.Size(142, 24);
            this.txtGC.TabIndex = 11;
            this.txtGC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGC_KeyPress);
            // 
            // txtCharge
            // 
            this.txtCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCharge.Location = new System.Drawing.Point(156, 163);
            this.txtCharge.Name = "txtCharge";
            this.txtCharge.Size = new System.Drawing.Size(142, 24);
            this.txtCharge.TabIndex = 12;
            this.txtCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCharge_KeyPress);
            // 
            // txtCash
            // 
            this.txtCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCash.Location = new System.Drawing.Point(156, 136);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(142, 24);
            this.txtCash.TabIndex = 13;
            this.txtCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCash_KeyPress);
            // 
            // lblCharge
            // 
            this.lblCharge.AutoSize = true;
            this.lblCharge.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCharge.Location = new System.Drawing.Point(93, 164);
            this.lblCharge.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCharge.Name = "lblCharge";
            this.lblCharge.Size = new System.Drawing.Size(54, 17);
            this.lblCharge.TabIndex = 14;
            this.lblCharge.Text = "Charge";
            // 
            // lblGC
            // 
            this.lblGC.AutoSize = true;
            this.lblGC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblGC.Location = new System.Drawing.Point(72, 195);
            this.lblGC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGC.Name = "lblGC";
            this.lblGC.Size = new System.Drawing.Size(75, 17);
            this.lblGC.TabIndex = 15;
            this.lblGC.Text = "GC/Others";
            // 
            // VarianceBreakdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 341);
            this.ControlBox = false;
            this.Controls.Add(this.lblGC);
            this.Controls.Add(this.lblCharge);
            this.Controls.Add(this.txtCash);
            this.Controls.Add(this.txtCharge);
            this.Controls.Add(this.txtGC);
            this.Controls.Add(this.lblCash);
            this.Controls.Add(this.cmbComponent);
            this.Controls.Add(this.lblComponent);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.txtMisclass);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOtherFind);
            this.Controls.Add(this.txtUnrep);
            this.Controls.Add(this.txtTxtProb);
            this.Controls.Add(this.txtVariance);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VarianceBreakdown";
            this.Text = "VarianceBreakdown";
            this.Load += new System.EventHandler(this.VarianceBreakdown_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox txtVariance;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label lblDate;
        public System.Windows.Forms.Label lblComponent;
        private System.Windows.Forms.ComboBox cmbComponent;
        private System.Windows.Forms.Label lblCash;
        public System.Windows.Forms.TextBox txtTxtProb;
        public System.Windows.Forms.TextBox txtUnrep;
        public System.Windows.Forms.TextBox txtOtherFind;
        public System.Windows.Forms.TextBox txtMisclass;
        private System.Windows.Forms.TextBox txtGC;
        private System.Windows.Forms.TextBox txtCharge;
        private System.Windows.Forms.TextBox txtCash;
        private System.Windows.Forms.Label lblCharge;
        private System.Windows.Forms.Label lblGC;
    }
}
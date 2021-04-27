namespace MSAS
{
    partial class SaveVarianceBreakdownSummary
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
            this.gbxDocuments = new System.Windows.Forms.GroupBox();
            this.chkOther = new System.Windows.Forms.CheckBox();
            this.chkMSR = new System.Windows.Forms.CheckBox();
            this.chkReadings = new System.Windows.Forms.CheckBox();
            this.chkDeposits = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.rdbFirst = new System.Windows.Forms.RadioButton();
            this.gbxHistory = new System.Windows.Forms.GroupBox();
            this.rdbNonRecur = new System.Windows.Forms.RadioButton();
            this.rdbRecur = new System.Windows.Forms.RadioButton();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.cmbNOE = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassif = new System.Windows.Forms.TextBox();
            this.txtComponent = new System.Windows.Forms.TextBox();
            this.gbxDocuments.SuspendLayout();
            this.gbxHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxDocuments
            // 
            this.gbxDocuments.Controls.Add(this.chkOther);
            this.gbxDocuments.Controls.Add(this.chkMSR);
            this.gbxDocuments.Controls.Add(this.chkReadings);
            this.gbxDocuments.Controls.Add(this.chkDeposits);
            this.gbxDocuments.Location = new System.Drawing.Point(31, 351);
            this.gbxDocuments.Name = "gbxDocuments";
            this.gbxDocuments.Size = new System.Drawing.Size(409, 83);
            this.gbxDocuments.TabIndex = 36;
            this.gbxDocuments.TabStop = false;
            this.gbxDocuments.Text = "Supporting Documents";
            // 
            // chkOther
            // 
            this.chkOther.AutoSize = true;
            this.chkOther.Location = new System.Drawing.Point(262, 52);
            this.chkOther.Name = "chkOther";
            this.chkOther.Size = new System.Drawing.Size(134, 21);
            this.chkOther.TabIndex = 20;
            this.chkOther.Text = "Other Document";
            this.chkOther.UseVisualStyleBackColor = true;
            // 
            // chkMSR
            // 
            this.chkMSR.AutoSize = true;
            this.chkMSR.Location = new System.Drawing.Point(119, 21);
            this.chkMSR.Name = "chkMSR";
            this.chkMSR.Size = new System.Drawing.Size(60, 21);
            this.chkMSR.TabIndex = 17;
            this.chkMSR.Text = "MSR";
            this.chkMSR.UseVisualStyleBackColor = true;
            // 
            // chkReadings
            // 
            this.chkReadings.AutoSize = true;
            this.chkReadings.Location = new System.Drawing.Point(119, 52);
            this.chkReadings.Name = "chkReadings";
            this.chkReadings.Size = new System.Drawing.Size(90, 21);
            this.chkReadings.TabIndex = 18;
            this.chkReadings.Text = "Readings";
            this.chkReadings.UseVisualStyleBackColor = true;
            // 
            // chkDeposits
            // 
            this.chkDeposits.AutoSize = true;
            this.chkDeposits.Location = new System.Drawing.Point(262, 12);
            this.chkDeposits.Name = "chkDeposits";
            this.chkDeposits.Size = new System.Drawing.Size(112, 38);
            this.chkDeposits.TabIndex = 19;
            this.chkDeposits.Text = "Cash/ Credit \r\nCard Deposit";
            this.chkDeposits.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(365, 440);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 50);
            this.btnCancel.TabIndex = 34;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(208, 440);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 50);
            this.btnOk.TabIndex = 33;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rdbFirst
            // 
            this.rdbFirst.AutoSize = true;
            this.rdbFirst.Location = new System.Drawing.Point(80, 21);
            this.rdbFirst.Name = "rdbFirst";
            this.rdbFirst.Size = new System.Drawing.Size(91, 21);
            this.rdbFirst.TabIndex = 12;
            this.rdbFirst.Text = "First Time";
            this.rdbFirst.UseVisualStyleBackColor = true;
            // 
            // gbxHistory
            // 
            this.gbxHistory.Controls.Add(this.rdbFirst);
            this.gbxHistory.Controls.Add(this.rdbNonRecur);
            this.gbxHistory.Controls.Add(this.rdbRecur);
            this.gbxHistory.Location = new System.Drawing.Point(31, 293);
            this.gbxHistory.Name = "gbxHistory";
            this.gbxHistory.Size = new System.Drawing.Size(409, 52);
            this.gbxHistory.TabIndex = 35;
            this.gbxHistory.TabStop = false;
            this.gbxHistory.Text = "History";
            // 
            // rdbNonRecur
            // 
            this.rdbNonRecur.AutoSize = true;
            this.rdbNonRecur.Location = new System.Drawing.Point(274, 21);
            this.rdbNonRecur.Name = "rdbNonRecur";
            this.rdbNonRecur.Size = new System.Drawing.Size(122, 21);
            this.rdbNonRecur.TabIndex = 14;
            this.rdbNonRecur.Text = "Non-Recurring";
            this.rdbNonRecur.UseVisualStyleBackColor = true;
            // 
            // rdbRecur
            // 
            this.rdbRecur.AutoSize = true;
            this.rdbRecur.Location = new System.Drawing.Point(177, 21);
            this.rdbRecur.Name = "rdbRecur";
            this.rdbRecur.Size = new System.Drawing.Size(91, 21);
            this.rdbRecur.TabIndex = 13;
            this.rdbRecur.Text = "Recurring";
            this.rdbRecur.UseVisualStyleBackColor = true;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(194, 184);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(246, 103);
            this.txtRemarks.TabIndex = 32;
            // 
            // cmbNOE
            // 
            this.cmbNOE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNOE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNOE.FormattingEnabled = true;
            this.cmbNOE.Location = new System.Drawing.Point(194, 107);
            this.cmbNOE.Name = "cmbNOE";
            this.cmbNOE.Size = new System.Drawing.Size(246, 33);
            this.cmbNOE.TabIndex = 31;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(194, 148);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ShortcutsEnabled = false;
            this.txtAmount.Size = new System.Drawing.Size(246, 30);
            this.txtAmount.TabIndex = 28;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 25);
            this.label5.TabIndex = 26;
            this.label5.Text = "Remarks:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 25);
            this.label4.TabIndex = 27;
            this.label4.Text = "Amount:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 25);
            this.label3.TabIndex = 25;
            this.label3.Text = "Nature of Error:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 24;
            this.label2.Text = "Classification:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Component:";
            // 
            // txtClassif
            // 
            this.txtClassif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClassif.Location = new System.Drawing.Point(194, 64);
            this.txtClassif.Name = "txtClassif";
            this.txtClassif.Size = new System.Drawing.Size(246, 30);
            this.txtClassif.TabIndex = 21;
            this.txtClassif.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClassif_KeyPress);
            // 
            // txtComponent
            // 
            this.txtComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComponent.Location = new System.Drawing.Point(194, 22);
            this.txtComponent.Name = "txtComponent";
            this.txtComponent.Size = new System.Drawing.Size(246, 30);
            this.txtComponent.TabIndex = 37;
            this.txtComponent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComponent_KeyPress);
            // 
            // SaveVarianceBreakdownSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 498);
            this.Controls.Add(this.txtComponent);
            this.Controls.Add(this.txtClassif);
            this.Controls.Add(this.gbxDocuments);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.gbxHistory);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.cmbNOE);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveVarianceBreakdownSummary";
            this.Text = "SaveVarianceBreakdownSummary";
            this.Load += new System.EventHandler(this.SaveVarianceBreakdownSummary_Load);
            this.gbxDocuments.ResumeLayout(false);
            this.gbxDocuments.PerformLayout();
            this.gbxHistory.ResumeLayout(false);
            this.gbxHistory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxDocuments;
        private System.Windows.Forms.CheckBox chkOther;
        private System.Windows.Forms.CheckBox chkMSR;
        private System.Windows.Forms.CheckBox chkReadings;
        private System.Windows.Forms.CheckBox chkDeposits;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RadioButton rdbFirst;
        private System.Windows.Forms.GroupBox gbxHistory;
        private System.Windows.Forms.RadioButton rdbNonRecur;
        private System.Windows.Forms.RadioButton rdbRecur;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.ComboBox cmbNOE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtComponent;
        public System.Windows.Forms.TextBox txtClassif;
        public System.Windows.Forms.TextBox txtAmount;
    }
}
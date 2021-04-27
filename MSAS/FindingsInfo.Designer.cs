namespace MSAS
{
    partial class FindingsInfo
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cmbComponent = new System.Windows.Forms.ComboBox();
            this.cmbClassification = new System.Windows.Forms.ComboBox();
            this.cmbNOE = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdbFirst = new System.Windows.Forms.RadioButton();
            this.rdbRecur = new System.Windows.Forms.RadioButton();
            this.rdbNonRecur = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkMSR = new System.Windows.Forms.CheckBox();
            this.chkReadings = new System.Windows.Forms.CheckBox();
            this.chkDeposits = new System.Windows.Forms.CheckBox();
            this.chkOther = new System.Windows.Forms.CheckBox();
            this.gbxHistory = new System.Windows.Forms.GroupBox();
            this.gbxDocuments = new System.Windows.Forms.GroupBox();
            this.gbxHistory.SuspendLayout();
            this.gbxDocuments.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Component:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Classification:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nature of Error:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(198, 138);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ShortcutsEnabled = false;
            this.txtAmount.Size = new System.Drawing.Size(246, 30);
            this.txtAmount.TabIndex = 6;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // cmbComponent
            // 
            this.cmbComponent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComponent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbComponent.FormattingEnabled = true;
            this.cmbComponent.Location = new System.Drawing.Point(198, 12);
            this.cmbComponent.Name = "cmbComponent";
            this.cmbComponent.Size = new System.Drawing.Size(246, 33);
            this.cmbComponent.TabIndex = 7;
            // 
            // cmbClassification
            // 
            this.cmbClassification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassification.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClassification.FormattingEnabled = true;
            this.cmbClassification.Location = new System.Drawing.Point(198, 54);
            this.cmbClassification.Name = "cmbClassification";
            this.cmbClassification.Size = new System.Drawing.Size(246, 33);
            this.cmbClassification.TabIndex = 8;
            this.cmbClassification.SelectedIndexChanged += new System.EventHandler(this.cmbClassification_SelectedIndexChanged);
            // 
            // cmbNOE
            // 
            this.cmbNOE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNOE.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNOE.FormattingEnabled = true;
            this.cmbNOE.Location = new System.Drawing.Point(198, 97);
            this.cmbNOE.Name = "cmbNOE";
            this.cmbNOE.Size = new System.Drawing.Size(246, 33);
            this.cmbNOE.TabIndex = 9;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(198, 174);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(246, 103);
            this.txtRemarks.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Remarks:";
            // 
            // rdbFirst
            // 
            this.rdbFirst.AutoSize = true;
            this.rdbFirst.Checked = true;
            this.rdbFirst.Location = new System.Drawing.Point(80, 21);
            this.rdbFirst.Name = "rdbFirst";
            this.rdbFirst.Size = new System.Drawing.Size(91, 21);
            this.rdbFirst.TabIndex = 12;
            this.rdbFirst.TabStop = true;
            this.rdbFirst.Text = "First Time";
            this.rdbFirst.UseVisualStyleBackColor = true;
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
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(198, 428);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 50);
            this.btnOk.TabIndex = 15;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(369, 428);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 50);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // gbxHistory
            // 
            this.gbxHistory.Controls.Add(this.rdbFirst);
            this.gbxHistory.Controls.Add(this.rdbNonRecur);
            this.gbxHistory.Controls.Add(this.rdbRecur);
            this.gbxHistory.Location = new System.Drawing.Point(35, 283);
            this.gbxHistory.Name = "gbxHistory";
            this.gbxHistory.Size = new System.Drawing.Size(409, 50);
            this.gbxHistory.TabIndex = 21;
            this.gbxHistory.TabStop = false;
            this.gbxHistory.Text = "History";
            // 
            // gbxDocuments
            // 
            this.gbxDocuments.Controls.Add(this.chkOther);
            this.gbxDocuments.Controls.Add(this.chkMSR);
            this.gbxDocuments.Controls.Add(this.chkReadings);
            this.gbxDocuments.Controls.Add(this.chkDeposits);
            this.gbxDocuments.Location = new System.Drawing.Point(35, 339);
            this.gbxDocuments.Name = "gbxDocuments";
            this.gbxDocuments.Size = new System.Drawing.Size(409, 83);
            this.gbxDocuments.TabIndex = 22;
            this.gbxDocuments.TabStop = false;
            this.gbxDocuments.Text = "Supporting Documents";
            // 
            // FindingsInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 494);
            this.Controls.Add(this.gbxDocuments);
            this.Controls.Add(this.gbxHistory);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.cmbNOE);
            this.Controls.Add(this.cmbClassification);
            this.Controls.Add(this.cmbComponent);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindingsInfo";
            this.Text = "FindingsInfo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindingsInfo_FormClosing);
            this.Load += new System.EventHandler(this.FindingsInfo_Load);
            this.gbxHistory.ResumeLayout(false);
            this.gbxHistory.PerformLayout();
            this.gbxDocuments.ResumeLayout(false);
            this.gbxDocuments.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cmbComponent;
        private System.Windows.Forms.ComboBox cmbClassification;
        private System.Windows.Forms.ComboBox cmbNOE;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdbFirst;
        private System.Windows.Forms.RadioButton rdbRecur;
        private System.Windows.Forms.RadioButton rdbNonRecur;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkMSR;
        private System.Windows.Forms.CheckBox chkReadings;
        private System.Windows.Forms.CheckBox chkDeposits;
        private System.Windows.Forms.CheckBox chkOther;
        private System.Windows.Forms.GroupBox gbxHistory;
        private System.Windows.Forms.GroupBox gbxDocuments;
    }
}
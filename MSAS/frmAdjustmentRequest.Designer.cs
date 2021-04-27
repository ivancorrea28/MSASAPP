namespace MSAS
{
    partial class frmAdjustmentRequest
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
            this.dtpSdate = new System.Windows.Forms.DateTimePicker();
            this.dtpEdate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnSaveOk = new System.Windows.Forms.Button();
            this.lblLocRPname = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpSdate
            // 
            this.dtpSdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSdate.Location = new System.Drawing.Point(89, 65);
            this.dtpSdate.Name = "dtpSdate";
            this.dtpSdate.Size = new System.Drawing.Size(110, 24);
            this.dtpSdate.TabIndex = 0;
            // 
            // dtpEdate
            // 
            this.dtpEdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEdate.Location = new System.Drawing.Point(305, 65);
            this.dtpEdate.Name = "dtpEdate";
            this.dtpEdate.Size = new System.Drawing.Size(110, 24);
            this.dtpEdate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Reason:";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(89, 95);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(326, 105);
            this.txtReason.TabIndex = 6;
            this.txtReason.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReason_KeyPress);
            // 
            // btnSaveOk
            // 
            this.btnSaveOk.Location = new System.Drawing.Point(194, 206);
            this.btnSaveOk.Name = "btnSaveOk";
            this.btnSaveOk.Size = new System.Drawing.Size(75, 23);
            this.btnSaveOk.TabIndex = 7;
            this.btnSaveOk.Text = "Save";
            this.btnSaveOk.UseVisualStyleBackColor = true;
            this.btnSaveOk.Click += new System.EventHandler(this.btnSaveOk_Click);
            // 
            // lblLocRPname
            // 
            this.lblLocRPname.AutoSize = true;
            this.lblLocRPname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocRPname.Location = new System.Drawing.Point(5, 9);
            this.lblLocRPname.Name = "lblLocRPname";
            this.lblLocRPname.Size = new System.Drawing.Size(203, 24);
            this.lblLocRPname.TabIndex = 8;
            this.lblLocRPname.Text = "LOCATION - RP Name";
            // 
            // frmAdjustmentRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 261);
            this.Controls.Add(this.lblLocRPname);
            this.Controls.Add(this.btnSaveOk);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEdate);
            this.Controls.Add(this.dtpSdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdjustmentRequest";
            this.Text = "Sales Adjustment Request";
            this.Load += new System.EventHandler(this.frmAdjustmentRequest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpSdate;
        private System.Windows.Forms.DateTimePicker dtpEdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Button btnSaveOk;
        public System.Windows.Forms.Label lblLocRPname;
    }
}
namespace MSAS
{
    partial class frmTickDoc
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
            this.chkDoc1 = new System.Windows.Forms.CheckBox();
            this.chkDoc2 = new System.Windows.Forms.CheckBox();
            this.chkDoc3 = new System.Windows.Forms.CheckBox();
            this.chkDoc4 = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtDoc1 = new System.Windows.Forms.TextBox();
            this.txtDoc2 = new System.Windows.Forms.TextBox();
            this.txtDoc3 = new System.Windows.Forms.TextBox();
            this.txtDoc4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAllDocs = new System.Windows.Forms.Button();
            this.btnMainDocs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(138, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "MSR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(99, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "READINGS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "CASH / Credit \r\nCard Deposits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(99, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Other \r\nDocument";
            // 
            // chkDoc1
            // 
            this.chkDoc1.AutoSize = true;
            this.chkDoc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDoc1.Location = new System.Drawing.Point(31, 45);
            this.chkDoc1.Name = "chkDoc1";
            this.chkDoc1.Size = new System.Drawing.Size(38, 29);
            this.chkDoc1.TabIndex = 4;
            this.chkDoc1.Text = "^";
            this.chkDoc1.UseVisualStyleBackColor = true;
            // 
            // chkDoc2
            // 
            this.chkDoc2.AutoSize = true;
            this.chkDoc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDoc2.Location = new System.Drawing.Point(31, 77);
            this.chkDoc2.Name = "chkDoc2";
            this.chkDoc2.Size = new System.Drawing.Size(37, 29);
            this.chkDoc2.TabIndex = 5;
            this.chkDoc2.Text = "/";
            this.chkDoc2.UseVisualStyleBackColor = true;
            // 
            // chkDoc3
            // 
            this.chkDoc3.AutoSize = true;
            this.chkDoc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDoc3.Location = new System.Drawing.Point(31, 109);
            this.chkDoc3.Name = "chkDoc3";
            this.chkDoc3.Size = new System.Drawing.Size(39, 29);
            this.chkDoc3.TabIndex = 6;
            this.chkDoc3.Text = "*";
            this.chkDoc3.UseVisualStyleBackColor = true;
            // 
            // chkDoc4
            // 
            this.chkDoc4.AutoSize = true;
            this.chkDoc4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDoc4.Location = new System.Drawing.Point(31, 141);
            this.chkDoc4.Name = "chkDoc4";
            this.chkDoc4.Size = new System.Drawing.Size(51, 29);
            this.chkDoc4.TabIndex = 7;
            this.chkDoc4.Text = "@";
            this.chkDoc4.UseVisualStyleBackColor = true;
            this.chkDoc4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(141, 175);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtDoc1
            // 
            this.txtDoc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoc1.Location = new System.Drawing.Point(182, 47);
            this.txtDoc1.Name = "txtDoc1";
            this.txtDoc1.Size = new System.Drawing.Size(175, 26);
            this.txtDoc1.TabIndex = 9;
            // 
            // txtDoc2
            // 
            this.txtDoc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoc2.Location = new System.Drawing.Point(182, 79);
            this.txtDoc2.Name = "txtDoc2";
            this.txtDoc2.Size = new System.Drawing.Size(175, 26);
            this.txtDoc2.TabIndex = 10;
            // 
            // txtDoc3
            // 
            this.txtDoc3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoc3.Location = new System.Drawing.Point(181, 111);
            this.txtDoc3.Name = "txtDoc3";
            this.txtDoc3.Size = new System.Drawing.Size(175, 26);
            this.txtDoc3.TabIndex = 11;
            // 
            // txtDoc4
            // 
            this.txtDoc4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoc4.Location = new System.Drawing.Point(181, 143);
            this.txtDoc4.Name = "txtDoc4";
            this.txtDoc4.Size = new System.Drawing.Size(175, 26);
            this.txtDoc4.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Document";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(246, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Remarks";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Symbol";
            // 
            // btnAllDocs
            // 
            this.btnAllDocs.Location = new System.Drawing.Point(12, 25);
            this.btnAllDocs.Name = "btnAllDocs";
            this.btnAllDocs.Size = new System.Drawing.Size(37, 23);
            this.btnAllDocs.TabIndex = 15;
            this.btnAllDocs.Text = "ALL";
            this.btnAllDocs.UseVisualStyleBackColor = true;
            this.btnAllDocs.Click += new System.EventHandler(this.btnAllDocs_Click);
            // 
            // btnMainDocs
            // 
            this.btnMainDocs.Location = new System.Drawing.Point(55, 25);
            this.btnMainDocs.Name = "btnMainDocs";
            this.btnMainDocs.Size = new System.Drawing.Size(75, 23);
            this.btnMainDocs.TabIndex = 16;
            this.btnMainDocs.Text = "REQDocs";
            this.btnMainDocs.UseVisualStyleBackColor = true;
            this.btnMainDocs.Click += new System.EventHandler(this.btnMainDocs_Click);
            // 
            // frmTickDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 236);
            this.ControlBox = false;
            this.Controls.Add(this.btnMainDocs);
            this.Controls.Add(this.btnAllDocs);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDoc4);
            this.Controls.Add(this.txtDoc3);
            this.Controls.Add(this.txtDoc2);
            this.Controls.Add(this.txtDoc1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkDoc4);
            this.Controls.Add(this.chkDoc3);
            this.Controls.Add(this.chkDoc2);
            this.Controls.Add(this.chkDoc1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTickDoc";
            this.Text = "Check Documents";
            this.Load += new System.EventHandler(this.frmTickDoc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkDoc1;
        private System.Windows.Forms.CheckBox chkDoc2;
        private System.Windows.Forms.CheckBox chkDoc3;
        private System.Windows.Forms.CheckBox chkDoc4;
        private System.Windows.Forms.TextBox txtDoc1;
        private System.Windows.Forms.TextBox txtDoc2;
        private System.Windows.Forms.TextBox txtDoc3;
        private System.Windows.Forms.TextBox txtDoc4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAllDocs;
        private System.Windows.Forms.Button btnMainDocs;
        public System.Windows.Forms.Button btnOK;
    }
}
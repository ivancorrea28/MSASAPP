namespace MSAS
{
    partial class WorkingPaper
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
            this.dgvWP = new System.Windows.Forms.DataGridView();
            this.txtMonthYear = new System.Windows.Forms.TextBox();
            this.txtRP = new System.Windows.Forms.TextBox();
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTerminal = new System.Windows.Forms.ComboBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnCheckDates = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnPDF = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnExcelCopy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWP)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWP
            // 
            this.dgvWP.AllowUserToAddRows = false;
            this.dgvWP.AllowUserToDeleteRows = false;
            this.dgvWP.AllowUserToResizeRows = false;
            this.dgvWP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWP.Location = new System.Drawing.Point(8, 65);
            this.dgvWP.Margin = new System.Windows.Forms.Padding(2);
            this.dgvWP.Name = "dgvWP";
            this.dgvWP.RowHeadersVisible = false;
            this.dgvWP.RowTemplate.Height = 24;
            this.dgvWP.Size = new System.Drawing.Size(998, 588);
            this.dgvWP.TabIndex = 0;
            this.dgvWP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWP_CellClick);
            this.dgvWP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWP_CellContentClick);
            this.dgvWP.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWP_CellValueChanged);
            // 
            // txtMonthYear
            // 
            this.txtMonthYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonthYear.Location = new System.Drawing.Point(120, 3);
            this.txtMonthYear.Margin = new System.Windows.Forms.Padding(2);
            this.txtMonthYear.Name = "txtMonthYear";
            this.txtMonthYear.ReadOnly = true;
            this.txtMonthYear.Size = new System.Drawing.Size(198, 26);
            this.txtMonthYear.TabIndex = 1;
            this.txtMonthYear.Text = "February 2020";
            this.txtMonthYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMonthYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonthYear_KeyPress);
            // 
            // txtRP
            // 
            this.txtRP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRP.Location = new System.Drawing.Point(437, 3);
            this.txtRP.Margin = new System.Windows.Forms.Padding(2);
            this.txtRP.Name = "txtRP";
            this.txtRP.ReadOnly = true;
            this.txtRP.Size = new System.Drawing.Size(198, 26);
            this.txtRP.TabIndex = 2;
            this.txtRP.Text = "Popeye\'s";
            this.txtRP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLoc
            // 
            this.txtLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoc.Location = new System.Drawing.Point(437, 26);
            this.txtLoc.Margin = new System.Windows.Forms.Padding(2);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.ReadOnly = true;
            this.txtLoc.Size = new System.Drawing.Size(198, 26);
            this.txtLoc.TabIndex = 3;
            this.txtLoc.Text = "Citywalk-I";
            this.txtLoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDate
            // 
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(120, 27);
            this.txtDate.Margin = new System.Windows.Forms.Padding(2);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(198, 26);
            this.txtDate.TabIndex = 5;
            this.txtDate.Text = "March 31, 2020";
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(321, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Retail Partner:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(321, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mall:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(653, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Terminal:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Date Printed:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Period:";
            // 
            // cmbTerminal
            // 
            this.cmbTerminal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTerminal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTerminal.FormattingEnabled = true;
            this.cmbTerminal.Location = new System.Drawing.Point(656, 32);
            this.cmbTerminal.Margin = new System.Windows.Forms.Padding(2);
            this.cmbTerminal.Name = "cmbTerminal";
            this.cmbTerminal.Size = new System.Drawing.Size(73, 28);
            this.cmbTerminal.TabIndex = 12;
            this.cmbTerminal.DropDown += new System.EventHandler(this.cmbTerminal_DropDown);
            this.cmbTerminal.SelectedIndexChanged += new System.EventHandler(this.cmbTerminal_SelectedIndexChanged);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(841, 34);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(80, 25);
            this.btnExcel.TabIndex = 13;
            this.btnExcel.Text = "Export Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnCheckDates
            // 
            this.btnCheckDates.Location = new System.Drawing.Point(561, 39);
            this.btnCheckDates.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckDates.Name = "btnCheckDates";
            this.btnCheckDates.Size = new System.Drawing.Size(74, 22);
            this.btnCheckDates.TabIndex = 14;
            this.btnCheckDates.Text = "Check All";
            this.btnCheckDates.UseVisualStyleBackColor = true;
            this.btnCheckDates.Visible = false;
            this.btnCheckDates.Click += new System.EventHandler(this.btnCheckDates_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(841, 6);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(165, 26);
            this.txtFileName.TabIndex = 15;
            // 
            // btnPDF
            // 
            this.btnPDF.Location = new System.Drawing.Point(926, 34);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(80, 25);
            this.btnPDF.TabIndex = 16;
            this.btnPDF.Text = "Export PDF";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(752, 9);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(84, 20);
            this.lblFileName.TabIndex = 17;
            this.lblFileName.Text = "File Name:";
            // 
            // btnExcelCopy
            // 
            this.btnExcelCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcelCopy.Location = new System.Drawing.Point(756, 34);
            this.btnExcelCopy.Name = "btnExcelCopy";
            this.btnExcelCopy.Size = new System.Drawing.Size(80, 25);
            this.btnExcelCopy.TabIndex = 18;
            this.btnExcelCopy.Text = "Copy to Excel";
            this.btnExcelCopy.UseVisualStyleBackColor = true;
            this.btnExcelCopy.Click += new System.EventHandler(this.btnExcelCopy_Click);
            // 
            // WorkingPaper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 609);
            this.Controls.Add(this.btnExcelCopy);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnCheckDates);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.cmbTerminal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtLoc);
            this.Controls.Add(this.txtRP);
            this.Controls.Add(this.txtMonthYear);
            this.Controls.Add(this.dgvWP);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "WorkingPaper";
            this.Text = "WorkingPaper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkingPaper_FormClosing);
            this.Load += new System.EventHandler(this.WorkingPaperRaw_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWP;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTerminal;
        public System.Windows.Forms.TextBox txtLoc;
        public System.Windows.Forms.TextBox txtRP;
        public System.Windows.Forms.TextBox txtMonthYear;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnCheckDates;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnExcelCopy;
    }
}
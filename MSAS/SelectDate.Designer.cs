namespace MSAS
{
    partial class SelectDate
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
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.rdbSingleDate = new System.Windows.Forms.RadioButton();
            this.rdbRangeDate = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(40, 107);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(127, 30);
            this.dtpStartDate.TabIndex = 0;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(211, 107);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(127, 30);
            this.dtpEndDate.TabIndex = 1;
            this.dtpEndDate.Visible = false;
            // 
            // rdbSingleDate
            // 
            this.rdbSingleDate.AutoSize = true;
            this.rdbSingleDate.Checked = true;
            this.rdbSingleDate.Location = new System.Drawing.Point(40, 63);
            this.rdbSingleDate.Name = "rdbSingleDate";
            this.rdbSingleDate.Size = new System.Drawing.Size(102, 21);
            this.rdbSingleDate.TabIndex = 2;
            this.rdbSingleDate.TabStop = true;
            this.rdbSingleDate.Text = "Single Date";
            this.rdbSingleDate.UseVisualStyleBackColor = true;
            this.rdbSingleDate.CheckedChanged += new System.EventHandler(this.rdbSingleDate_CheckedChanged);
            // 
            // rdbRangeDate
            // 
            this.rdbRangeDate.AutoSize = true;
            this.rdbRangeDate.Location = new System.Drawing.Point(211, 63);
            this.rdbRangeDate.Name = "rdbRangeDate";
            this.rdbRangeDate.Size = new System.Drawing.Size(105, 21);
            this.rdbRangeDate.TabIndex = 3;
            this.rdbRangeDate.Text = "Date Range";
            this.rdbRangeDate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(65, 143);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 44);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add Date";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDays
            // 
            this.txtDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDays.Location = new System.Drawing.Point(115, 12);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(223, 30);
            this.txtDays.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Selected Days:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(211, 143);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 44);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // SelectDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 221);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.rdbRangeDate);
            this.Controls.Add(this.rdbSingleDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectDate";
            this.Text = "SelectDate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectDate_FormClosing);
            this.Load += new System.EventHandler(this.SelectDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.RadioButton rdbSingleDate;
        private System.Windows.Forms.RadioButton rdbRangeDate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
    }
}
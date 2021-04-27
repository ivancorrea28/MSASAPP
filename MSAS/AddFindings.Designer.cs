namespace MSAS
{
    partial class AddFindings
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
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.dgvFindings = new System.Windows.Forms.DataGridView();
            this.btnAddFindings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDays = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindings)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMonth
            // 
            this.txtMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonth.Location = new System.Drawing.Point(12, 12);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.ReadOnly = true;
            this.txtMonth.Size = new System.Drawing.Size(161, 30);
            this.txtMonth.TabIndex = 0;
            // 
            // dgvFindings
            // 
            this.dgvFindings.AllowUserToAddRows = false;
            this.dgvFindings.AllowUserToDeleteRows = false;
            this.dgvFindings.AllowUserToResizeRows = false;
            this.dgvFindings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFindings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFindings.Location = new System.Drawing.Point(12, 48);
            this.dgvFindings.Name = "dgvFindings";
            this.dgvFindings.RowTemplate.Height = 24;
            this.dgvFindings.Size = new System.Drawing.Size(583, 150);
            this.dgvFindings.TabIndex = 2;
            this.dgvFindings.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFindings_CellClick);
            // 
            // btnAddFindings
            // 
            this.btnAddFindings.Location = new System.Drawing.Point(12, 204);
            this.btnAddFindings.Name = "btnAddFindings";
            this.btnAddFindings.Size = new System.Drawing.Size(95, 51);
            this.btnAddFindings.TabIndex = 3;
            this.btnAddFindings.Text = "Add";
            this.btnAddFindings.UseVisualStyleBackColor = true;
            this.btnAddFindings.Click += new System.EventHandler(this.btnAddFindings_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 51);
            this.button1.TabIndex = 4;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(500, 204);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 51);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDays
            // 
            this.txtDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDays.Location = new System.Drawing.Point(179, 12);
            this.txtDays.Name = "txtDays";
            this.txtDays.ReadOnly = true;
            this.txtDays.Size = new System.Drawing.Size(416, 30);
            this.txtDays.TabIndex = 6;
            this.txtDays.Text = "Click to Set Date Day(s)";
            this.txtDays.Click += new System.EventHandler(this.txtDays_Click);
            // 
            // AddFindings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 319);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddFindings);
            this.Controls.Add(this.dgvFindings);
            this.Controls.Add(this.txtMonth);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddFindings";
            this.Text = "AddFindings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddFindings_FormClosing);
            this.Load += new System.EventHandler(this.AddFindings_Load);
            this.Shown += new System.EventHandler(this.AddFindings_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFindings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.DataGridView dgvFindings;
        private System.Windows.Forms.Button btnAddFindings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox txtDays;
    }
}
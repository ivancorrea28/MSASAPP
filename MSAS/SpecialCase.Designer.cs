namespace MSAS
{
    partial class SpecialCase
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
            this.cmbCase = new System.Windows.Forms.ComboBox();
            this.txtGSC = new System.Windows.Forms.TextBox();
            this.txtVES = new System.Windows.Forms.TextBox();
            this.txtONV = new System.Windows.Forms.TextBox();
            this.lblGSC = new System.Windows.Forms.Label();
            this.lblVES = new System.Windows.Forms.Label();
            this.lblONV = new System.Windows.Forms.Label();
            this.dgvSalesBreakdown = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.chkSublease = new System.Windows.Forms.CheckBox();
            this.cmbDescription = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesBreakdown)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCase
            // 
            this.cmbCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCase.FormattingEnabled = true;
            this.cmbCase.Location = new System.Drawing.Point(65, 12);
            this.cmbCase.Name = "cmbCase";
            this.cmbCase.Size = new System.Drawing.Size(648, 28);
            this.cmbCase.TabIndex = 0;
            this.cmbCase.Visible = false;
            this.cmbCase.SelectedIndexChanged += new System.EventHandler(this.cmbCase_SelectedIndexChanged);
            // 
            // txtGSC
            // 
            this.txtGSC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGSC.Location = new System.Drawing.Point(128, 49);
            this.txtGSC.Name = "txtGSC";
            this.txtGSC.Size = new System.Drawing.Size(263, 24);
            this.txtGSC.TabIndex = 1;
            this.txtGSC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtGSC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGSC_KeyPress);
            // 
            // txtVES
            // 
            this.txtVES.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVES.Location = new System.Drawing.Point(475, 16);
            this.txtVES.Name = "txtVES";
            this.txtVES.Size = new System.Drawing.Size(164, 24);
            this.txtVES.TabIndex = 2;
            this.txtVES.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVES.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVES_KeyPress);
            // 
            // txtONV
            // 
            this.txtONV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtONV.Location = new System.Drawing.Point(475, 49);
            this.txtONV.Name = "txtONV";
            this.txtONV.Size = new System.Drawing.Size(164, 24);
            this.txtONV.TabIndex = 3;
            this.txtONV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtONV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtONV_KeyPress);
            // 
            // lblGSC
            // 
            this.lblGSC.AutoSize = true;
            this.lblGSC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGSC.Location = new System.Drawing.Point(12, 52);
            this.lblGSC.Name = "lblGSC";
            this.lblGSC.Size = new System.Drawing.Size(45, 18);
            this.lblGSC.TabIndex = 4;
            this.lblGSC.Text = "GSC:";
            // 
            // lblVES
            // 
            this.lblVES.AutoSize = true;
            this.lblVES.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVES.Location = new System.Drawing.Point(428, 22);
            this.lblVES.Name = "lblVES";
            this.lblVES.Size = new System.Drawing.Size(41, 18);
            this.lblVES.TabIndex = 5;
            this.lblVES.Text = "VES:";
            // 
            // lblONV
            // 
            this.lblONV.AutoSize = true;
            this.lblONV.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblONV.Location = new System.Drawing.Point(425, 52);
            this.lblONV.Name = "lblONV";
            this.lblONV.Size = new System.Drawing.Size(44, 18);
            this.lblONV.TabIndex = 6;
            this.lblONV.Text = "ONV:";
            // 
            // dgvSalesBreakdown
            // 
            this.dgvSalesBreakdown.AllowUserToAddRows = false;
            this.dgvSalesBreakdown.AllowUserToDeleteRows = false;
            this.dgvSalesBreakdown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesBreakdown.Location = new System.Drawing.Point(12, 96);
            this.dgvSalesBreakdown.Name = "dgvSalesBreakdown";
            this.dgvSalesBreakdown.ReadOnly = true;
            this.dgvSalesBreakdown.RowHeadersVisible = false;
            this.dgvSalesBreakdown.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSalesBreakdown.Size = new System.Drawing.Size(760, 317);
            this.dgvSalesBreakdown.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(682, 35);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 55);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(-8, 76);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(164, 24);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescription.Visible = false;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(9, 19);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(113, 18);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "DESCRIPTION:";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 443);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 35);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete Selected";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // chkSublease
            // 
            this.chkSublease.AutoSize = true;
            this.chkSublease.Location = new System.Drawing.Point(682, 14);
            this.chkSublease.Name = "chkSublease";
            this.chkSublease.Size = new System.Drawing.Size(70, 17);
            this.chkSublease.TabIndex = 10;
            this.chkSublease.Text = "Sublease";
            this.chkSublease.UseVisualStyleBackColor = true;
            // 
            // cmbDescription
            // 
            this.cmbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDescription.FormattingEnabled = true;
            this.cmbDescription.Location = new System.Drawing.Point(128, 16);
            this.cmbDescription.Name = "cmbDescription";
            this.cmbDescription.Size = new System.Drawing.Size(263, 28);
            this.cmbDescription.TabIndex = 11;
            this.cmbDescription.DropDown += new System.EventHandler(this.cmbDescription_DropDown);
            // 
            // SpecialCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.cmbDescription);
            this.Controls.Add(this.chkSublease);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvSalesBreakdown);
            this.Controls.Add(this.lblONV);
            this.Controls.Add(this.lblVES);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblGSC);
            this.Controls.Add(this.txtONV);
            this.Controls.Add(this.txtVES);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtGSC);
            this.Controls.Add(this.cmbCase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpecialCase";
            this.Text = "SpecialCase";
            this.Load += new System.EventHandler(this.SpecialCase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesBreakdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCase;
        private System.Windows.Forms.TextBox txtGSC;
        private System.Windows.Forms.TextBox txtVES;
        private System.Windows.Forms.TextBox txtONV;
        private System.Windows.Forms.Label lblGSC;
        private System.Windows.Forms.Label lblVES;
        private System.Windows.Forms.Label lblONV;
        private System.Windows.Forms.DataGridView dgvSalesBreakdown;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox chkSublease;
        private System.Windows.Forms.ComboBox cmbDescription;
    }
}
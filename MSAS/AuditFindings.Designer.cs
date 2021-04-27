namespace MSAS
{
    partial class AuditFindings
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
            this.tabPrimary = new System.Windows.Forms.TabControl();
            this.tabCash = new System.Windows.Forms.TabPage();
            this.btnDeleteCash = new System.Windows.Forms.Button();
            this.btnEditCash = new System.Windows.Forms.Button();
            this.dgvCash = new System.Windows.Forms.DataGridView();
            this.tabCharge = new System.Windows.Forms.TabPage();
            this.btnDeleteCharge = new System.Windows.Forms.Button();
            this.btnEditCharge = new System.Windows.Forms.Button();
            this.dgvCharge = new System.Windows.Forms.DataGridView();
            this.tabGC = new System.Windows.Forms.TabPage();
            this.btnDeleteGC = new System.Windows.Forms.Button();
            this.btnEditGC = new System.Windows.Forms.Button();
            this.dgvGC = new System.Windows.Forms.DataGridView();
            this.tabOtherDiscount = new System.Windows.Forms.TabPage();
            this.btnDeleteOD = new System.Windows.Forms.Button();
            this.btnEditOD = new System.Windows.Forms.Button();
            this.dgvOD = new System.Windows.Forms.DataGridView();
            this.tabSeniorDiscount = new System.Windows.Forms.TabPage();
            this.btnDeleteSD = new System.Windows.Forms.Button();
            this.btnEditSD = new System.Windows.Forms.Button();
            this.dgvSD = new System.Windows.Forms.DataGridView();
            this.tabServiceCharge = new System.Windows.Forms.TabPage();
            this.btnDeleteSC = new System.Windows.Forms.Button();
            this.btnEditSC = new System.Windows.Forms.Button();
            this.dgvSC = new System.Windows.Forms.DataGridView();
            this.btnAddFindings = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAuditedCash = new System.Windows.Forms.TextBox();
            this.txtFindingsCash = new System.Windows.Forms.TextBox();
            this.txtFindingsCharge = new System.Windows.Forms.TextBox();
            this.txtAuditedCharge = new System.Windows.Forms.TextBox();
            this.txtAuditedSC = new System.Windows.Forms.TextBox();
            this.txtAuditedSD = new System.Windows.Forms.TextBox();
            this.txtAuditedOD = new System.Windows.Forms.TextBox();
            this.txtAuditedGC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFindingsSC = new System.Windows.Forms.TextBox();
            this.txtFindingsSD = new System.Windows.Forms.TextBox();
            this.txtFindingsOD = new System.Windows.Forms.TextBox();
            this.txtFindingsGC = new System.Windows.Forms.TextBox();
            this.chkPositiveNegative = new System.Windows.Forms.CheckBox();
            this.btnAFBreakdown = new System.Windows.Forms.Button();
            this.tabPrimary.SuspendLayout();
            this.tabCash.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCash)).BeginInit();
            this.tabCharge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharge)).BeginInit();
            this.tabGC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGC)).BeginInit();
            this.tabOtherDiscount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOD)).BeginInit();
            this.tabSeniorDiscount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSD)).BeginInit();
            this.tabServiceCharge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSC)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPrimary
            // 
            this.tabPrimary.Controls.Add(this.tabCash);
            this.tabPrimary.Controls.Add(this.tabCharge);
            this.tabPrimary.Controls.Add(this.tabGC);
            this.tabPrimary.Controls.Add(this.tabOtherDiscount);
            this.tabPrimary.Controls.Add(this.tabSeniorDiscount);
            this.tabPrimary.Controls.Add(this.tabServiceCharge);
            this.tabPrimary.Location = new System.Drawing.Point(6, 61);
            this.tabPrimary.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPrimary.Name = "tabPrimary";
            this.tabPrimary.SelectedIndex = 0;
            this.tabPrimary.Size = new System.Drawing.Size(975, 520);
            this.tabPrimary.TabIndex = 0;
            // 
            // tabCash
            // 
            this.tabCash.Controls.Add(this.btnDeleteCash);
            this.tabCash.Controls.Add(this.btnEditCash);
            this.tabCash.Controls.Add(this.dgvCash);
            this.tabCash.Location = new System.Drawing.Point(4, 22);
            this.tabCash.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCash.Name = "tabCash";
            this.tabCash.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCash.Size = new System.Drawing.Size(967, 494);
            this.tabCash.TabIndex = 0;
            this.tabCash.Text = "Cash";
            this.tabCash.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCash
            // 
            this.btnDeleteCash.Location = new System.Drawing.Point(873, 53);
            this.btnDeleteCash.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteCash.Name = "btnDeleteCash";
            this.btnDeleteCash.Size = new System.Drawing.Size(92, 43);
            this.btnDeleteCash.TabIndex = 2;
            this.btnDeleteCash.Text = "Delete Cash";
            this.btnDeleteCash.UseVisualStyleBackColor = true;
            this.btnDeleteCash.Click += new System.EventHandler(this.btnDeleteCash_Click);
            // 
            // btnEditCash
            // 
            this.btnEditCash.Location = new System.Drawing.Point(873, 5);
            this.btnEditCash.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditCash.Name = "btnEditCash";
            this.btnEditCash.Size = new System.Drawing.Size(92, 43);
            this.btnEditCash.TabIndex = 1;
            this.btnEditCash.Text = "Edit Cash";
            this.btnEditCash.UseVisualStyleBackColor = true;
            this.btnEditCash.Visible = false;
            // 
            // dgvCash
            // 
            this.dgvCash.AllowUserToAddRows = false;
            this.dgvCash.AllowUserToDeleteRows = false;
            this.dgvCash.AllowUserToResizeRows = false;
            this.dgvCash.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCash.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCash.Location = new System.Drawing.Point(6, 5);
            this.dgvCash.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvCash.Name = "dgvCash";
            this.dgvCash.ReadOnly = true;
            this.dgvCash.RowHeadersVisible = false;
            this.dgvCash.RowTemplate.Height = 24;
            this.dgvCash.Size = new System.Drawing.Size(862, 488);
            this.dgvCash.TabIndex = 0;
            // 
            // tabCharge
            // 
            this.tabCharge.Controls.Add(this.btnDeleteCharge);
            this.tabCharge.Controls.Add(this.btnEditCharge);
            this.tabCharge.Controls.Add(this.dgvCharge);
            this.tabCharge.Location = new System.Drawing.Point(4, 22);
            this.tabCharge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCharge.Name = "tabCharge";
            this.tabCharge.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCharge.Size = new System.Drawing.Size(967, 494);
            this.tabCharge.TabIndex = 1;
            this.tabCharge.Text = "Charge";
            this.tabCharge.UseVisualStyleBackColor = true;
            // 
            // btnDeleteCharge
            // 
            this.btnDeleteCharge.Location = new System.Drawing.Point(873, 53);
            this.btnDeleteCharge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteCharge.Name = "btnDeleteCharge";
            this.btnDeleteCharge.Size = new System.Drawing.Size(92, 43);
            this.btnDeleteCharge.TabIndex = 2;
            this.btnDeleteCharge.Text = "Delete Charge";
            this.btnDeleteCharge.UseVisualStyleBackColor = true;
            this.btnDeleteCharge.Click += new System.EventHandler(this.btnDeleteCharge_Click);
            // 
            // btnEditCharge
            // 
            this.btnEditCharge.Location = new System.Drawing.Point(873, 5);
            this.btnEditCharge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditCharge.Name = "btnEditCharge";
            this.btnEditCharge.Size = new System.Drawing.Size(92, 43);
            this.btnEditCharge.TabIndex = 1;
            this.btnEditCharge.Text = "Edit Charge";
            this.btnEditCharge.UseVisualStyleBackColor = true;
            this.btnEditCharge.Visible = false;
            // 
            // dgvCharge
            // 
            this.dgvCharge.AllowUserToAddRows = false;
            this.dgvCharge.AllowUserToDeleteRows = false;
            this.dgvCharge.AllowUserToResizeRows = false;
            this.dgvCharge.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCharge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCharge.Location = new System.Drawing.Point(6, 5);
            this.dgvCharge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvCharge.Name = "dgvCharge";
            this.dgvCharge.ReadOnly = true;
            this.dgvCharge.RowHeadersVisible = false;
            this.dgvCharge.RowTemplate.Height = 24;
            this.dgvCharge.Size = new System.Drawing.Size(862, 488);
            this.dgvCharge.TabIndex = 0;
            // 
            // tabGC
            // 
            this.tabGC.Controls.Add(this.btnDeleteGC);
            this.tabGC.Controls.Add(this.btnEditGC);
            this.tabGC.Controls.Add(this.dgvGC);
            this.tabGC.Location = new System.Drawing.Point(4, 22);
            this.tabGC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabGC.Name = "tabGC";
            this.tabGC.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabGC.Size = new System.Drawing.Size(967, 494);
            this.tabGC.TabIndex = 2;
            this.tabGC.Text = "GC/Others";
            this.tabGC.UseVisualStyleBackColor = true;
            // 
            // btnDeleteGC
            // 
            this.btnDeleteGC.Location = new System.Drawing.Point(873, 53);
            this.btnDeleteGC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteGC.Name = "btnDeleteGC";
            this.btnDeleteGC.Size = new System.Drawing.Size(92, 43);
            this.btnDeleteGC.TabIndex = 2;
            this.btnDeleteGC.Text = "Delete GC/Others";
            this.btnDeleteGC.UseVisualStyleBackColor = true;
            this.btnDeleteGC.Click += new System.EventHandler(this.btnDeleteGC_Click);
            // 
            // btnEditGC
            // 
            this.btnEditGC.Location = new System.Drawing.Point(873, 5);
            this.btnEditGC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditGC.Name = "btnEditGC";
            this.btnEditGC.Size = new System.Drawing.Size(92, 43);
            this.btnEditGC.TabIndex = 1;
            this.btnEditGC.Text = "Edit GC/Others";
            this.btnEditGC.UseVisualStyleBackColor = true;
            this.btnEditGC.Visible = false;
            // 
            // dgvGC
            // 
            this.dgvGC.AllowUserToAddRows = false;
            this.dgvGC.AllowUserToDeleteRows = false;
            this.dgvGC.AllowUserToResizeRows = false;
            this.dgvGC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGC.Location = new System.Drawing.Point(6, 5);
            this.dgvGC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvGC.Name = "dgvGC";
            this.dgvGC.ReadOnly = true;
            this.dgvGC.RowHeadersVisible = false;
            this.dgvGC.RowTemplate.Height = 24;
            this.dgvGC.Size = new System.Drawing.Size(862, 488);
            this.dgvGC.TabIndex = 0;
            // 
            // tabOtherDiscount
            // 
            this.tabOtherDiscount.Controls.Add(this.btnDeleteOD);
            this.tabOtherDiscount.Controls.Add(this.btnEditOD);
            this.tabOtherDiscount.Controls.Add(this.dgvOD);
            this.tabOtherDiscount.Location = new System.Drawing.Point(4, 22);
            this.tabOtherDiscount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabOtherDiscount.Name = "tabOtherDiscount";
            this.tabOtherDiscount.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabOtherDiscount.Size = new System.Drawing.Size(967, 494);
            this.tabOtherDiscount.TabIndex = 3;
            this.tabOtherDiscount.Text = "Other Discount";
            this.tabOtherDiscount.UseVisualStyleBackColor = true;
            // 
            // btnDeleteOD
            // 
            this.btnDeleteOD.Location = new System.Drawing.Point(873, 53);
            this.btnDeleteOD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteOD.Name = "btnDeleteOD";
            this.btnDeleteOD.Size = new System.Drawing.Size(92, 43);
            this.btnDeleteOD.TabIndex = 2;
            this.btnDeleteOD.Text = "Delete Other Discount";
            this.btnDeleteOD.UseVisualStyleBackColor = true;
            this.btnDeleteOD.Click += new System.EventHandler(this.btnDeleteOD_Click);
            // 
            // btnEditOD
            // 
            this.btnEditOD.Location = new System.Drawing.Point(873, 5);
            this.btnEditOD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditOD.Name = "btnEditOD";
            this.btnEditOD.Size = new System.Drawing.Size(92, 43);
            this.btnEditOD.TabIndex = 1;
            this.btnEditOD.Text = "Edit Other Discount";
            this.btnEditOD.UseVisualStyleBackColor = true;
            this.btnEditOD.Visible = false;
            // 
            // dgvOD
            // 
            this.dgvOD.AllowUserToAddRows = false;
            this.dgvOD.AllowUserToDeleteRows = false;
            this.dgvOD.AllowUserToResizeRows = false;
            this.dgvOD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOD.Location = new System.Drawing.Point(6, 5);
            this.dgvOD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvOD.Name = "dgvOD";
            this.dgvOD.ReadOnly = true;
            this.dgvOD.RowHeadersVisible = false;
            this.dgvOD.RowTemplate.Height = 24;
            this.dgvOD.Size = new System.Drawing.Size(862, 488);
            this.dgvOD.TabIndex = 0;
            // 
            // tabSeniorDiscount
            // 
            this.tabSeniorDiscount.Controls.Add(this.btnDeleteSD);
            this.tabSeniorDiscount.Controls.Add(this.btnEditSD);
            this.tabSeniorDiscount.Controls.Add(this.dgvSD);
            this.tabSeniorDiscount.Location = new System.Drawing.Point(4, 22);
            this.tabSeniorDiscount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabSeniorDiscount.Name = "tabSeniorDiscount";
            this.tabSeniorDiscount.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabSeniorDiscount.Size = new System.Drawing.Size(967, 494);
            this.tabSeniorDiscount.TabIndex = 4;
            this.tabSeniorDiscount.Text = "Senior Discount";
            this.tabSeniorDiscount.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSD
            // 
            this.btnDeleteSD.Location = new System.Drawing.Point(873, 53);
            this.btnDeleteSD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteSD.Name = "btnDeleteSD";
            this.btnDeleteSD.Size = new System.Drawing.Size(92, 43);
            this.btnDeleteSD.TabIndex = 2;
            this.btnDeleteSD.Text = "Delete Senior Discount";
            this.btnDeleteSD.UseVisualStyleBackColor = true;
            this.btnDeleteSD.Click += new System.EventHandler(this.btnDeleteSD_Click);
            // 
            // btnEditSD
            // 
            this.btnEditSD.Location = new System.Drawing.Point(873, 5);
            this.btnEditSD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditSD.Name = "btnEditSD";
            this.btnEditSD.Size = new System.Drawing.Size(92, 43);
            this.btnEditSD.TabIndex = 1;
            this.btnEditSD.Text = "Edit Senior Discount";
            this.btnEditSD.UseVisualStyleBackColor = true;
            this.btnEditSD.Visible = false;
            // 
            // dgvSD
            // 
            this.dgvSD.AllowUserToAddRows = false;
            this.dgvSD.AllowUserToDeleteRows = false;
            this.dgvSD.AllowUserToResizeRows = false;
            this.dgvSD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSD.Location = new System.Drawing.Point(6, 5);
            this.dgvSD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvSD.Name = "dgvSD";
            this.dgvSD.ReadOnly = true;
            this.dgvSD.RowHeadersVisible = false;
            this.dgvSD.RowTemplate.Height = 24;
            this.dgvSD.Size = new System.Drawing.Size(862, 488);
            this.dgvSD.TabIndex = 0;
            // 
            // tabServiceCharge
            // 
            this.tabServiceCharge.Controls.Add(this.btnDeleteSC);
            this.tabServiceCharge.Controls.Add(this.btnEditSC);
            this.tabServiceCharge.Controls.Add(this.dgvSC);
            this.tabServiceCharge.Location = new System.Drawing.Point(4, 22);
            this.tabServiceCharge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabServiceCharge.Name = "tabServiceCharge";
            this.tabServiceCharge.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabServiceCharge.Size = new System.Drawing.Size(967, 494);
            this.tabServiceCharge.TabIndex = 5;
            this.tabServiceCharge.Text = "Service Charge";
            this.tabServiceCharge.UseVisualStyleBackColor = true;
            // 
            // btnDeleteSC
            // 
            this.btnDeleteSC.Location = new System.Drawing.Point(873, 53);
            this.btnDeleteSC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteSC.Name = "btnDeleteSC";
            this.btnDeleteSC.Size = new System.Drawing.Size(92, 43);
            this.btnDeleteSC.TabIndex = 2;
            this.btnDeleteSC.Text = "Delete Service Charge";
            this.btnDeleteSC.UseVisualStyleBackColor = true;
            this.btnDeleteSC.Click += new System.EventHandler(this.btnDeleteSC_Click);
            // 
            // btnEditSC
            // 
            this.btnEditSC.Location = new System.Drawing.Point(873, 5);
            this.btnEditSC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditSC.Name = "btnEditSC";
            this.btnEditSC.Size = new System.Drawing.Size(92, 43);
            this.btnEditSC.TabIndex = 1;
            this.btnEditSC.Text = "Edit Service Charge";
            this.btnEditSC.UseVisualStyleBackColor = true;
            this.btnEditSC.Visible = false;
            // 
            // dgvSC
            // 
            this.dgvSC.AllowUserToAddRows = false;
            this.dgvSC.AllowUserToDeleteRows = false;
            this.dgvSC.AllowUserToOrderColumns = true;
            this.dgvSC.AllowUserToResizeRows = false;
            this.dgvSC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSC.Location = new System.Drawing.Point(6, 5);
            this.dgvSC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvSC.Name = "dgvSC";
            this.dgvSC.ReadOnly = true;
            this.dgvSC.RowHeadersVisible = false;
            this.dgvSC.RowTemplate.Height = 24;
            this.dgvSC.Size = new System.Drawing.Size(862, 488);
            this.dgvSC.TabIndex = 0;
            // 
            // btnAddFindings
            // 
            this.btnAddFindings.Location = new System.Drawing.Point(882, 21);
            this.btnAddFindings.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddFindings.Name = "btnAddFindings";
            this.btnAddFindings.Size = new System.Drawing.Size(67, 37);
            this.btnAddFindings.TabIndex = 1;
            this.btnAddFindings.Text = "Add Findings";
            this.btnAddFindings.UseVisualStyleBackColor = true;
            this.btnAddFindings.Visible = false;
            this.btnAddFindings.Click += new System.EventHandler(this.btnAddFindings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "CASH";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Audited Variance:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Audit Findings:";
            // 
            // txtAuditedCash
            // 
            this.txtAuditedCash.Location = new System.Drawing.Point(239, 21);
            this.txtAuditedCash.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAuditedCash.Name = "txtAuditedCash";
            this.txtAuditedCash.Size = new System.Drawing.Size(98, 20);
            this.txtAuditedCash.TabIndex = 10;
            this.txtAuditedCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAuditedCash.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAuditedCash_KeyPress);
            // 
            // txtFindingsCash
            // 
            this.txtFindingsCash.Location = new System.Drawing.Point(239, 40);
            this.txtFindingsCash.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFindingsCash.Name = "txtFindingsCash";
            this.txtFindingsCash.Size = new System.Drawing.Size(98, 20);
            this.txtFindingsCash.TabIndex = 11;
            this.txtFindingsCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFindingsCharge
            // 
            this.txtFindingsCharge.Location = new System.Drawing.Point(336, 40);
            this.txtFindingsCharge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFindingsCharge.Name = "txtFindingsCharge";
            this.txtFindingsCharge.Size = new System.Drawing.Size(98, 20);
            this.txtFindingsCharge.TabIndex = 12;
            this.txtFindingsCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFindingsCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFindingsCharge_KeyPress);
            // 
            // txtAuditedCharge
            // 
            this.txtAuditedCharge.Location = new System.Drawing.Point(336, 21);
            this.txtAuditedCharge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAuditedCharge.Name = "txtAuditedCharge";
            this.txtAuditedCharge.Size = new System.Drawing.Size(98, 20);
            this.txtAuditedCharge.TabIndex = 13;
            this.txtAuditedCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAuditedCharge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAuditedCharge_KeyPress);
            // 
            // txtAuditedSC
            // 
            this.txtAuditedSC.Location = new System.Drawing.Point(723, 21);
            this.txtAuditedSC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAuditedSC.Name = "txtAuditedSC";
            this.txtAuditedSC.Size = new System.Drawing.Size(98, 20);
            this.txtAuditedSC.TabIndex = 14;
            this.txtAuditedSC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAuditedSC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAuditedSC_KeyPress);
            // 
            // txtAuditedSD
            // 
            this.txtAuditedSD.Location = new System.Drawing.Point(626, 21);
            this.txtAuditedSD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAuditedSD.Name = "txtAuditedSD";
            this.txtAuditedSD.Size = new System.Drawing.Size(98, 20);
            this.txtAuditedSD.TabIndex = 15;
            this.txtAuditedSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAuditedSD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAuditedSD_KeyPress);
            // 
            // txtAuditedOD
            // 
            this.txtAuditedOD.Location = new System.Drawing.Point(530, 21);
            this.txtAuditedOD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAuditedOD.Name = "txtAuditedOD";
            this.txtAuditedOD.Size = new System.Drawing.Size(98, 20);
            this.txtAuditedOD.TabIndex = 16;
            this.txtAuditedOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAuditedOD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAuditedOD_KeyPress);
            // 
            // txtAuditedGC
            // 
            this.txtAuditedGC.Location = new System.Drawing.Point(433, 21);
            this.txtAuditedGC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAuditedGC.Name = "txtAuditedGC";
            this.txtAuditedGC.Size = new System.Drawing.Size(98, 20);
            this.txtAuditedGC.TabIndex = 17;
            this.txtAuditedGC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAuditedGC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAuditedGC_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(386, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "CHARGE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(466, 6);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "GC/OTHERS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(551, 6);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Other Discount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(645, 6);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Senior Discount";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(745, 6);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Service Charge";
            // 
            // txtFindingsSC
            // 
            this.txtFindingsSC.Location = new System.Drawing.Point(723, 40);
            this.txtFindingsSC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFindingsSC.Name = "txtFindingsSC";
            this.txtFindingsSC.Size = new System.Drawing.Size(98, 20);
            this.txtFindingsSC.TabIndex = 23;
            this.txtFindingsSC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFindingsSC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFindingsSC_KeyPress);
            // 
            // txtFindingsSD
            // 
            this.txtFindingsSD.Location = new System.Drawing.Point(626, 40);
            this.txtFindingsSD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFindingsSD.Name = "txtFindingsSD";
            this.txtFindingsSD.Size = new System.Drawing.Size(98, 20);
            this.txtFindingsSD.TabIndex = 24;
            this.txtFindingsSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFindingsSD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFindingsSD_KeyPress);
            // 
            // txtFindingsOD
            // 
            this.txtFindingsOD.Location = new System.Drawing.Point(530, 40);
            this.txtFindingsOD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFindingsOD.Name = "txtFindingsOD";
            this.txtFindingsOD.Size = new System.Drawing.Size(98, 20);
            this.txtFindingsOD.TabIndex = 25;
            this.txtFindingsOD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFindingsOD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFindingsOD_KeyPress);
            // 
            // txtFindingsGC
            // 
            this.txtFindingsGC.Location = new System.Drawing.Point(433, 40);
            this.txtFindingsGC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFindingsGC.Name = "txtFindingsGC";
            this.txtFindingsGC.Size = new System.Drawing.Size(98, 20);
            this.txtFindingsGC.TabIndex = 26;
            this.txtFindingsGC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFindingsGC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFindingsGC_KeyPress);
            // 
            // chkPositiveNegative
            // 
            this.chkPositiveNegative.AutoSize = true;
            this.chkPositiveNegative.Checked = true;
            this.chkPositiveNegative.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPositiveNegative.Location = new System.Drawing.Point(147, -1);
            this.chkPositiveNegative.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkPositiveNegative.Name = "chkPositiveNegative";
            this.chkPositiveNegative.Size = new System.Drawing.Size(142, 17);
            this.chkPositiveNegative.TabIndex = 27;
            this.chkPositiveNegative.Text = "Positve / Negative Total";
            this.chkPositiveNegative.UseVisualStyleBackColor = true;
            this.chkPositiveNegative.CheckedChanged += new System.EventHandler(this.chkPositiveNegative_CheckedChanged);
            // 
            // btnAFBreakdown
            // 
            this.btnAFBreakdown.Location = new System.Drawing.Point(9, 12);
            this.btnAFBreakdown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAFBreakdown.Name = "btnAFBreakdown";
            this.btnAFBreakdown.Size = new System.Drawing.Size(131, 37);
            this.btnAFBreakdown.TabIndex = 51;
            this.btnAFBreakdown.Text = "Audit Findings Breakdown";
            this.btnAFBreakdown.UseVisualStyleBackColor = true;
            this.btnAFBreakdown.Click += new System.EventHandler(this.btnAFBreakdown_Click);
            // 
            // AuditFindings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1011, 586);
            this.Controls.Add(this.btnAFBreakdown);
            this.Controls.Add(this.chkPositiveNegative);
            this.Controls.Add(this.txtFindingsGC);
            this.Controls.Add(this.txtFindingsOD);
            this.Controls.Add(this.txtFindingsSD);
            this.Controls.Add(this.txtFindingsSC);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAuditedGC);
            this.Controls.Add(this.txtAuditedOD);
            this.Controls.Add(this.txtAuditedSD);
            this.Controls.Add(this.txtAuditedSC);
            this.Controls.Add(this.txtAuditedCharge);
            this.Controls.Add(this.txtFindingsCharge);
            this.Controls.Add(this.txtFindingsCash);
            this.Controls.Add(this.txtAuditedCash);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddFindings);
            this.Controls.Add(this.tabPrimary);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "AuditFindings";
            this.Text = "AuditFindings";
            this.Load += new System.EventHandler(this.AuditFindings_Load);
            this.tabPrimary.ResumeLayout(false);
            this.tabCash.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCash)).EndInit();
            this.tabCharge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharge)).EndInit();
            this.tabGC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGC)).EndInit();
            this.tabOtherDiscount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOD)).EndInit();
            this.tabSeniorDiscount.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSD)).EndInit();
            this.tabServiceCharge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabPrimary;
        private System.Windows.Forms.TabPage tabCash;
        private System.Windows.Forms.DataGridView dgvCash;
        private System.Windows.Forms.TabPage tabCharge;
        private System.Windows.Forms.DataGridView dgvCharge;
        private System.Windows.Forms.TabPage tabGC;
        private System.Windows.Forms.DataGridView dgvGC;
        private System.Windows.Forms.TabPage tabOtherDiscount;
        private System.Windows.Forms.DataGridView dgvOD;
        private System.Windows.Forms.TabPage tabSeniorDiscount;
        private System.Windows.Forms.DataGridView dgvSD;
        private System.Windows.Forms.TabPage tabServiceCharge;
        private System.Windows.Forms.DataGridView dgvSC;
        private System.Windows.Forms.Button btnAddFindings;
        private System.Windows.Forms.Button btnDeleteCash;
        private System.Windows.Forms.Button btnEditCash;
        private System.Windows.Forms.Button btnDeleteCharge;
        private System.Windows.Forms.Button btnEditCharge;
        private System.Windows.Forms.Button btnDeleteGC;
        private System.Windows.Forms.Button btnEditGC;
        private System.Windows.Forms.Button btnDeleteOD;
        private System.Windows.Forms.Button btnEditOD;
        private System.Windows.Forms.Button btnDeleteSD;
        private System.Windows.Forms.Button btnEditSD;
        private System.Windows.Forms.Button btnDeleteSC;
        private System.Windows.Forms.Button btnEditSC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAuditedCash;
        private System.Windows.Forms.TextBox txtFindingsCash;
        private System.Windows.Forms.TextBox txtFindingsCharge;
        private System.Windows.Forms.TextBox txtAuditedCharge;
        private System.Windows.Forms.TextBox txtAuditedSC;
        private System.Windows.Forms.TextBox txtAuditedSD;
        private System.Windows.Forms.TextBox txtAuditedOD;
        private System.Windows.Forms.TextBox txtAuditedGC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFindingsSC;
        private System.Windows.Forms.TextBox txtFindingsSD;
        private System.Windows.Forms.TextBox txtFindingsOD;
        private System.Windows.Forms.TextBox txtFindingsGC;
        private System.Windows.Forms.CheckBox chkPositiveNegative;
        private System.Windows.Forms.Button btnAFBreakdown;
    }
}
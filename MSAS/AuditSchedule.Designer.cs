namespace MSAS
{
    partial class AuditSchedule
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAdjustments = new System.Windows.Forms.Button();
            this.btnAdjRequest = new System.Windows.Forms.Button();
            this.lblVerifiedRPCount = new System.Windows.Forms.Label();
            this.lblRPCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLocations = new System.Windows.Forms.ComboBox();
            this.chkVerified = new System.Windows.Forms.CheckBox();
            this.btnSpecialCase = new System.Windows.Forms.Button();
            this.btnDownloadRejected = new System.Windows.Forms.Button();
            this.btnViewFindings = new System.Windows.Forms.Button();
            this.btnPrintAudited = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.Label();
            this.pgbLoading = new System.Windows.Forms.ProgressBar();
            this.btnPrintRaw = new System.Windows.Forms.Button();
            this.btnAWP = new System.Windows.Forms.Button();
            this.btnEditWP = new System.Windows.Forms.Button();
            this.btnViewWP = new System.Windows.Forms.Button();
            this.pbxLoading = new System.Windows.Forms.PictureBox();
            this.lblLoad = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnDownloadRPA = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.chkHighRisk = new System.Windows.Forms.CheckBox();
            this.dgvAuditSchedule = new System.Windows.Forms.DataGridView();
            this.cmbYears = new System.Windows.Forms.ComboBox();
            this.cmbMonths = new System.Windows.Forms.ComboBox();
            this.txtAuditor = new System.Windows.Forms.TextBox();
            this.bgwDownload = new System.ComponentModel.BackgroundWorker();
            this.bgwDownloadRPA = new System.ComponentModel.BackgroundWorker();
            this.bgwUpload = new System.ComponentModel.BackgroundWorker();
            this.bgwDownloadRejected = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnAdjustments);
            this.groupBox1.Controls.Add(this.btnAdjRequest);
            this.groupBox1.Controls.Add(this.lblVerifiedRPCount);
            this.groupBox1.Controls.Add(this.lblRPCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbLocations);
            this.groupBox1.Controls.Add(this.chkVerified);
            this.groupBox1.Controls.Add(this.btnSpecialCase);
            this.groupBox1.Controls.Add(this.btnDownloadRejected);
            this.groupBox1.Controls.Add(this.btnViewFindings);
            this.groupBox1.Controls.Add(this.btnPrintAudited);
            this.groupBox1.Controls.Add(this.txtNote);
            this.groupBox1.Controls.Add(this.pgbLoading);
            this.groupBox1.Controls.Add(this.btnPrintRaw);
            this.groupBox1.Controls.Add(this.btnAWP);
            this.groupBox1.Controls.Add(this.btnEditWP);
            this.groupBox1.Controls.Add(this.btnViewWP);
            this.groupBox1.Controls.Add(this.pbxLoading);
            this.groupBox1.Controls.Add(this.lblLoad);
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Controls.Add(this.btnDownloadRPA);
            this.groupBox1.Controls.Add(this.btnDownload);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.chkHighRisk);
            this.groupBox1.Controls.Add(this.dgvAuditSchedule);
            this.groupBox1.Controls.Add(this.cmbYears);
            this.groupBox1.Controls.Add(this.cmbMonths);
            this.groupBox1.Controls.Add(this.txtAuditor);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1004, 722);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(915, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 53);
            this.button3.TabIndex = 46;
            this.button3.Text = "Upload Sales Adjustment";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(836, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 53);
            this.button2.TabIndex = 45;
            this.button2.Text = "Download Data for Adjustment";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(756, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 53);
            this.button1.TabIndex = 44;
            this.button1.Text = "Upload Adjustment Request";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAdjustments
            // 
            this.btnAdjustments.Enabled = false;
            this.btnAdjustments.Location = new System.Drawing.Point(659, 522);
            this.btnAdjustments.Name = "btnAdjustments";
            this.btnAdjustments.Size = new System.Drawing.Size(75, 53);
            this.btnAdjustments.TabIndex = 43;
            this.btnAdjustments.Text = "Sales Adjustment";
            this.btnAdjustments.UseVisualStyleBackColor = true;
            this.btnAdjustments.Click += new System.EventHandler(this.btnAdjustments_Click);
            // 
            // btnAdjRequest
            // 
            this.btnAdjRequest.Location = new System.Drawing.Point(578, 522);
            this.btnAdjRequest.Name = "btnAdjRequest";
            this.btnAdjRequest.Size = new System.Drawing.Size(75, 53);
            this.btnAdjRequest.TabIndex = 42;
            this.btnAdjRequest.Text = "Adjustment Request";
            this.btnAdjRequest.UseVisualStyleBackColor = true;
            this.btnAdjRequest.Click += new System.EventHandler(this.btnAdjRequest_Click);
            // 
            // lblVerifiedRPCount
            // 
            this.lblVerifiedRPCount.AutoSize = true;
            this.lblVerifiedRPCount.Location = new System.Drawing.Point(903, 522);
            this.lblVerifiedRPCount.Name = "lblVerifiedRPCount";
            this.lblVerifiedRPCount.Size = new System.Drawing.Size(87, 13);
            this.lblVerifiedRPCount.TabIndex = 1;
            this.lblVerifiedRPCount.Text = "Total Verified: 12";
            // 
            // lblRPCount
            // 
            this.lblRPCount.AutoSize = true;
            this.lblRPCount.Location = new System.Drawing.Point(801, 522);
            this.lblRPCount.Name = "lblRPCount";
            this.lblRPCount.Size = new System.Drawing.Size(67, 13);
            this.lblRPCount.TabIndex = 1;
            this.lblRPCount.Text = "Total RP: 10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(332, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Location:";
            this.label1.Visible = false;
            // 
            // cmbLocations
            // 
            this.cmbLocations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocations.FormattingEnabled = true;
            this.cmbLocations.Location = new System.Drawing.Point(212, 44);
            this.cmbLocations.Name = "cmbLocations";
            this.cmbLocations.Size = new System.Drawing.Size(186, 28);
            this.cmbLocations.TabIndex = 40;
            this.cmbLocations.SelectedIndexChanged += new System.EventHandler(this.cmbLocations_SelectedIndexChanged);
            // 
            // chkVerified
            // 
            this.chkVerified.AutoSize = true;
            this.chkVerified.Checked = true;
            this.chkVerified.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerified.Location = new System.Drawing.Point(161, 78);
            this.chkVerified.Name = "chkVerified";
            this.chkVerified.Size = new System.Drawing.Size(138, 17);
            this.chkVerified.TabIndex = 1;
            this.chkVerified.Text = "Show Verified RPs Only";
            this.chkVerified.UseVisualStyleBackColor = true;
            this.chkVerified.CheckedChanged += new System.EventHandler(this.chkVerified_CheckedChanged);
            // 
            // btnSpecialCase
            // 
            this.btnSpecialCase.Enabled = false;
            this.btnSpecialCase.Location = new System.Drawing.Point(335, 522);
            this.btnSpecialCase.Name = "btnSpecialCase";
            this.btnSpecialCase.Size = new System.Drawing.Size(75, 53);
            this.btnSpecialCase.TabIndex = 39;
            this.btnSpecialCase.Text = "View Special Case";
            this.btnSpecialCase.UseVisualStyleBackColor = true;
            this.btnSpecialCase.Click += new System.EventHandler(this.btnSpecialCase_Click);
            // 
            // btnDownloadRejected
            // 
            this.btnDownloadRejected.Location = new System.Drawing.Point(676, 17);
            this.btnDownloadRejected.Margin = new System.Windows.Forms.Padding(2);
            this.btnDownloadRejected.Name = "btnDownloadRejected";
            this.btnDownloadRejected.Size = new System.Drawing.Size(75, 53);
            this.btnDownloadRejected.TabIndex = 38;
            this.btnDownloadRejected.Text = "Download Rejected Data";
            this.btnDownloadRejected.UseVisualStyleBackColor = true;
            this.btnDownloadRejected.Click += new System.EventHandler(this.btnDownloadRejected_Click);
            // 
            // btnViewFindings
            // 
            this.btnViewFindings.Enabled = false;
            this.btnViewFindings.Location = new System.Drawing.Point(254, 522);
            this.btnViewFindings.Margin = new System.Windows.Forms.Padding(2);
            this.btnViewFindings.Name = "btnViewFindings";
            this.btnViewFindings.Size = new System.Drawing.Size(75, 53);
            this.btnViewFindings.TabIndex = 37;
            this.btnViewFindings.Text = "View Findings";
            this.btnViewFindings.UseVisualStyleBackColor = true;
            this.btnViewFindings.Click += new System.EventHandler(this.btnViewFindings_Click);
            // 
            // btnPrintAudited
            // 
            this.btnPrintAudited.Enabled = false;
            this.btnPrintAudited.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintAudited.Location = new System.Drawing.Point(498, 521);
            this.btnPrintAudited.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintAudited.Name = "btnPrintAudited";
            this.btnPrintAudited.Size = new System.Drawing.Size(75, 53);
            this.btnPrintAudited.TabIndex = 36;
            this.btnPrintAudited.Text = "PRINT MULTIPLE WP (AUDITED)";
            this.btnPrintAudited.UseVisualStyleBackColor = true;
            this.btnPrintAudited.Click += new System.EventHandler(this.btnPrintAudited_Click);
            // 
            // txtNote
            // 
            this.txtNote.AutoSize = true;
            this.txtNote.Location = new System.Drawing.Point(10, 578);
            this.txtNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(362, 13);
            this.txtNote.TabIndex = 35;
            this.txtNote.Text = "Note: RPs with Sales Breakdown cannot be shown on Printing Multiple WP";
            // 
            // pgbLoading
            // 
            this.pgbLoading.Location = new System.Drawing.Point(597, 78);
            this.pgbLoading.MarqueeAnimationSpeed = 1000;
            this.pgbLoading.Name = "pgbLoading";
            this.pgbLoading.Size = new System.Drawing.Size(393, 23);
            this.pgbLoading.TabIndex = 34;
            this.pgbLoading.Visible = false;
            // 
            // btnPrintRaw
            // 
            this.btnPrintRaw.Enabled = false;
            this.btnPrintRaw.Location = new System.Drawing.Point(416, 521);
            this.btnPrintRaw.Name = "btnPrintRaw";
            this.btnPrintRaw.Size = new System.Drawing.Size(75, 53);
            this.btnPrintRaw.TabIndex = 33;
            this.btnPrintRaw.Text = "PRINT MULTIPLE WP (RAW)";
            this.btnPrintRaw.UseVisualStyleBackColor = true;
            this.btnPrintRaw.Click += new System.EventHandler(this.btnPrintRaw_Click);
            // 
            // btnAWP
            // 
            this.btnAWP.Enabled = false;
            this.btnAWP.Location = new System.Drawing.Point(174, 522);
            this.btnAWP.Name = "btnAWP";
            this.btnAWP.Size = new System.Drawing.Size(75, 53);
            this.btnAWP.TabIndex = 32;
            this.btnAWP.Text = "REVIEW Audited WP";
            this.btnAWP.UseVisualStyleBackColor = true;
            this.btnAWP.Click += new System.EventHandler(this.btnAWP_Click);
            // 
            // btnEditWP
            // 
            this.btnEditWP.Enabled = false;
            this.btnEditWP.Location = new System.Drawing.Point(93, 522);
            this.btnEditWP.Name = "btnEditWP";
            this.btnEditWP.Size = new System.Drawing.Size(75, 53);
            this.btnEditWP.TabIndex = 31;
            this.btnEditWP.Text = "EDIT WP";
            this.btnEditWP.UseVisualStyleBackColor = true;
            this.btnEditWP.Click += new System.EventHandler(this.btnEditWP_Click);
            // 
            // btnViewWP
            // 
            this.btnViewWP.Enabled = false;
            this.btnViewWP.Location = new System.Drawing.Point(12, 522);
            this.btnViewWP.Name = "btnViewWP";
            this.btnViewWP.Size = new System.Drawing.Size(75, 53);
            this.btnViewWP.TabIndex = 1;
            this.btnViewWP.Text = "VIEW RAW WP";
            this.btnViewWP.UseVisualStyleBackColor = true;
            this.btnViewWP.Click += new System.EventHandler(this.btnViewWP_Click);
            // 
            // pbxLoading
            // 
            this.pbxLoading.Image = global::MSAS.Properties.Resources.blue_loading_gif_transparent_10;
            this.pbxLoading.Location = new System.Drawing.Point(566, 78);
            this.pbxLoading.Name = "pbxLoading";
            this.pbxLoading.Size = new System.Drawing.Size(25, 25);
            this.pbxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLoading.TabIndex = 30;
            this.pbxLoading.TabStop = false;
            this.pbxLoading.Visible = false;
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Location = new System.Drawing.Point(413, 82);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(95, 13);
            this.lblLoad.TabIndex = 10;
            this.lblLoad.Text = "Loading Text Here";
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(597, 17);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 53);
            this.btnUpload.TabIndex = 9;
            this.btnUpload.Text = "Upload Audited Data";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnDownloadRPA
            // 
            this.btnDownloadRPA.Location = new System.Drawing.Point(435, 17);
            this.btnDownloadRPA.Name = "btnDownloadRPA";
            this.btnDownloadRPA.Size = new System.Drawing.Size(75, 53);
            this.btnDownloadRPA.TabIndex = 8;
            this.btnDownloadRPA.Text = "Download RP Assignments";
            this.btnDownloadRPA.UseVisualStyleBackColor = true;
            this.btnDownloadRPA.Click += new System.EventHandler(this.btnDownloadRPA_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(515, 17);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 53);
            this.btnDownload.TabIndex = 7;
            this.btnDownload.Text = "Download Sales Data";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(298, 75);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 26);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Visible = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(223, 98);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(187, 20);
            this.txtUsername.TabIndex = 5;
            this.txtUsername.Visible = false;
            // 
            // chkHighRisk
            // 
            this.chkHighRisk.AutoSize = true;
            this.chkHighRisk.Location = new System.Drawing.Point(6, 78);
            this.chkHighRisk.Name = "chkHighRisk";
            this.chkHighRisk.Size = new System.Drawing.Size(149, 17);
            this.chkHighRisk.TabIndex = 4;
            this.chkHighRisk.Text = "Show High Risk RPs Only";
            this.chkHighRisk.UseVisualStyleBackColor = true;
            this.chkHighRisk.CheckedChanged += new System.EventHandler(this.chkHighRisk_CheckedChanged);
            // 
            // dgvAuditSchedule
            // 
            this.dgvAuditSchedule.AllowUserToAddRows = false;
            this.dgvAuditSchedule.AllowUserToResizeRows = false;
            this.dgvAuditSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAuditSchedule.Location = new System.Drawing.Point(6, 111);
            this.dgvAuditSchedule.MultiSelect = false;
            this.dgvAuditSchedule.Name = "dgvAuditSchedule";
            this.dgvAuditSchedule.RowHeadersVisible = false;
            this.dgvAuditSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAuditSchedule.Size = new System.Drawing.Size(984, 405);
            this.dgvAuditSchedule.TabIndex = 3;
            this.dgvAuditSchedule.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvAuditSchedule_CellBeginEdit);
            this.dgvAuditSchedule.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAuditSchedule_CellClick);
            this.dgvAuditSchedule.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAuditSchedule_CellValueChanged);
            this.dgvAuditSchedule.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAuditSchedule_ColumnHeaderMouseClick);
            // 
            // cmbYears
            // 
            this.cmbYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYears.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYears.FormattingEnabled = true;
            this.cmbYears.Location = new System.Drawing.Point(122, 44);
            this.cmbYears.Name = "cmbYears";
            this.cmbYears.Size = new System.Drawing.Size(84, 28);
            this.cmbYears.TabIndex = 2;
            this.cmbYears.SelectedIndexChanged += new System.EventHandler(this.cmbYears_SelectedIndexChanged);
            // 
            // cmbMonths
            // 
            this.cmbMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonths.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonths.FormattingEnabled = true;
            this.cmbMonths.Location = new System.Drawing.Point(6, 44);
            this.cmbMonths.Name = "cmbMonths";
            this.cmbMonths.Size = new System.Drawing.Size(110, 28);
            this.cmbMonths.TabIndex = 2;
            this.cmbMonths.SelectedIndexChanged += new System.EventHandler(this.cmbMonths_SelectedIndexChanged);
            // 
            // txtAuditor
            // 
            this.txtAuditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuditor.Location = new System.Drawing.Point(6, 12);
            this.txtAuditor.Name = "txtAuditor";
            this.txtAuditor.Size = new System.Drawing.Size(392, 26);
            this.txtAuditor.TabIndex = 1;
            this.txtAuditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAuditor_KeyPress);
            // 
            // bgwDownload
            // 
            this.bgwDownload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDownload_DoWork);
            this.bgwDownload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDownload_RunWorkerCompleted);
            // 
            // bgwDownloadRPA
            // 
            this.bgwDownloadRPA.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDownloadRPA_DoWork);
            this.bgwDownloadRPA.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDownloadRPA_RunWorkerCompleted);
            // 
            // bgwUpload
            // 
            this.bgwUpload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwUpload_DoWork);
            this.bgwUpload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwUpload_RunWorkerCompleted);
            // 
            // bgwDownloadRejected
            // 
            this.bgwDownloadRejected.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDownloadRejected_DoWork);
            this.bgwDownloadRejected.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDownloadRejected_RunWorkerCompleted);
            // 
            // AuditSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 609);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AuditSchedule";
            this.Text = "Megaworld Sales Audit System v5.1";
            this.Load += new System.EventHandler(this.AuditSchedule_Load);
            this.SizeChanged += new System.EventHandler(this.AuditSchedule_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAuditSchedule)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkHighRisk;
        private System.Windows.Forms.DataGridView dgvAuditSchedule;
        private System.Windows.Forms.ComboBox cmbYears;
        private System.Windows.Forms.ComboBox cmbMonths;
        public System.Windows.Forms.TextBox txtUsername;
        public System.Windows.Forms.TextBox txtAuditor;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnDownloadRPA;
        private System.ComponentModel.BackgroundWorker bgwDownload;
        private System.Windows.Forms.PictureBox pbxLoading;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.Button btnPrintRaw;
        private System.Windows.Forms.Button btnAWP;
        private System.Windows.Forms.Button btnEditWP;
        private System.Windows.Forms.Button btnViewWP;
        private System.Windows.Forms.ProgressBar pgbLoading;
        private System.ComponentModel.BackgroundWorker bgwDownloadRPA;
        private System.ComponentModel.BackgroundWorker bgwUpload;
        private System.Windows.Forms.Label txtNote;
        private System.Windows.Forms.Button btnPrintAudited;
        private System.Windows.Forms.Button btnViewFindings;
        private System.Windows.Forms.Button btnDownloadRejected;
        private System.ComponentModel.BackgroundWorker bgwDownloadRejected;
        private System.Windows.Forms.Button btnSpecialCase;
        private System.Windows.Forms.CheckBox chkVerified;
        private System.Windows.Forms.ComboBox cmbLocations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVerifiedRPCount;
        private System.Windows.Forms.Label lblRPCount;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAdjustments;
        private System.Windows.Forms.Button btnAdjRequest;
        private System.Windows.Forms.Button button3;
    }
}
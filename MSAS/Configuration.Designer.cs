namespace MSAS
{
    partial class Configuration
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
            this.txtLocSvr = new System.Windows.Forms.TextBox();
            this.txtLocDb = new System.Windows.Forms.TextBox();
            this.txtLocUser = new System.Windows.Forms.TextBox();
            this.txtLocPass = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCreateTables = new System.Windows.Forms.Button();
            this.txtLowRiskDays = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDownload = new System.Windows.Forms.Button();
            this.txtDataSrc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRmtDb = new System.Windows.Forms.TextBox();
            this.txtRmtPass = new System.Windows.Forms.TextBox();
            this.txtRmtSvr = new System.Windows.Forms.TextBox();
            this.txtRmtUser = new System.Windows.Forms.TextBox();
            this.btnTestConnect = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHighRiskDays = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLocSvr
            // 
            this.txtLocSvr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocSvr.Location = new System.Drawing.Point(78, 29);
            this.txtLocSvr.Name = "txtLocSvr";
            this.txtLocSvr.Size = new System.Drawing.Size(182, 23);
            this.txtLocSvr.TabIndex = 0;
            // 
            // txtLocDb
            // 
            this.txtLocDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocDb.Location = new System.Drawing.Point(78, 58);
            this.txtLocDb.Name = "txtLocDb";
            this.txtLocDb.Size = new System.Drawing.Size(182, 23);
            this.txtLocDb.TabIndex = 1;
            // 
            // txtLocUser
            // 
            this.txtLocUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocUser.Location = new System.Drawing.Point(78, 88);
            this.txtLocUser.Name = "txtLocUser";
            this.txtLocUser.Size = new System.Drawing.Size(182, 23);
            this.txtLocUser.TabIndex = 3;
            // 
            // txtLocPass
            // 
            this.txtLocPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocPass.Location = new System.Drawing.Point(78, 117);
            this.txtLocPass.Name = "txtLocPass";
            this.txtLocPass.Size = new System.Drawing.Size(182, 23);
            this.txtLocPass.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(288, 270);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtHighRiskDays);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.btnCreateTables);
            this.tabPage1.Controls.Add(this.txtLowRiskDays);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtLocDb);
            this.tabPage1.Controls.Add(this.txtLocPass);
            this.tabPage1.Controls.Add(this.txtLocSvr);
            this.tabPage1.Controls.Add(this.txtLocUser);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(280, 244);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Local Server";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnCreateTables
            // 
            this.btnCreateTables.Location = new System.Drawing.Point(185, 199);
            this.btnCreateTables.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCreateTables.Name = "btnCreateTables";
            this.btnCreateTables.Size = new System.Drawing.Size(75, 39);
            this.btnCreateTables.TabIndex = 14;
            this.btnCreateTables.Text = "Create Tables";
            this.btnCreateTables.UseVisualStyleBackColor = true;
            this.btnCreateTables.Click += new System.EventHandler(this.btnCreateTables_Click);
            // 
            // txtLowRiskDays
            // 
            this.txtLowRiskDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowRiskDays.Location = new System.Drawing.Point(144, 146);
            this.txtLowRiskDays.Name = "txtLowRiskDays";
            this.txtLowRiskDays.Size = new System.Drawing.Size(116, 23);
            this.txtLowRiskDays.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Low Risk (Min. # of Days):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Database:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server: ";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnDownload);
            this.tabPage2.Controls.Add(this.txtDataSrc);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtRmtDb);
            this.tabPage2.Controls.Add(this.txtRmtPass);
            this.tabPage2.Controls.Add(this.txtRmtSvr);
            this.tabPage2.Controls.Add(this.txtRmtUser);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(280, 214);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Remote Server";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(184, 175);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 39);
            this.btnDownload.TabIndex = 8;
            this.btnDownload.Text = "Download UserData";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // txtDataSrc
            // 
            this.txtDataSrc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataSrc.Location = new System.Drawing.Point(78, 147);
            this.txtDataSrc.Name = "txtDataSrc";
            this.txtDataSrc.Size = new System.Drawing.Size(182, 23);
            this.txtDataSrc.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Data Src:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Username:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Database:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Server: ";
            // 
            // txtRmtDb
            // 
            this.txtRmtDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRmtDb.Location = new System.Drawing.Point(78, 58);
            this.txtRmtDb.Name = "txtRmtDb";
            this.txtRmtDb.Size = new System.Drawing.Size(182, 23);
            this.txtRmtDb.TabIndex = 6;
            // 
            // txtRmtPass
            // 
            this.txtRmtPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRmtPass.Location = new System.Drawing.Point(78, 117);
            this.txtRmtPass.Name = "txtRmtPass";
            this.txtRmtPass.Size = new System.Drawing.Size(182, 23);
            this.txtRmtPass.TabIndex = 8;
            // 
            // txtRmtSvr
            // 
            this.txtRmtSvr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRmtSvr.Location = new System.Drawing.Point(78, 29);
            this.txtRmtSvr.Name = "txtRmtSvr";
            this.txtRmtSvr.Size = new System.Drawing.Size(182, 23);
            this.txtRmtSvr.TabIndex = 5;
            // 
            // txtRmtUser
            // 
            this.txtRmtUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRmtUser.Location = new System.Drawing.Point(78, 88);
            this.txtRmtUser.Name = "txtRmtUser";
            this.txtRmtUser.Size = new System.Drawing.Size(182, 23);
            this.txtRmtUser.TabIndex = 7;
            // 
            // btnTestConnect
            // 
            this.btnTestConnect.Location = new System.Drawing.Point(2, 276);
            this.btnTestConnect.Name = "btnTestConnect";
            this.btnTestConnect.Size = new System.Drawing.Size(75, 39);
            this.btnTestConnect.TabIndex = 6;
            this.btnTestConnect.Text = "Test Connection";
            this.btnTestConnect.UseVisualStyleBackColor = true;
            this.btnTestConnect.Click += new System.EventHandler(this.btnTestConnect_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(82, 276);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 39);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "High Risk (Min. # of Days):";
            // 
            // txtHighRiskDays
            // 
            this.txtHighRiskDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighRiskDays.Location = new System.Drawing.Point(144, 171);
            this.txtHighRiskDays.Name = "txtHighRiskDays";
            this.txtHighRiskDays.Size = new System.Drawing.Size(116, 23);
            this.txtHighRiskDays.TabIndex = 8;
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 331);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnTestConnect);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuration";
            this.Text = "Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Configuration_FormClosing);
            this.Load += new System.EventHandler(this.Configuration_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtLocSvr;
        private System.Windows.Forms.TextBox txtLocDb;
        private System.Windows.Forms.TextBox txtLocUser;
        private System.Windows.Forms.TextBox txtLocPass;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRmtDb;
        private System.Windows.Forms.TextBox txtRmtPass;
        private System.Windows.Forms.TextBox txtRmtSvr;
        private System.Windows.Forms.TextBox txtRmtUser;
        private System.Windows.Forms.Button btnTestConnect;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.TextBox txtDataSrc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLowRiskDays;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCreateTables;
        private System.Windows.Forms.TextBox txtHighRiskDays;
        private System.Windows.Forms.Label label11;
    }
}
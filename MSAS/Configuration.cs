using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MSAS
{
    public partial class Configuration : Form
    {
        
        public Configuration()
        {
            InitializeComponent();
            txtLocPass.UseSystemPasswordChar = true;
            txtRmtPass.UseSystemPasswordChar = true;
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            string path = @AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "app.config";
            string newPath = Path.Combine(path, fileName);
            string[] appConfig = System.IO.File.ReadAllLines(Path.Combine(path, fileName));
            try
            {
                txtLocSvr.Text = appConfig[0];
                txtLocDb.Text = appConfig[1];
                txtLocUser.Text = appConfig[2];
                txtLocPass.Text = appConfig[3];
                txtRmtSvr.Text = appConfig[4];
                txtRmtDb.Text = appConfig[5];
                txtRmtUser.Text = appConfig[6];
                txtRmtPass.Text = appConfig[7];
                txtDataSrc.Text = appConfig[8];
                txtLowRiskDays.Text = appConfig[9];
                txtHighRiskDays.Text = appConfig[10];
            }
            catch (Exception er)
            {

            }
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (LoginForm.localConnectionString.Contains("CLOUD"))
            {
                MessageBox.Show("Local Server Cannot Contain the word \"Cloud\", Contact a System Administrator or Developer for Assistance." + Environment.NewLine + "Canceling Download...");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(LoginForm.remoteConnectionString);
                    con.Open();
                    string sql = "spMSASDLUsers";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 180;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("rmtSvr", txtRmtSvr.Text);
                    cmd.Parameters.AddWithValue("rmtDb", txtRmtDb.Text);
                    cmd.Parameters.AddWithValue("locSvr", txtLocSvr.Text);
                    cmd.Parameters.AddWithValue("locDb", txtLocDb.Text);
                    cmd.ExecuteNonQuery();

                    string sql2 = "spMSASDLComponents";
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.CommandTimeout = 120;
                    cmd2.Parameters.Clear();
                    cmd2.Parameters.AddWithValue("rmtSvr", txtRmtSvr.Text);
                    cmd2.Parameters.AddWithValue("rmtDb", txtRmtDb.Text);
                    cmd2.Parameters.AddWithValue("locSvr", txtLocSvr.Text);
                    cmd2.Parameters.AddWithValue("locDb", txtLocDb.Text);
                    cmd2.ExecuteNonQuery();


                    string sql3 = "spMSASDLClassification";
                    SqlCommand cmd3 = new SqlCommand(sql3, con);
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.CommandTimeout = 120;
                    cmd3.Parameters.Clear();
                    cmd3.Parameters.AddWithValue("rmtSvr", txtRmtSvr.Text);
                    cmd3.Parameters.AddWithValue("rmtDb", txtRmtDb.Text);
                    cmd3.Parameters.AddWithValue("locSvr", txtLocSvr.Text);
                    cmd3.Parameters.AddWithValue("locDb", txtLocDb.Text);
                    cmd3.ExecuteNonQuery();


                    string sql4 = "spMSASDLNOE";
                    SqlCommand cmd4 = new SqlCommand(sql4, con);
                    cmd4.CommandType = CommandType.StoredProcedure;
                    cmd4.CommandTimeout = 120;
                    cmd4.Parameters.Clear();
                    cmd4.Parameters.AddWithValue("rmtSvr", txtRmtSvr.Text);
                    cmd4.Parameters.AddWithValue("rmtDb", txtRmtDb.Text);
                    cmd4.Parameters.AddWithValue("locSvr", txtLocSvr.Text);
                    cmd4.Parameters.AddWithValue("locDb", txtLocDb.Text);
                    cmd4.ExecuteNonQuery();


                    string sql5 = "spMSASDLRPStatuses";
                    SqlCommand cmd5 = new SqlCommand(sql5, con);
                    cmd5.CommandType = CommandType.StoredProcedure;
                    cmd5.CommandTimeout = 120;
                    cmd5.Parameters.Clear();
                    cmd5.Parameters.AddWithValue("rmtSvr", txtRmtSvr.Text);
                    cmd5.Parameters.AddWithValue("rmtDb", txtRmtDb.Text);
                    cmd5.Parameters.AddWithValue("locSvr", txtLocSvr.Text);
                    cmd5.Parameters.AddWithValue("locDb", txtLocDb.Text);
                    cmd5.ExecuteNonQuery();
                    MessageBox.Show("Successfully Downloaded User Data");
                    con.Close();
                }
                catch (Exception er)
                {
                    MessageBox.Show("Error : " + er.Message.ToString());
                }
            }

            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string path = @AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "app.config";
            string newPath = Path.Combine(path, fileName);
            using (FileStream fs = File.Create(newPath))
            {
                // Add default TEXTS inside the file 
                string appConfig = txtLocSvr.Text + "\n" + txtLocDb.Text + "\n";
                appConfig += txtLocUser.Text + "\n" + txtLocPass.Text + "\n";
                appConfig += txtRmtSvr.Text + "\n" + txtRmtDb.Text + "\n";
                appConfig += txtRmtUser.Text + "\n" + txtRmtPass.Text + "\n" + txtDataSrc.Text + "\n";
                appConfig += txtLowRiskDays.Text + "\n";
                appConfig += txtHighRiskDays.Text + "\n";
                Byte[] texts = new UTF8Encoding(true).GetBytes(appConfig);
                fs.Write(texts, 0, texts.Length);
            }
            LoginForm.remoteConnectionString = "Data Source=" + txtDataSrc.Text + ";Initial Catalog=" + txtRmtDb.Text + ";Persist Security Info=True;User ID=" + txtRmtUser.Text + ";Password=" + txtRmtPass.Text + ";";
            if (txtLocUser.Text == "" && txtLocPass.Text == ""){
                LoginForm.localConnectionString = "Data Source=" + txtLocSvr.Text + ";Initial Catalog=" + txtLocDb.Text + ";Integrated Security=SSPI;";
            }
            else{
                LoginForm.localConnectionString = "Data Source=" + txtLocSvr.Text + ";Initial Catalog=" + txtLocDb.Text + ";Persist Security Info=True;User ID=" + txtLocUser.Text + ";Password=" + txtLocPass.Text + ";";
            } 
            try
            {//Try to Convert if not ALL, if a number then save

                if (txtLowRiskDays.Text != "ALL")
                {
                    Convert.ToInt32(txtLowRiskDays.Text);
                }
                if (txtHighRiskDays.Text != "ALL")
                {
                    Convert.ToInt32(txtHighRiskDays.Text);
                }

                LoginForm.lowRiskDays = txtLowRiskDays.Text;
                LoginForm.highRiskDays = txtHighRiskDays.Text;
                MessageBox.Show("Configuration Saved.");
                this.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("Minimum Low/High Risk Days is Invalid/ Not Set");
            }
        }

        private void btnTestConnect_Click(object sender, EventArgs e)
        {

            if (LoginForm.localConnectionString.Contains("CLOUD"))
            {
                MessageBox.Show("Local Server Cannot Contain the word \"Cloud\", Contact a System Administrator or Developer for Assistance." + Environment.NewLine + "Canceling Test Connection...");
            }
            //else if (LoginForm.remoteConnectionString.Contains("CMEGAWORLDMALLS"))
            //{
            //    MessageBox.Show("Remote Server Configuration Cannot Contain the word \"CMEGAWORLDMALLS\", Contact a System Administrator or Developer for Assistance." + Environment.NewLine + "Canceling Login...");
            //} 
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(LoginForm.localConnectionString);
                    con.Open();
                    con.Close();
                    MessageBox.Show("Local Server Connection is Okay!");
                }
                catch (Exception er)
                {
                    MessageBox.Show("Local Server Connection Error: " + er.Message);
                }

                try
                {
                    SqlConnection con2 = new SqlConnection(LoginForm.remoteConnectionString);
                    con2.Open();
                    con2.Close();
                    MessageBox.Show("Cloud Server Connection is Okay!");
                }
                catch (Exception er)
                {
                    MessageBox.Show("Cloud Server Connection Error: " + er.Message);
                }
            }
        }

        private void btnCreateTables_Click(object sender, EventArgs e)
        {
            createTables();
        }

        public void createTables()
        {

            string path = @AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "schema.config";
            string newPath = Path.Combine(path, fileName);
            string[] schemaQuery = System.IO.File.ReadAllLines(Path.Combine(path, fileName));
            string query = "";

            for (int i = 0; i < schemaQuery.Length; i++)
            {
                query += " " + schemaQuery[i];
            }
            try
            {
                SqlConnection con = new SqlConnection(LoginForm.localConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.CommandTimeout = 180;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Tables Created Successfuly!");
                con.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show("Error: " + er.Message.ToString());
            }

        }

        private void Configuration_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool errorHandled = false;
            try
            {//Try to Convert if not ALL, if a number then save

                if (txtLowRiskDays.Text != "ALL")
                {
                    Convert.ToInt32(txtLowRiskDays.Text);
                }
                if (txtHighRiskDays.Text != "ALL")
                {
                    Convert.ToInt32(txtHighRiskDays.Text);
                }

                LoginForm.lowRiskDays = txtLowRiskDays.Text;
                LoginForm.highRiskDays = txtHighRiskDays.Text; 
            }
            catch (Exception er)
            {
                MessageBox.Show("Minimum Low/High Risk Days is Invalid/ Not Set");
                errorHandled = true;  
            }
             
            if (txtLocSvr.Text.Contains("CLOUD"))
            {
                errorHandled = true;
                MessageBox.Show("Local Server Cannot Contain the word \"Cloud\", Contact a System Administrator or Developer for Assistance." + Environment.NewLine + "Canceling Exit...");
                tabControl1.SelectedIndex = 0;
                txtLocSvr.Focus();
            }
            //else if (txtRmtDb.Text.Contains("CMEGAWORLDMALLS"))
            //{
            //    errorHandled = true;
            //    MessageBox.Show("Remote Server Configuration Cannot Contain the word \"CMEGAWORLDMALLS\", Contact a System Administrator or Developer for Assistance." + Environment.NewLine + "Canceling Exit...");
            //    tabControl1.SelectedIndex = 1;
            //    txtRmtDb.Focus();
            //} 

            if (errorHandled){
                e.Cancel = true;
            }
        }
    }
}

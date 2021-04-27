using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace MSAS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }
        public static string remoteConnectionString;
        public static string localConnectionString;
        public static string fullname;
        public static string admin = "ITAudit";
        public static string adminPass = "IT-@ud1tMSAS";
        public static string lowRiskDays = "1";
        public static string highRiskDays = "1";
        public void reSetConnectionString()
        {
            string path = @AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "app.config";
            string newPath = Path.Combine(path, fileName);
            string[] appConfig = System.IO.File.ReadAllLines(Path.Combine(path, fileName));
            remoteConnectionString = "Data Source=" + appConfig[8] + ";Initial Catalog=" + appConfig[5];
            remoteConnectionString += ";Persist Security Info=True;User ID=" + appConfig[6] + ";Password=" + appConfig[7] + ";";
            localConnectionString = "Data Source=" + appConfig[0] + ";Initial Catalog=" + appConfig[1];
            localConnectionString += ";Persist Security Info=True;User ID=" + appConfig[2] + ";Password=" + appConfig[3] + ";";
            //localConnectionString = "Data Source=" + "." + ";Initial Catalog=" + "AUDITOR";
            //localConnectionString += ";Integrated Security=SSPI;";
            //bool error = true;
            //while (error)
            //{
                try
                {
                    if (appConfig[9].ToString() != "ALL")
                    {
                        Convert.ToInt32(appConfig[9]);
                    }
                    if (appConfig[10].ToString() != "ALL")
                    {
                        Convert.ToInt32(appConfig[10]);
                    }
                    lowRiskDays =appConfig[9].ToString();
                    highRiskDays = appConfig[10].ToString();
                    //error = false;
                }
                catch (Exception er)
                {
                    MessageBox.Show("Minimum Low/High Risk Days is Invalid/ Not Set");
                    Configuration frmConfig = new Configuration();
                    frmConfig.StartPosition = FormStartPosition.CenterParent;
                    frmConfig.ShowDialog();
                }
            //}
        }
        private void btnWorkingPaper_Click(object sender, EventArgs e)
        {
            EditWorkingPaper ewp = new EditWorkingPaper();
            ewp.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = @AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "app.config";
            string newPath = Path.Combine(path, fileName);
            while (!File.Exists(newPath))
            {
                //then OPEN CONFIGURATION FORM
                Configuration frmConfig = new Configuration();
                frmConfig.StartPosition = FormStartPosition.CenterParent;
                frmConfig.ShowDialog();
            }
            reSetConnectionString();
            //this.WindowState = FormWindowState.Maximized;
            //this.panel1.Left = this.Width /
                //this.Left = this.Width / 2;
            //btnWorkingPaper.Location=  new Point(this.Width/2,this.Height/2);
            this.CenterToScreen();// = true;
        }
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public bool login(string username, string password)
        {
            try { 
            SqlConnection con = new SqlConnection(localConnectionString);
            con.Open();
            string sql = "SELECT COUNT(*) FROM USERSONLINE WHERE  username=@user AND password=@pass";
            //sql = "SELECT COUNT(*) FROM USERSONLINE WHERE  username=@user";//Comment/uncomment this for password restriction
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("user", txtUsername.Text);
            cmd.Parameters.AddWithValue("pass", Encrypt(txtPassword.Text));
            int count = 0;
            try
            {
                count = (int)cmd.ExecuteScalar();
            }
            catch (Exception er) { MessageBox.Show("Error : "+er.Message); }
            con.Close();
            if (count > 0) {
                con.Open();
                sql = "SELECT Firstname+' '+LastName FROM USERSONLINE WHERE  username=@user"; 
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("user", txtUsername.Text);
                fullname = (string)cmd.ExecuteScalar();
                con.Close();
                return true;
            }
            else
            {
                MessageBox.Show("Invalid account");
            }
            }
            catch(Exception er)
            { MessageBox.Show("Error : " + er.Message); }
            return false;
        }
        public static string username = "";
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (txtPassword.Text == adminPass && txtUsername.Text == admin)
            {
                Configuration config = new Configuration();
                config.StartPosition = FormStartPosition.CenterParent;
                config.ShowDialog();
                reSetConnectionString();
            }
            else if (localConnectionString.Contains("CLOUD"))
            {
                MessageBox.Show("Local Server Configuration Cannot Contain the word \"Cloud\", Contact a System Administrator or Developer for Assistance." + Environment.NewLine + "Canceling Login...");
                MessageBox.Show(localConnectionString);
            }
            //else if(remoteConnectionString.Contains("CMEGAWORLDMALLS"))--for RPSMS Migration 01-19-2021
            //{
            //    MessageBox.Show("Remote Server Configuration Cannot Contain the word \"CMEGAWORLDMALLS\", Contact a System Administrator or Developer for Assistance." + Environment.NewLine + "Canceling Login...");
            //}
            else if (txtPassword.Text == "" || txtUsername.Text == "")
            {
                MessageBox.Show("Fields cannot be empty.");
            }
            else if (login(txtUsername.Text,txtPassword.Text)){
                //open audit sched
                username=txtUsername.Text;
                AuditSchedule auditsched = new AuditSchedule();
                this.Hide();
                auditsched.txtAuditor.Text = fullname;
                auditsched.txtUsername.Text = txtUsername.Text;
                auditsched.ShowDialog();
                
                
                this.Visible = true;
            }
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            this.AcceptButton = this.btnLogin;
        }
    }
}

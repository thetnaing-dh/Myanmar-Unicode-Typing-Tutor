using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UnicodeTyping
{
    public partial class FormLogin : Form
    {       
        DBConnection db = new DBConnection();
        SQLiteCommand cmd;
        SQLiteDataReader dr;
		string productkey = ComputerInfo.GetProductKey();

		public FormLogin()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleparam = base.CreateParams;
                handleparam.ExStyle |= 0x02000000;
                return handleparam;
            }
        }
        string CheckProductKey()
		{
			string key = "";
			try
			{
				db.cn.Open();
				cmd = new SQLiteCommand("select productkey from register where id like (select max(id) from register)", db.cn);
				dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					key = dr.GetString(0);
				}
				dr.Close();
				db.cn.Close();
			}
			catch
			{
				db.cn.Close();
			}
			return key;
		}

		void checkReg()
		{
			try
			{
				string storeProductKey = CheckProductKey();
				if (storeProductKey == productkey || storeProductKey == "Success Professional Institute")
				{
					db.cn.Open();
					cmd = new SQLiteCommand("select expired from register where expired like '2021-06-21' and id = (select max(id) from register)", db.cn);
					dr = cmd.ExecuteReader();
					dr.Read();
					if (dr.HasRows)
					{
                        dr.Close();
                       	SQLiteCommand cmd1 = new SQLiteCommand("update register set expired = date('now','30 days'),syscode = unixepoch(date('now','30 days')),productkey ='" + productkey + "' where expired like '2021-06-21'", db.cn);
						cmd1.ExecuteNonQuery();
                        Status.valid = 30;
                    }
					else
					{
						dr.Close();
						cmd = new SQLiteCommand("select strftime(\"%Y-%m-%d\", syscode, 'unixepoch') expired from register where id = (select max(id) from register)", db.cn);
						dr = cmd.ExecuteReader();
						while (dr.Read())
						{
							Status.expire = Convert.ToDateTime(dr["expired"].ToString());
							Status.valid = (Status.expire - DateTime.Now).Days + 1;
						}
						dr.Close();
					}
					db.cn.Close();
				}
				else
				{
					Status.valid = 0;
				}
			}
			catch
			{
				db.cn.Close();
				Status.valid = 0;
			}
		}

		void loadRecord()
        {
            try
            {
                db.cn.Open();
                cmd = new SQLiteCommand("select * from settings", db.cn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Status.title = dr["title"].ToString();
					this.Text = Status.title;
                    byte[] img = dr["loginImage"] as byte[];
					if (img != null)
					{
						MemoryStream ms = new MemoryStream(img);
                        this.BackgroundImageLayout =ImageLayout.Stretch;
						this.BackgroundImage = Image.FromStream(ms);
					}
					else
					{
						this.BackgroundImage = null;
					}
				}
                dr.Close();
                db.cn.Close();               
            }
            catch
            {
                db.cn.Close();              
            }
        }

        void addUser()
        {
            try
            {
                db.cn.Open();
                cmd = new SQLiteCommand("Insert into users('username') values(@name)", db.cn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.ExecuteNonQuery();
                db.cn.Close();
            }
            catch
            {
                db.cn.Close();
            }
        }

        void loadUser()
        {
            try
            {
                dataGridView1.Rows.Clear();
                AutoCompleteStringCollection myCollection = new AutoCompleteStringCollection();
                db.cn.Open();
                cmd = new SQLiteCommand("select id,username from users", db.cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    myCollection.Add(dr["username"].ToString());
                    dataGridView1.Rows.Add(dr["id"].ToString(), dr["username"].ToString());
                }
                txtName.AutoCompleteCustomSource = myCollection;
                dr.Close();
                db.cn.Close();
                if (dataGridView1.Rows.Count < 1)
                {
                    panel1.Visible = false;
                }
            }
            catch
            {
                db.cn.Close();              
            }
        }

        void getLesson()
        {
            try
            {
                db.cn.Open();
                cmd = new SQLiteCommand("select id,eng,mya from users where username like @name", db.cn);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Status.userid = dr["id"].ToString();
                    Status.endEnglesson = Convert.ToInt32(dr["eng"].ToString());
                    Status.endlesson = Convert.ToInt32(dr["mya"].ToString());
                }
                dr.Close();
                db.cn.Close();
            }
            catch
            {
                db.cn.Close();           
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            loadRecord();       
			checkReg();
            loadUser();
		}

        private void lbName_Click(object sender, EventArgs e)
        {
            int c = dataGridView1.Rows.Count;

            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Height = 3;
                if (c <= 10)
                {
                    panel1.Height += 40 * c;
                }
                else
                {
                    panel1.Height = 40 * 10 + 3;
                }
                panel1.Visible = true;
            }
        }

        private void lbLogin_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Replace(" ", "") == String.Empty)
            {
                txtName.Clear();
                MessageBox.Show("Please enter your name!", Status.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }
            addUser();
            getLesson();

            this.Hide();           
			
            if (txtLanguage.Text == "English")
            {
                if (Screen.FromControl(this).Bounds.Width > 1536)
                {
                    // for 1920x1080 - 100%
                    FormEnglishTyping1536 frm = new FormEnglishTyping1536();
                    frm.ShowDialog();
                }

                else if (Screen.FromControl(this).Bounds.Width > 1366)
                {
                    // for 1920x1080 - 120%
                    FormEnglishTyping1536 frm = new FormEnglishTyping1536();
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();
                }

                else if (Screen.FromControl(this).Bounds.Width > 1280)
                {
                    // for 1366x768
                    FormEnglishTyping1366 frm = new FormEnglishTyping1366();
                    frm.ShowDialog();                   
                }
                else
                {
                    // for 1920x1080 - 150%
                    FormEnglishTyping1280 frm = new FormEnglishTyping1280();
                    frm.ShowDialog();
                }
            }
            else
            {
                if (Screen.FromControl(this).Bounds.Width > 1536)
                {
                    // for 1920x1080 - 100%
                    FormMyanmarTyping1536 frm = new FormMyanmarTyping1536();
                    frm.ShowDialog();
                }

                else if (Screen.FromControl(this).Bounds.Width > 1366)
                {
                    // for 1920x1080 - 120%
                    FormMyanmarTyping1536 frm = new FormMyanmarTyping1536();
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();
                }

                else if (Screen.FromControl(this).Bounds.Width > 1280)
                {
                    // for 1366x768
                    FormMyanmarTyping1366 frm = new FormMyanmarTyping1366();
                    frm.ShowDialog();
                }
                else
                {
                    // for 1920x1080 - 150%
                    FormMyanmarTyping1280 frm = new FormMyanmarTyping1280();
                    frm.ShowDialog();
                }
            }


            this.Show();
        }

        private void lbSetting_Click(object sender, EventArgs e)
        {
            try
            {
                db.cn.Open();
                cmd = new SQLiteCommand("select password from settings;", db.cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Status.password = dr["password"].ToString();
                }
                dr.Close();   
                db.cn.Close();
            }
            catch
            {
                db.cn.Close();
            }
            if (Status.password != string.Empty) { 
             FormPassword frm = new FormPassword();
             frm.ShowDialog();
            }
            else
            {
                FormSetting formSetting = new FormSetting();
                this.Hide();
                formSetting.ShowDialog();
                this.Show();
            }               
            loadRecord();
            loadUser();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 2)
                {
                    try
                    {
                        db.cn.Open();
                        cmd = new SQLiteCommand("delete from users where id like @id", db.cn);
                        cmd.Parameters.AddWithValue("@id", row.Cells[0].Value);
                        cmd.ExecuteNonQuery();
                        db.cn.Close();
                        loadUser();
                        txtName.Clear();
                    }
                    catch
                    {
                        return;
                    }
                }
                else
                {
                    txtName.Text = row.Cells[1].Value.ToString();
                    panel1.Visible = false;
                }
            }
        }

        private void lbManual_Click(object sender, EventArgs e)
        {
            string exePath =
  System.IO.Path.GetDirectoryName(
     System.Reflection.Assembly.GetEntryAssembly().Location);

            string file = exePath + @"\User Manual.pdf";
            Process.Start(file);
        }

        private void lbLanguage_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
            }
            else
            {
                panel2.Visible = true;
            }
        }

        private void lbEng_Click(object sender, EventArgs e)
        {
            txtLanguage.Text = lbEng.Text;
            panel2.Hide();
            lbLogin.Focus();
        }

        private void lbMyan_Click(object sender, EventArgs e)
        {
            txtLanguage.Text = lbMyan.Text;
            panel2.Hide();
            lbLogin.Focus();
        }
    }
}

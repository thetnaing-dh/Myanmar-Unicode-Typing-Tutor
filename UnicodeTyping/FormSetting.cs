using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace UnicodeTyping
{
    public partial class FormSetting : Form
    {      
        bool afterloading = false;
        DBConnection db = new DBConnection();
        SQLiteCommand cmd;
        SQLiteDataReader dr;
        byte[] img;
        MemoryStream ms = new MemoryStream();
        PictureBox tempPictureBox = new PictureBox();      

        public FormSetting()
        {
            InitializeComponent();
        }

        void loadRecord()
        {
            try
            {
                db.cn.Open();
                cmd = new SQLiteCommand("select * from settings", db.cn);
                dr = cmd.ExecuteReader();
                dr.Read();
                if(dr.HasRows) {                  
                   txtName.Text = dr["title"].ToString();
                   txtInfo.Text = dr["info"] == null ? "" : dr["info"].ToString();
                   txtPassword.Text = dr["password"].ToString();
                }
                dr.Close();
                db.cn.Close();
                afterloading = true;
            }
            catch
            {               
                db.cn.Close();
                afterloading = true;
            }
        }

        private void FormSetting_Load(object sender, EventArgs e)
        {
            loadRecord();
            this.Text = Status.title;
            try
            {
                db.cn.Open();
                cmd = new SQLiteCommand("delete from settings_tmp; insert into settings_tmp select * from settings;", db.cn);
                cmd.ExecuteNonQuery();
                db.cn.Close();
            }
            catch
            {
                db.cn.Close();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (afterloading==true)
                {
                    if (txtName.Text.Trim().Length > 0)
                    {
                        db.cn.Open();
                        cmd = new SQLiteCommand("update settings_tmp set title = @title", db.cn);
                        cmd.Parameters.AddWithValue("@title", txtName.Text);
                        Status.title = txtName.Text;
                        cmd.ExecuteNonQuery();
                        db.cn.Close();
                    }
                }             
            }
            catch 
            {              
                db.cn.Close();
            }
        }

        private void txtInfo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (afterloading)
                {
                    if (txtInfo.Text.Trim().Length > 0)
                    {
                        db.cn.Open();
                        cmd = new SQLiteCommand("update settings_tmp set info = @info", db.cn);
                        cmd.Parameters.AddWithValue("@info", txtInfo.Text);
                        cmd.ExecuteNonQuery();
                        db.cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.cn.Close();
            }
        }

        private void btnLoginImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image (*.JPG;*.PNG,*.GIF|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                ms = new MemoryStream();
                tempPictureBox.Image = Image.FromFile(opf.FileName);
                tempPictureBox.Image.Save(ms, tempPictureBox.Image.RawFormat);
                img = ms.ToArray();
            }

            try
            {
                if (img == null) return;
                db.cn.Open();
                cmd = new SQLiteCommand("update settings_tmp set loginImage=@image", db.cn);
                cmd.Parameters.AddWithValue("@image", img);
                cmd.ExecuteNonQuery();
                db.cn.Close();
            }
            catch 
            {              
                db.cn.Close();
            }
        }

        private void btnMainImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image (*.JPG;*.PNG,*.GIF|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                ms = new MemoryStream();
                tempPictureBox.Image = Image.FromFile(opf.FileName);
                tempPictureBox.Image.Save(ms, tempPictureBox.Image.RawFormat);
                img = ms.ToArray();
            }

            try
            {
                if (img == null) return;
                db.cn.Open();
                cmd = new SQLiteCommand("update settings_tmp set mainImage=@image", db.cn);
                cmd.Parameters.AddWithValue("@image", img);
                cmd.ExecuteNonQuery();
                db.cn.Close();
            }
            catch 
            {                
                db.cn.Close();
            }
        }

        private void btnResultImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image (*.JPG;*.PNG,*.GIF|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                ms = new MemoryStream();
                tempPictureBox.Image = Image.FromFile(opf.FileName);
                tempPictureBox.Image.Save(ms, tempPictureBox.Image.RawFormat);
                img = ms.ToArray();
            }

            try
            {
                if (img == null) return;
                db.cn.Open();
                cmd = new SQLiteCommand("update settings_tmp set resultImage=@image", db.cn);
                cmd.Parameters.AddWithValue("@image", img);
                cmd.ExecuteNonQuery();
                db.cn.Close();
            }
            catch
            {               
                db.cn.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Status.title = txtName.Text;
            try
            {
                db.cn.Open();
                cmd = new SQLiteCommand("delete from settings; insert into settings select * from settings_tmp;", db.cn);
                cmd.ExecuteNonQuery();
                db.cn.Close();
            }
            catch
            {
                db.cn.Close();
            }
            this.Close();
        }

        private void btnLoginReset_Click(object sender, EventArgs e)
        {
            try
            {
                db.cn.Open();
                cmd = new SQLiteCommand("update settings_tmp set loginimage=loginOriginalImage", db.cn);
                cmd.ExecuteNonQuery();
                db.cn.Close();
            }
            catch
            {
                db.cn.Close();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (afterloading == true)
                {
                    if (txtName.Text.Trim().Length > 0)
                    {
                        db.cn.Open();
                        cmd = new SQLiteCommand("update settings_tmp set password = @pass", db.cn);
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                        cmd.ExecuteNonQuery();
                        db.cn.Close();
                    }
                }
            }
            catch
            {
                db.cn.Close();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            FormReportViewer formReportViewer = new FormReportViewer();
            formReportViewer.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to clear all data?", Status.title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    db.cn.Open();
                    cmd = new SQLiteCommand("delete from users where id > 1; delete from results; update users set mya = 1 where id = 1; " +
                        "update sqlite_sequence set users = 1;", db.cn);
                    cmd.ExecuteNonQuery();
                    db.cn.Close();
                }
                catch
                {
                    db.cn.Close();
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.ShowDialog();
        }

        private void btnMainReset_Click(object sender, EventArgs e)
        {
            try
            {
                db.cn.Open();
                cmd = new SQLiteCommand("update settings_tmp set mainimage=mainOriginalImage", db.cn);
                cmd.ExecuteNonQuery();
                db.cn.Close();
            }
            catch
            {
                db.cn.Close();
            }
        }

        private void btnResultReset_Click(object sender, EventArgs e)
        {
            try
            {
                db.cn.Open();
                cmd = new SQLiteCommand("update settings_tmp set resultimage=resultOriginalImage", db.cn);
                cmd.ExecuteNonQuery();
                db.cn.Close();
            }
            catch
            {
                db.cn.Close();
            }
        }
    }
}

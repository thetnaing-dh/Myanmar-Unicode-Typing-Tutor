using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnicodeTyping
{
    public partial class FormResultEng : Form
    {
        DBConnection db = new DBConnection();
        SQLiteCommand cmd,cmd1;
        SQLiteDataReader dr;
        public string time, error, accu, speed;
        public int retry,retype;

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
                    byte[] img = dr["resultImage"] as byte[];
                    if (img != null)
                    {
                        MemoryStream ms = new MemoryStream(img);
                        this.BackgroundImageLayout = ImageLayout.Stretch;
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

        private void FormResult_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void FormResult_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        Status.typeEnglesson += 1;
                        this.Hide();
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Hide();
                        break;
                    }
            }
        }

        private void lbTry_Click(object sender, EventArgs e)
        {
           this.Hide();
        }

        private void lbNext_Click(object sender, EventArgs e)
        {
            if (Status.typeEnglesson == 29)
            {            
                Status.typeEnglesson = 1;
            }
            else
            {
               Status.typeEnglesson += 1;
            }
            this.Hide();
        }

        private void FormResult_Load(object sender, EventArgs e)
        {           
            this.Text = Status.title;
            loadRecord();
            lbTime.Text = time;
            lbError.Text = error;
            lbAccu.Text = accu;
            lbSpeed.Text = String.Format("{0:0.##}", (speed));
            try
            {
                db.cn.Open();        
                if (Status.typeEnglesson == Status.endEnglesson)
                {
                    if (Status.endEnglesson < 29)
                    {
                        cmd = new SQLiteCommand("update users set eng = @les + 1 where id like @stdid; insert into results values(@date,@stdid,@les,@time,@total,@speed,@accu,0);", db.cn);
                        cmd.Parameters.AddWithValue("@les", Status.endEnglesson);
                        Status.endEnglesson += 1;
                    }
                    else
                    {
                        bool isRepeat = false;
                        if (Status.typeEnglesson == 29)
                        {
                            cmd1 = new SQLiteCommand("select * from results where studentId like @stdid and lessonid like @les and myan_eng = 0;", db.cn);
                            cmd1.Parameters.AddWithValue("@stdid", Status.userid);
                            cmd1.Parameters.AddWithValue("@les", Status.typeEnglesson);
                            dr = cmd1.ExecuteReader();
                            dr.Read();
                            if (dr.HasRows)
                            {
                                isRepeat = true;
                            }
                            dr.Close();
                        }

                        if (isRepeat)
                        {
                            cmd = new SQLiteCommand("update results set date=@date,time=@time,totalWord=@total,speed=@speed,accuracy=@accu where studentId like @stdid and lessonid like @les and myan_eng = 0;", db.cn);
                            cmd.Parameters.AddWithValue("@les", Status.typeEnglesson);
                        }
                        else
                        {
                            cmd = new SQLiteCommand("insert into results values(@date,@stdid,@les,@time,@total,@speed,@accu,0);", db.cn);
                            cmd.Parameters.AddWithValue("@les", Status.endEnglesson);
                        }                       
                    }
                }
                else
                {
                    cmd = new SQLiteCommand("update results set date=@date,time=@time,totalWord=@total,speed=@speed,accuracy=@accu where studentId like @stdid and lessonid like @les and myan_eng = 0;", db.cn);
                    cmd.Parameters.AddWithValue("@les", Status.typeEnglesson);
                }
                cmd.Parameters.AddWithValue("@stdid", Status.userid);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@time", time);
                cmd.Parameters.AddWithValue("@total", error);
                cmd.Parameters.AddWithValue("@speed", speed);
                cmd.Parameters.AddWithValue("@accu", accu);
                cmd.ExecuteNonQuery();
                db.cn.Close();                
            }
            catch
            {             
                db.cn.Close();
            }
        }
            
        public FormResultEng()
        {
            InitializeComponent();
        }
    }
}

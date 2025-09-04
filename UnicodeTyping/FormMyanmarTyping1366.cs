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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace UnicodeTyping
{
    public partial class FormMyanmarTyping1366 : Form
    {
        int lHand = 0, rHand = 0, ercount = 0, sec = 1, s = 1, m = 0, y = 0;
    
        DBConnection db = new DBConnection();
        SQLiteCommand cmd;
        SQLiteDataReader dr;

        public FormMyanmarTyping1366()
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
                if (dr.HasRows)
                {  
                    byte[] img = dr["mainImage"] as byte[];
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

        private void txtTypingBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (txtView.Text.Substring(0, txtView.Text.Length - 1) != txtTypingBox.Text) return;
                    if (Status.valid == 0)
                    {
                        MessageBox.Show("Please register to practice next lessons!", Status.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormRegister frm = new FormRegister();
                        frm.ShowDialog();
                        return;
                    }
                    else
                    {
                        checkResult();
                    }
                    break;
            }
        }

        void checkResult()
        {
            float tcount = txtView.Text.Length;
            float speed = tcount / sec;
            try
            {
                FormResult frm = new FormResult();
                frm.time = String.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
                frm.error = txtTypingBox.Text.Length.ToString();
                frm.speed = (speed * 60).ToString("0");
                if (ercount == 0)
                {
                    frm.accu = "100";
                }
                else
                {
                    frm.accu = ((txtTypingBox.Text.Length - ercount) * 100 / txtTypingBox.Text.Length).ToString();
                }
                timer1.Stop();
                frm.ShowDialog();

                lbLesson.Text = "Lesson" + (Status.typelesson);
                txtView.Text = Lessons.myan[Status.typelesson - 1];              
                lbTxt.Text = Lessons.eng[Status.typelesson - 1];
                txtTypingBox.Text = "";
                lbSpeed.Text = "";
                txtView.SelectionLength = 0;
                txtView.SelectionStart = 0;
                getCharToType();              
                countErr();
                ercount = 0;
                m = 0;
                s = 1;
                sec = 1;
                timer1.Dispose();            
            }
            catch
            {

            }
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

        private void FormMyanmarTyping1366_Load(object sender, EventArgs e)
        {            
            this.Text = Status.title;
            Status.typelesson = Status.endlesson;                
            nextLevel(Status.typelesson);
            txtTypingBox.Focus();
            loadRecord();           
        }

        private void lbNext_Click(object sender, EventArgs e)
        {
            if(Status.endlesson < 29)
            {
                if (Status.typelesson == Status.endlesson) return;
                else Status.typelesson += 1;
            }
            else
            {
                if (Status.typelesson == 29)
                {
                    Status.typelesson = 1;
                }
                else
                {
                    Status.typelesson += 1;
                }
            }
            lbLesson.Text = "Lesson" + (Status.typelesson);
            txtView.Text = Lessons.myan[Status.typelesson - 1];
            lbTxt.Text = Lessons.eng[Status.typelesson - 1];
            txtTypingBox.Text = "";
            lbSpeed.Text = "";
            getCharToType();
            countErr();
            ercount = 0;
            m = 0;
            s = 1;
            sec = 1;
            timer1.Dispose();
        }

        private void lbPrevious_Click(object sender, EventArgs e)
        {
            if (Status.typelesson == 1) return;
            Status.typelesson -= 1;
            lbLesson.Text = "Lesson" + (Status.typelesson);
            txtView.Text = Lessons.myan[Status.typelesson - 1];
            lbTxt.Text = Lessons.eng[Status.typelesson - 1];
            txtTypingBox.Text = "";
            lbSpeed.Text = "";
            getCharToType();
            countErr();
            ercount = 0;
            m = 0;
            s = 1;
            sec = 1;
            timer1.Dispose();
        }

        void nextLevel(int les)
        {
            try
            {
                lbTxt.Text = Lessons.eng[les - 1];
                txtView.Text = Lessons.myan[les - 1];
                lbLesson.Text = "Lesson" + (les);
                getCharToType();
            }
            catch
            {  }
          
        }
     
        private void FormMyanmarTyping1366_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sec += 1;
            s += 1;
            if (s == 60)
            {
                s = 0;
                m += 1;
            }
            lbSpeed.Text = "Times : " + String.Format("{0}:{1}", m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));

        }

        void countErr()
        {
            int[] error = { 10, 16, 5, 14, 4, 6, 10, 10, 10, 4, 14, 13, 4, 16, 8, 2, 0, 8, 14, 12, 10, 12, 10, 17, 6, 4, 11, 5, 3 };

            ercount -= error[Status.typelesson - 1];

                    // char[] ch = Lessons.eng[Status.typelesson-1].ToCharArray();

                    //for (int i = 0; i < ch.Length; i++)
                    //{
                    //    if (ch[i] == 'a')
                    //    {
                    //        if (ch[i + 2] == 's')
                    //        {
                    //            ercount = ercount - 4;
                    //        }
                    //        else if (ch[i + 2] == 'G')
                    //        {
                    //            ercount = ercount - 4;
                    //        }
                    //        else if (ch[i + 2] == 'S')
                    //        {
                    //            ercount = ercount - 4;
                    //        }
                    //        else
                    //        {
                    //            ercount = ercount - 3;
                    //        }
                    //    }
                    //    else if (ch[i] == 'H')
                    //    {
                    //        if (ch[i + 1] == 'k')
                    //        {
                    //            ercount -= 1;
                    //        }
                    //    }
                    //}
            }

        void checkPyidaungsu()
        {
            try
            {
                char c = txtTypingBox.Text[txtTypingBox.Text.Length - 1];
                if ((int)c < 1000)
                {
                    if ((int)c == 32)
                    {
                        lbPyi.Visible = false;
                    }
                    else if ((int)c == 44)
                    {
                        lbPyi.Visible = false;
                    }
                    else if ((int)c == 46)
                    {
                        lbPyi.Visible = false;
                    }
                    else if ((int)c == 44)
                    {
                        lbPyi.Visible = false;
                    }
                    else if ((int)c == 39)
                    {
                        lbPyi.Visible = false;
                    }
                    else if ((int)c == 34)
                    {
                        lbPyi.Visible = false;
                    }
                    else if ((int)c == 47)
                    {
                        lbPyi.Visible = false;
                    }
                    else
                    {
                        lbPyi.Visible = true;
                    }
                }
                else { lbPyi.Visible = false; }
            }
            catch { }
        }

        void getCharToType()
        {
            lbHide();
            try
            {
                char c = lbTxt.Text[txtTypingBox.Text.Length - y];
                switch ((int)c)
                {
                    case 34:
                        lHand = 4;
                        rHand = 4;
                        lbLShift.Visible = true;
                        lbQuote.Visible = true;
                        break;
                    case 40:
                        lHand = 4;
                        rHand = 3;
                        lbLShift.Visible = true;
                        lb9.Visible = true;
                        break;
                    case 41:
                        lHand = 4;
                        rHand = 4;
                        lbLShift.Visible = true;
                        lb0.Visible = true;
                        break;
                    case 47:
                        lHand = 0;
                        rHand = 4;
                        lbSlash.Visible = true;
                        break;
                    case 63:
                        lHand = 4;
                        rHand = 4;
                        lbLShift.Visible = true;
                        lbSlash.Visible = true;
                        break;
                    case 64:
                        lHand = 3;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lb2.Visible = true;
                        break;
                    case 44:
                        lHand = 0;
                        rHand = 2;
                        lbLess.Visible = true;
                        break;
                    case 46:
                        lHand = 0;
                        rHand = 3;
                        lbGreater.Visible = true;
                        break;
                    case 32:
                        lHand = 5;
                        rHand = 5;
                        lbSpace.Visible = true;
                        break;
                    case 117:
                        lHand = 0;
                        rHand = 1;
                        lbU.Visible = true;
                        break;
                    case 99:
                        lHand = 2;
                        rHand = 0;
                        lbC.Visible = true;
                        break;
                    case 58:
                        lHand = 4;
                        rHand = 4;
                        lbLShift.Visible = true;
                        lbColon.Visible = true;
                        break;
                    case 67:
                        lHand = 2;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbC.Visible = true;
                        break;
                    case 105:
                        lHand = 0;
                        rHand = 2;
                        lbI.Visible = true;
                        break;
                    case 112:
                        lHand = 0;
                        rHand = 4;
                        lbP.Visible = true;
                        break;
                    case 113:
                        lHand = 4;
                        rHand = 0;
                        lbQ.Visible = true;
                        break;
                    case 90:
                        lHand = 4;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbZ.Visible = true;
                        break;
                    case 81:
                        lHand = 4;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbQ.Visible = true;
                        break;
                    case 78:
                        lHand = 4;
                        rHand = 1;
                        lbLShift.Visible = true;
                        lbN.Visible = true;
                        break;
                    case 110:
                        lHand = 0;
                        rHand = 1;
                        lbN.Visible = true;
                        break;
                    case 35:
                        lHand = 2;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lb3.Visible = true;
                        break;
                    case 88:
                        lHand = 3;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbX.Visible = true;
                        break;
                    case 33:
                        lHand = 4;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lb1.Visible = true;
                        break;
                    case 126:
                        lHand = 4;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbGrave.Visible = true;
                        break;
                    case 80:
                        lHand = 4;
                        rHand = 4;
                        lbLShift.Visible = true;
                        lbP.Visible = true;
                        break;
                    case 119:
                        lHand = 3;
                        rHand = 0;
                        lbW.Visible = true;
                        break;
                    case 120:
                        lHand = 3;
                        rHand = 0;
                        lbX.Visible = true;
                        break;
                    case 75:
                        lHand = 4;
                        rHand = 2;
                        lbLShift.Visible = true;
                        lbK.Visible = true;
                        break;
                    case 76:
                        lHand = 4;
                        rHand = 3;
                        lbLShift.Visible = true;
                        lbL.Visible = true;
                        break;
                    case 101:
                        lHand = 2;
                        rHand = 0;
                        lbE.Visible = true;
                        break;
                    case 121:
                        lHand = 0;
                        rHand = 1;
                        lbY.Visible = true;
                        break;
                    case 122:
                        lHand = 4;
                        rHand = 0;
                        lbZ.Visible = true;
                        break;
                    case 65:
                        lHand = 4;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbA.Visible = true;
                        break;
                    case 98:
                        lHand = 1;
                        rHand = 0;
                        lbB.Visible = true;
                        break;
                    case 114:
                        lHand = 1;
                        rHand = 0;
                        lbR.Visible = true;
                        break;
                    case 66:
                        lHand = 1;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbB.Visible = true;
                        break;
                    case 38:
                        lHand = 4;
                        rHand = 1;
                        lbLShift.Visible = true;
                        lb7.Visible = true;
                        break;
                    case 118:
                        lHand = 1;
                        rHand = 0;
                        lbV.Visible = true;
                        break;
                    case 87:
                        lHand = 3;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbW.Visible = true;
                        break;
                    case 111:
                        lHand = 0;
                        rHand = 3;
                        lbO.Visible = true;
                        break;
                    case 91:
                        lHand = 0;
                        rHand = 4;
                        lbOpenbrace.Visible = true;
                        break;
                    case 86:
                        lHand = 1;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbV.Visible = true;
                        break;
                    case 116:
                        lHand = 1;
                        rHand = 0;
                        lbT.Visible = true;
                        break;
                    case 48:
                        lHand = 0;
                        rHand = 4;
                        lb0.Visible = true;
                        break;
                    case 49:
                        lHand = 4;
                        rHand = 0;
                        lb1.Visible = true;
                        break;
                    case 50:
                        lHand = 3;
                        rHand = 0;
                        lb2.Visible = true;
                        break;
                    case 51:
                        lHand = 2;
                        rHand = 0;
                        lb3.Visible = true;
                        break;
                    case 52:
                        lHand = 1;
                        rHand = 0;
                        lb4.Visible = true;
                        break;
                    case 53:
                        lHand = 1;
                        rHand = 0;
                        lb5.Visible = true;
                        break;
                    case 54:
                        lHand = 0;
                        rHand = 1;
                        lb6.Visible = true;
                        break;
                    case 55:
                        lHand = 0;
                        rHand = 1;
                        lb7.Visible = true;
                        break;
                    case 56:
                        lHand = 0;
                        rHand = 2;
                        lb8.Visible = true;
                        break;
                    case 57:
                        lHand = 0;
                        rHand = 3;
                        lb9.Visible = true;
                        break;
                    case 45:
                        lHand = 0;
                        rHand = 4;
                        lbMinus.Visible = true;
                        break;
                    case 61:
                        lHand = 0;
                        rHand = 4;
                        lbPlus.Visible = true;
                        break;
                    case 43:
                        lHand = 4;
                        rHand = 4;
                        lbLShift.Visible = true;
                        lbPlus.Visible = true;
                        break;
                    case 95:
                        lHand = 4;
                        rHand = 4;
                        lbLShift.Visible = true;
                        lbMinus.Visible = true;
                        break;
                    case 97:
                        lHand = 4;
                        rHand = 0;
                        lbA.Visible = true;
                        y = 1;
                        break;
                    case 115:
                        lHand = 3;
                        rHand = 0;
                        lbS.Visible = true;
                        break;
                    case 83:
                        lHand = 3;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbS.Visible = true;
                        break;
                    case 100:
                        lHand = 2;
                        rHand = 0;
                        lbD.Visible = true;
                        break;
                    case 68:
                        lHand = 2;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbD.Visible = true;
                        break;
                    case 102:
                        lHand = 1;
                        rHand = 0;
                        lbF.Visible = true;
                        break;
                    case 70:
                        lHand = 1;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbF.Visible = true;
                        break;
                    case 103:
                        lHand = 1;
                        rHand = 0;
                        lbG.Visible = true;
                        break;
                    case 71:
                        lHand = 1;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbG.Visible = true;
                        break;
                    case 104:
                        lHand = 0;
                        rHand = 1;
                        lbH.Visible = true;
                        break;
                    case 72:
                        lHand = 4;
                        rHand = 1;
                        lbLShift.Visible = true;
                        lbH.Visible = true;
                        break;
                    case 106:
                        lHand = 0;
                        rHand = 1;
                        lbJ.Visible = true;
                        break;
                    case 74:
                        lHand = 4;
                        rHand = 1;
                        lbLShift.Visible = true;
                        lbJ.Visible = true;
                        break;
                    case 107:
                        lHand = 0;
                        rHand = 2;
                        lbK.Visible = true;
                        break;
                    case 108:
                        lHand = 0;
                        rHand = 3;
                        lbL.Visible = true;
                        break;
                    case 59:
                        lHand = 0;
                        rHand = 4;
                        lbColon.Visible = true;
                        break;
                    case 39:
                        lHand = 0;
                        rHand = 4;
                        lbQuote.Visible = true;
                        break;
                    case 60:
                        lHand = 4;
                        rHand = 2;
                        lbLShift.Visible = true;
                        lbLess.Visible = true;
                        break;
                    case 62:
                        lHand = 4;
                        rHand = 3;
                        lbLShift.Visible = true;
                        lbGreater.Visible = true;
                        break;
                    case 69:
                        lHand = 2;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbE.Visible = true;
                        break;
                    case 82:
                        lHand = 1;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbR.Visible = true;
                        break;
                    case 84:
                        lHand = 1;
                        rHand = 4;
                        lbRShift.Visible = true;
                        lbT.Visible = true;
                        break;
                    case 89:
                        lHand = 4;
                        rHand = 1;
                        lbLShift.Visible = true;
                        lbY.Visible = true;
                        break;
                    case 85:
                        lHand = 4;
                        rHand = 1;
                        lbLShift.Visible = true;
                        lbU.Visible = true;
                        break;
                    case 73:
                        lHand = 4;
                        rHand = 2;
                        lbLShift.Visible = true;
                        lbI.Visible = true;
                        break;
                    case 79:
                        lHand = 4;
                        rHand = 3;
                        lbLShift.Visible = true;
                        lbO.Visible = true;
                        break;
                    case 123:
                        lHand = 4;
                        rHand = 4;
                        lbLShift.Visible = true;
                        lbOpenbrace.Visible = true;
                        break;
                    case 93:
                        lHand = 0;
                        rHand = 4;
                        lbClosebrace.Visible = true;
                        break;
                    case 125:
                        lHand = 4;
                        rHand = 4;
                        lbLShift.Visible = true;
                        lbClosebrace.Visible = true;
                        break;
                    case 92:
                        lHand = 0;
                        rHand = 4;
                        lbBackslash.Visible = true;
                        break;
                    case 77:
                        lHand = 4;
                        rHand = 1;
                        lbLShift.Visible = true;
                        lbM.Visible = true;
                        break;
                    case 109:
                        lHand = 0;
                        rHand = 1;
                        lbM.Visible = true;
                        break;
                    default:
                        lHand = 0;
                        rHand = 4;
                        timer1.Stop();
                        lbEnter.Visible = true;
                        break;
                }
                hand();             
            }
            catch
            {
                y = 0;
                getCharToType();
            }
        }

        void lbHide()
        {
            lbGrave.Visible = false;
            lb1.Visible = false;
            lb2.Visible = false;
            lb3.Visible = false;
            lb4.Visible = false;
            lb5.Visible = false;
            lb6.Visible = false;
            lb7.Visible = false;
            lb8.Visible = false;
            lb9.Visible = false;
            lb0.Visible = false;
            lbMinus.Visible = false;
            lbPlus.Visible = false;
            lbA.Visible = false;
            lbB.Visible = false;
            lbC.Visible = false;
            lbD.Visible = false;
            lbE.Visible = false;
            lbF.Visible = false;
            lbG.Visible = false;
            lbH.Visible = false;
            lbI.Visible = false;
            lbJ.Visible = false;
            lbK.Visible = false;
            lbL.Visible = false;
            lbM.Visible = false;
            lbN.Visible = false;
            lbO.Visible = false;
            lbP.Visible = false;
            lbQ.Visible = false;
            lbR.Visible = false;
            lbS.Visible = false;
            lbT.Visible = false;
            lbU.Visible = false;
            lbV.Visible = false;
            lbW.Visible = false;
            lbX.Visible = false;
            lbY.Visible = false;
            lbZ.Visible = false;
            lbOpenbrace.Visible = false;
            lbClosebrace.Visible = false;
            lbColon.Visible = false;
            lbQuote.Visible = false;
            lbLess.Visible = false;
            lbGreater.Visible = false;
            lbSlash.Visible = false;
            lbBackslash.Visible = false;
            lbLShift.Visible = false;
            lbRShift.Visible = false;
            lbSpace.Visible = false;
            lbBack.Visible = false;
            lbEnter.Visible = false;
        }

        void hand()
        {
            if (lHand == 0)
            {
                lbLhand.Image = Properties.Resources.LFinger;
            }
            else if (lHand == 1)
            {
                lbLhand.Image = Properties.Resources.LIndex;
            }
            else if (lHand == 2)
            {
                lbLhand.Image = Properties.Resources.LMiddle;
            }
            else if (lHand == 3)
            {
                lbLhand.Image = Properties.Resources.LRing;
            }
            else if (lHand == 4)
            {
                lbLhand.Image = Properties.Resources.LLittle;
            }
            else
            {
                lbLhand.Image = Properties.Resources.LThumb;
            }

            if (rHand == 0)
            {
                lbRhand.Image = Properties.Resources.RFinger;
            }
            else if (rHand == 1)
            {
                lbRhand.Image = Properties.Resources.RIndex;
            }
            else if (rHand == 2)
            {
                lbRhand.Image = Properties.Resources.RMiddle;
            }
            else if (rHand == 3)
            {
                lbRhand.Image = Properties.Resources.RRing;
            }
            else if (rHand == 4)
            {
                lbRhand.Image = Properties.Resources.RLittle;
            }
            else
            {
                lbRhand.Image = Properties.Resources.RThumb;
            }
        }

        private void txtTypingBox_TextChanged(object sender, EventArgs e)
        {
            checkPyidaungsu();
            timer1.Start();
          
            if (txtTypingBox.Text == "")
            {
                getCharToType();
                timer1.Stop();
            }
            else if (txtTypingBox.Text + '\n' == txtView.Text)
            {
                if (Status.valid == 0)
                {
                    MessageBox.Show("Please register to practice next lessons!", Status.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormRegister frm = new FormRegister();
                    frm.ShowDialog();
                    return;
                }
                else
                {
                   countErr();                  
                   checkResult();
                }
            }
            else
            {
                try
                {
                    char a = ' ', h = ' ', k = ' ';
                    if (txtTypingBox.Text.Length >= 2)
                    {
                        a = lbTxt.Text[txtTypingBox.Text.Length - 2];
                    }
                    if (txtTypingBox.Text.Length >= 1)
                    {
                        h = lbTxt.Text[txtTypingBox.Text.Length - 1];
                        k = lbTxt.Text[txtTypingBox.Text.Length];
                    }
                    if (txtTypingBox.Text == txtView.Text.Substring(0, txtTypingBox.Text.Length))
                    {

                        y = 0;
                        if (h == 'H')
                        {
                            if (k == 'k')
                            {
                              //  ercount += 1;
                                txtTypingBox.ForeColor = Color.Red;
                                lbBack.Visible = true;
                            }
                        }
                        else
                        {
                            txtTypingBox.ForeColor = Color.Green;
                        }
                    }
                    else if (a == 'a')
                    {                       
                        txtTypingBox.ForeColor = Color.Green;                       
                    }
                    else if (h == 'H')
                    {
                        txtTypingBox.ForeColor = Color.Green;
                    }
                    else if (k == 'h' && h == 'f')
                    {
                        txtTypingBox.ForeColor = Color.Green;
                    }
                    else if (k == 'S' && h == 'j')
                    {
                        txtTypingBox.ForeColor = Color.Green;
                    }
                    else if (k == 'G' && h == 's')
                    {
                        txtTypingBox.ForeColor = Color.Green;
                    }
                    else if (k == 'S' && h == 'G')
                    {
                        txtTypingBox.ForeColor = Color.Green;
                    }
                    else if (h == 'a' && txtTypingBox.Text != txtView.Text.Substring(0, txtTypingBox.Text.Length))
                    {
                       // ercount += 1;
                        txtTypingBox.ForeColor = Color.Red;
                        lbBack.Visible = true;
                    }
                    else
                    {
                      //  ercount += 1;
                        txtTypingBox.ForeColor = Color.Red;
                        lbBack.Visible = true;
                    }                   
                }

                catch
                {
                    txtTypingBox.ForeColor = Color.Red;
                    lbBack.Visible = true;
                }

                if (txtTypingBox.ForeColor == Color.Green)
                {
                    getCharToType();
                }
                else
                {                             
                    ercount += 1;
                }

                if (txtTypingBox.Text.Length > 60)
                {
                    txtView.SelectionLength = 0;
                    txtView.SelectionStart = txtView.Text.Length;
                    txtView.ScrollToCaret();
                }
                else
                {
                    txtView.SelectionLength = 0;
                    txtView.SelectionStart = 0;
                }
            }
        }
    }
}

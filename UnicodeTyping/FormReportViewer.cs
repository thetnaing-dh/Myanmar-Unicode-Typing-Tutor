using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace UnicodeTyping
{
    public partial class FormReportViewer : Form
    {
        DBConnection db = new DBConnection();
        SQLiteCommand cmd, cmd1, cmd2;
        SQLiteDataAdapter da, da1, da2;
        DataTable dt, dt1, dt2;
        SQLiteDataReader dr1;

        public FormReportViewer()
        {
            InitializeComponent();
        }
        void checkDataToPrint()
        {
            dr1 = cmd.ExecuteReader();
            dr1.Read();
            if (dr1.HasRows == false)
            {
                dr1.Close();
                MessageBox.Show("No Data to Report!", Status.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.cn.Close();
                this.Close();
            }
            dr1.Close();
        }
        private void FormReportViewer_Load(object sender, EventArgs e)
        {
            this.Text = Status.title;
            reportViewer1.Refresh();
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            try
            {
                db.cn.Open();
                cmd = new SQLiteCommand("select username name,date,concat('Lesson : ',lessonid)lesson,time,totalWord,speed,accuracy,myan_eng from results r left join users u on r.studentId=u.id order by myan_eng", db.cn);
                checkDataToPrint();
                da = new SQLiteDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                cmd1 = new SQLiteCommand("select title,info from settings;", db.cn);
                da1 = new SQLiteDataAdapter(cmd1);
                dt1 = new DataTable();
                da1.Fill(dt1);

                ReportDataSource source = new ReportDataSource("DataSet1", dt);
                ReportDataSource source1 = new ReportDataSource("DataSet2", dt1);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.LocalReport.DataSources.Add(source1);

                reportViewer1.LocalReport.ReportPath = @".\Reports\rptStudentResults.rdlc";


                db.cn.Close();

            }
            catch
            {
                db.cn.Close();
            }

            this.reportViewer1.RefreshReport();
        }
    }
}

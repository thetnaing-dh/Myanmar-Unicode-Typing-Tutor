namespace UnicodeTyping
{
    partial class FormLogin
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.txtName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbMyan = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbEng = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtLanguage = new System.Windows.Forms.TextBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.lbManual = new System.Windows.Forms.Label();
            this.lbSetting = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLanguage = new System.Windows.Forms.Label();
            this.lbLogin = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtName.BackColor = System.Drawing.SystemColors.Info;
            this.txtName.Font = new System.Drawing.Font("Pyidaungsu", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtName.Location = new System.Drawing.Point(211, 206);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 40);
            this.txtName.TabIndex = 8;
            this.txtName.Text = "Student";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Location = new System.Drawing.Point(211, 247);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 124);
            this.panel1.TabIndex = 11;
            this.panel1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName,
            this.colDelete});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.dataGridView1.Location = new System.Drawing.Point(2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Pyidaungsu", 14.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(196, 120);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // colID
            // 
            this.colID.HeaderText = "id";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colName
            // 
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Pyidaungsu", 14.25F, System.Drawing.FontStyle.Bold);
            this.colName.DefaultCellStyle = dataGridViewCellStyle1;
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "";
            this.colDelete.Image = global::UnicodeTyping.Properties.Resources.delete;
            this.colDelete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Visible = false;
            this.colDelete.Width = 35;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(2, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(196, 2);
            this.panel9.TabIndex = 9;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(2, 122);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(196, 2);
            this.panel10.TabIndex = 8;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(198, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(2, 124);
            this.panel11.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel12.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(2, 124);
            this.panel12.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lbMyan);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.lbEng);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Location = new System.Drawing.Point(211, 318);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 76);
            this.panel2.TabIndex = 22;
            this.panel2.Visible = false;
            // 
            // lbMyan
            // 
            this.lbMyan.BackColor = System.Drawing.Color.PapayaWhip;
            this.lbMyan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbMyan.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbMyan.Font = new System.Drawing.Font("Pyidaungsu", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbMyan.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbMyan.Location = new System.Drawing.Point(2, 39);
            this.lbMyan.Name = "lbMyan";
            this.lbMyan.Size = new System.Drawing.Size(196, 35);
            this.lbMyan.TabIndex = 12;
            this.lbMyan.Text = "ပြည်ထောင်စု";
            this.lbMyan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbMyan.Click += new System.EventHandler(this.lbMyan_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(2, 37);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(196, 2);
            this.panel6.TabIndex = 11;
            // 
            // lbEng
            // 
            this.lbEng.BackColor = System.Drawing.Color.Ivory;
            this.lbEng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbEng.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbEng.Font = new System.Drawing.Font("Pyidaungsu", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbEng.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbEng.Location = new System.Drawing.Point(2, 2);
            this.lbEng.Name = "lbEng";
            this.lbEng.Size = new System.Drawing.Size(196, 35);
            this.lbEng.TabIndex = 10;
            this.lbEng.Text = "English";
            this.lbEng.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbEng.Click += new System.EventHandler(this.lbEng_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(2, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(196, 2);
            this.panel5.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(2, 74);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(196, 2);
            this.panel4.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(198, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(2, 76);
            this.panel3.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(2, 76);
            this.panel7.TabIndex = 0;
            // 
            // txtLanguage
            // 
            this.txtLanguage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtLanguage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLanguage.BackColor = System.Drawing.SystemColors.Info;
            this.txtLanguage.Font = new System.Drawing.Font("Pyidaungsu", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLanguage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtLanguage.Location = new System.Drawing.Point(212, 277);
            this.txtLanguage.Name = "txtLanguage";
            this.txtLanguage.ReadOnly = true;
            this.txtLanguage.Size = new System.Drawing.Size(199, 40);
            this.txtLanguage.TabIndex = 23;
            this.txtLanguage.Text = "English";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::UnicodeTyping.Properties.Resources.delete;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Visible = false;
            this.dataGridViewImageColumn1.Width = 35;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Pyidaungsu", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::UnicodeTyping.Properties.Resources.language;
            this.label3.Location = new System.Drawing.Point(82, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 35);
            this.label3.TabIndex = 24;
            // 
            // lbManual
            // 
            this.lbManual.BackColor = System.Drawing.Color.Transparent;
            this.lbManual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbManual.Image = global::UnicodeTyping.Properties.Resources.manual;
            this.lbManual.Location = new System.Drawing.Point(481, 519);
            this.lbManual.Name = "lbManual";
            this.lbManual.Size = new System.Drawing.Size(100, 38);
            this.lbManual.TabIndex = 17;
            this.lbManual.Click += new System.EventHandler(this.lbManual_Click);
            // 
            // lbSetting
            // 
            this.lbSetting.BackColor = System.Drawing.Color.Transparent;
            this.lbSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbSetting.Image = global::UnicodeTyping.Properties.Resources.setting;
            this.lbSetting.Location = new System.Drawing.Point(2, 2);
            this.lbSetting.Name = "lbSetting";
            this.lbSetting.Size = new System.Drawing.Size(30, 30);
            this.lbSetting.TabIndex = 16;
            this.lbSetting.Click += new System.EventHandler(this.lbSetting_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Image = global::UnicodeTyping.Properties.Resources.pyidaungsu;
            this.label2.Location = new System.Drawing.Point(52, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(480, 60);
            this.label2.TabIndex = 15;
            // 
            // lbName
            // 
            this.lbName.BackColor = System.Drawing.Color.Transparent;
            this.lbName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbName.Font = new System.Drawing.Font("Pyidaungsu", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Image = global::UnicodeTyping.Properties.Resources.down;
            this.lbName.Location = new System.Drawing.Point(416, 209);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(33, 33);
            this.lbName.TabIndex = 9;
            this.lbName.Click += new System.EventHandler(this.lbName_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Pyidaungsu", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::UnicodeTyping.Properties.Resources.name;
            this.label1.Location = new System.Drawing.Point(135, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 35);
            this.label1.TabIndex = 7;
            // 
            // lbLanguage
            // 
            this.lbLanguage.BackColor = System.Drawing.Color.Transparent;
            this.lbLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLanguage.Font = new System.Drawing.Font("Pyidaungsu", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLanguage.Image = global::UnicodeTyping.Properties.Resources.down;
            this.lbLanguage.Location = new System.Drawing.Point(417, 280);
            this.lbLanguage.Name = "lbLanguage";
            this.lbLanguage.Size = new System.Drawing.Size(33, 33);
            this.lbLanguage.TabIndex = 21;
            this.lbLanguage.Click += new System.EventHandler(this.lbLanguage_Click);
            // 
            // lbLogin
            // 
            this.lbLogin.BackColor = System.Drawing.Color.Transparent;
            this.lbLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLogin.Image = global::UnicodeTyping.Properties.Resources.Login;
            this.lbLogin.Location = new System.Drawing.Point(225, 351);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(138, 38);
            this.lbLogin.TabIndex = 19;
            this.lbLogin.Click += new System.EventHandler(this.lbLogin_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbManual);
            this.Controls.Add(this.lbSetting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtLanguage);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbLanguage);
            this.Controls.Add(this.lbLogin);
            this.Font = new System.Drawing.Font("Pyidaungsu", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unicode Typing";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbSetting;
        private System.Windows.Forms.Label lbManual;
        private System.Windows.Forms.Label lbLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbMyan;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbEng;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label lbLanguage;
        private System.Windows.Forms.TextBox txtLanguage;
        private System.Windows.Forms.Label label3;
    }
}


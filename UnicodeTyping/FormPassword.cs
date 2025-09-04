using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnicodeTyping
{
    public partial class FormPassword : Form
    {
        public FormPassword()
        {
            InitializeComponent();
        }

        private void FormPassword_Load(object sender, EventArgs e)
        {
            this.Text = Status.title;
        }

        void CheckPassword()
        {
            if (txtPassword.Text == Status.password)
            {
                FormSetting formSetting = new FormSetting();
                FormLogin formLogin = new FormLogin();
                formLogin.Hide();
                this.Hide();
                formSetting.ShowDialog();
                formLogin.Show();
            }
            else
            {
                MessageBox.Show("Invalid Password!", Status.title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CheckPassword();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                CheckPassword();
            }
        }
    }
}

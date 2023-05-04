using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarAppWebClient
{
    public partial class LoginForm : Form
    {
        private String parola;
        private String email;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Console.WriteLine(AppDomain.CurrentDomain.GetData("masterpassword.txt").ToString());
            email = textBoxUsername.Text;
            parola = textBoxPassword.Text;
            //under construction, awaiting for LoginService
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm form = new RegisterForm(this);
            form.ShowDialog();
        }

    }
}

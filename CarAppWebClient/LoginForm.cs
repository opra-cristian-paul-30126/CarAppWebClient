using CarAppWebClient.LoginService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
        bool isAdmin = false;
        User user;
        Admin admin;
        CarAppWebClient.LoginService.LoginServiceSoapClient loginService
        = new CarAppWebClient.LoginService.LoginServiceSoapClient();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            email = textBoxUsername.Text;
            parola = textBoxPassword.Text;

            if (IsValidEmail(email))
            {
                //adresa de email valida
                if (loginService.FoundEmail(email, isAdmin))
                {
                    //emailul este in database
                    if (loginService.CheckPassword(email, parola, isAdmin))
                    {

                        //login success new catalogue form
                        if (!isAdmin)
                        {
                            user = loginService.ReturnUser(email);
                            if (user.isBanned == 0)
                            {
                                BrowserForm bf = new BrowserForm(user);
                                bf.Show();
                            }
                            else
                            {
                                new ErrorForm(1);
                            }
                        }
                        else
                        {
                            admin = loginService.ReturnAdmin(email);
                            BrowserForm bf = new BrowserForm(admin);
                            bf.Show();
                        }
                    }
                    else
                    {
                        //hmmm
                        //parola incorecta
                        new ErrorForm(1);
                    }
                }
                else
                {

                    //eroare emailul nu este in database
                    new ErrorForm(2);
                }
            }
            else
            {
                //eroare invalid email
                new ErrorForm(3);
            }

        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm rf = new RegisterForm(this);
            rf.ShowDialog();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                isAdmin = true;
            }
            else
            {
                isAdmin = false;
            }
        }
    }
}

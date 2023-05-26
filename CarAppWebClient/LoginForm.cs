using CarAppWebClient.LoginService;
using System;
using System.Text.RegularExpressions;
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
        LoginServiceSoapClient loginService = new LoginServiceSoapClient();
        // string eyeOpen = Path.Combine(Application.StartupPath,  "eyeOpen.png");
        // string eyeClose = Path.Combine(Application.StartupPath, "eyeClose.png");

        public LoginForm()
        {
            InitializeComponent();
            textBoxPassword.UseSystemPasswordChar = true;
            // passBox.BackgroundImage = Image.FromFile(eyeClose);
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
                            if (!user.isBanned)
                            {
                                BrowserForm bf = new BrowserForm(user);
                                bf.Show();
                            }
                            else
                            {
                                new ErrorForm(13);
                            }
                        }
                        else
                        {
                            admin = loginService.ReturnAdmin(email);
                            BrowserForm bf = new BrowserForm(admin);
                            this.Tag = bf;
                            bf.Tag=this;
                            bf.Show();
                        }
                    }
                    else
                    {
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
            string pattern = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(email);
            return match.Success;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked) isAdmin = true;
            else isAdmin = false;   
        }

        private void passBox_CheckedChanged(object sender, EventArgs e)
        {
            if (passBox.Checked)
            //passBox.BackgroundImage = Image.FromFile(eyeOpen);
            textBoxPassword.UseSystemPasswordChar = false;
            else
            //passBox.BackgroundImage = Image.FromFile(eyeClose);
            textBoxPassword.UseSystemPasswordChar = true;
        }
    }
}

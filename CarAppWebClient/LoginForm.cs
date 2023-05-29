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
                // EMAIL IS VALID FORM
                if (loginService.FoundEmail(email, isAdmin))
                {
                    // EMAIL IS IN DATABASE
                    if (loginService.CheckPassword(email, parola, isAdmin))
                    {
                        // SUCCESSFUL LOGIN, OPENING BROWSER FORM
                        // REGULAR USER
                        if (!isAdmin)
                        {
                            user = loginService.ReturnUser(email);
                            // CHECK IF BANNED
                            if (!user.isBanned)
                            {
                                BrowserForm bf = new BrowserForm(user);
                                this.Hide();
                                bf.Show();
                                if (bf.IsDisposed)
                                {
                                    this.Show();
                                }
                            }
                            else
                            {
                                // BANNED USER
                                new ErrorForm(0,1);
                            }
                        }
                        // ADMIN
                        else
                        {
                            admin = loginService.ReturnAdmin(email);
                            BrowserForm bf = new BrowserForm(admin);
                            this.Hide();
                            bf.Show();
                            if (bf.IsDisposed)
                            {
                                this.Show();
                            }
                        }
                    }
                    else
                    {
                        //WRONG PASSWORD
                        new ErrorForm(0,0);
                    }
                }
                else
                {
                    // EMAIL NOT IN DATABASE
                    new ErrorForm(0,2);
                }
            }
            else
            {
                // INVALID EMAIL FORM
                new ErrorForm(0,3);
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

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

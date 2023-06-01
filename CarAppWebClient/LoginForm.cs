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
        private bool isAdmin = false;
        private User user;
        private Admin admin;
        private LoginServiceSoapClient loginService = new LoginServiceSoapClient();
        public LoginForm()
        {
            InitializeComponent();
            textBoxPassword.UseSystemPasswordChar = true;
        }

        // LOGIN
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            email  = textBoxUsername.Text;
            parola = textBoxPassword.Text;

            // CHECKS IF EMAIL IS IN CORRECT FORMAT
            if (IsValidEmail(email))
            {
                // CHECKS IF EMAIL IS IN DATABASE
                if (loginService.FoundEmail(email, isAdmin))
                {
                    // CHECKS PASSWORD
                    if (loginService.CheckPassword(email, parola, isAdmin))
                    {
                        // IF REGULAR USER
                        if (!isAdmin)
                        {
                            user = loginService.ReturnUser(email);
                            // CHECK IF NOT BANNED
                            if (!user.isBanned)
                            {
                                // SUCCESSFUL LOGIN, OPENING BROWSER FORM
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
                            // SUCCESSFUL LOGIN, OPENING BROWSER FORM
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

        // OPEN REGISTER FORM
        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm rf = new RegisterForm(this);
            rf.ShowDialog();
        }

        // CHEKS IF EMAIL IS IN VALID FORMAT (USERNAME@DOMAIN.TLD)
        private bool IsValidEmail(string email)
        {
            string pattern = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(email);
            return match.Success;
        }

        // CHANGES BACK AND FORTH THE LOGIN TYPE USER/ADMIN
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked) isAdmin = true;
            else isAdmin = false;   
        }

        // SHOWS/HIDES THE PASSWORD
        private void passBox_CheckedChanged(object sender, EventArgs e)
        {
            if (passBox.Checked)
                textBoxPassword.UseSystemPasswordChar = false;
            else
                textBoxPassword.UseSystemPasswordChar = true;
        }

        // CLOSES THE APPLICATION
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

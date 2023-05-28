using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CarAppWebClient
{
    public partial class RegisterForm : Form
    {
        CarAppWebClient.CreateAccountService.CreateAccountSoapClient createAccountService
    = new CarAppWebClient.CreateAccountService.CreateAccountSoapClient();

        private string imageLocation;
        private string nume;
        private string prenume;
        private string email;
        private string parola;
        private string confirmareParola;
        private string telefon;
        private string adresa;
        private string pass;
        private LoginForm lf;

        public RegisterForm(LoginForm lf)
        {
            this.lf = lf;
            InitializeComponent();
            lf.Visible = false;
            textBoxParola.UseSystemPasswordChar = false;
            textBoxConfirmareParola.UseSystemPasswordChar = false;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            lf.Visible = false;
            this.Close();
        }

        private byte[] ConvertImageToByteArray(System.Drawing.Image image, System.Drawing.Imaging.ImageFormat format)
        {
            byte[] rez;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, format);
                    rez = ms.ToArray();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return rez;
        }


        private void button_Ok_Click(object sender, EventArgs e)
        {
            if (!checkBoxAdmin.Checked)
            {
                prenume          = textBoxNume.Text;
                nume             = textBoxPrenume.Text;
                email            = textBoxEmail.Text;
                parola           = textBoxParola.Text;
                confirmareParola = textBoxConfirmareParola.Text;
                telefon          = textBoxTelefon.Text;
                adresa           = textBoxAdresa.Text;

                if (String.IsNullOrEmpty(prenume))
                {
                    // LAST NAME IS EMPTY
                    new ErrorForm(1,0);
                    return;
                }

                if (String.IsNullOrEmpty(nume))
                {
                    // FIRST NAME IS EMPTY
                    new ErrorForm(1,1);
                    return;
                }

                if (String.IsNullOrEmpty(email))
                {
                    // EMAIL IS EMPTY
                    new ErrorForm(1,2);
                    return;
                }

                if (!IsValidEmail(email))
                {
                    // EMAIL FORMAT NOT CORRECT
                    new ErrorForm(1,3);
                    return;
                }

                if (String.IsNullOrEmpty(parola))
                {
                    // PASSWORD IS EMPTY
                    new ErrorForm(1,4);
                    return;
                }

                if (!confirmareParola.Equals(parola))
                {
                    // PASSWORDS ARE NOT THE SAME
                    new ErrorForm(1,5);
                    return;
                }

                if(!ValidatePassword(parola))
                {
                    // PASSWORD FORMAT NOT CORECT
                    new ErrorForm(1,6);
                    return;
                }


                if (String.IsNullOrEmpty(telefon))
                {
                    telefon = String.Empty;
                }

                if (String.IsNullOrEmpty(adresa))
                {
                    adresa = String.Empty;
                }

                byte[] userImage = ConvertImageToByteArray(pictureBox.Image, System.Drawing.Imaging.ImageFormat.Png);

                bool success = createAccountService.createUserAcount(nume, prenume, email, parola, adresa, telefon, userImage);
                if (success) Console.WriteLine("Contul a fost inregistrat cu success!");
                else
                {
                    // ACCOUNT ALREADY IN DATABASE
                    new ErrorForm(1,7);
                    return;
                }
            }
            else if (createAccountService.checkPass(textBoxTelefon.Text))
            {
                prenume          = textBoxNume.Text;
                nume             = textBoxPrenume.Text;
                email            = textBoxEmail.Text;
                parola           = textBoxParola.Text;
                confirmareParola = textBoxConfirmareParola.Text;
                pass             = textBoxTelefon.Text;
                adresa           = textBoxAdresa.Text;

                if (String.IsNullOrEmpty(prenume))
                {
                    // LAST NAME IS EMPTY
                    new ErrorForm(1,0);
                    return;
                }

                if (String.IsNullOrEmpty(nume))
                {
                    // FIRST NAME IS EMPTY
                    new ErrorForm(1,1);
                    return;
                }

                if (String.IsNullOrEmpty(email))
                {
                    // EMAIL IS EMPTY
                    new ErrorForm(1,2);
                    return;
                }

                if (IsValidEmail(email))
                {
                    // EMAIL FORMAT NOT CORRECT
                    new ErrorForm(1,3);
                    return;
                }

                if (String.IsNullOrEmpty(parola))
                {
                    // PASSWORD IS EMPTY
                    new ErrorForm(1,4);
                    return;
                }
                
                if (!confirmareParola.Equals(parola))
                {
                    // PASSWORDS ARE NOT THE SAME
                    new ErrorForm(1,5);
                    return;
                }

                if (!ValidatePassword(parola))
                {
                    // PASSWORD FORMAT NOT CORRECT
                    new ErrorForm(1,6);
                    return;
                }

                if (String.IsNullOrEmpty(telefon))
                {
                    telefon = String.Empty;
                }

                if (String.IsNullOrEmpty(adresa))
                {
                    adresa = String.Empty;
                }

                byte[] userImage = ConvertImageToByteArray(pictureBox.Image, System.Drawing.Imaging.ImageFormat.Png);

                bool success = createAccountService.createAdminAcount(nume, prenume, email, parola, adresa, userImage);
                if (success) Console.WriteLine("Contul a fost inregistrat cu success!");
                else
                {
                    // ACCOUNT ALREADY IN DATABASE
                    new ErrorForm(1,7);
                    return;
                }
            }
            else
            {
                // WRONG ADMIN PASS
                new ErrorForm(1,8);
                return;
            }


            lf.Visible = true;
            this.Close();
        }

        private void checkBoxAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAdmin.Checked)
            {
                label_Adresa.Text   = "Contact";
                label_Telefon.Text  = "Permis";
                textBoxTelefon.Text = string.Empty;
                textBoxTelefon.UseSystemPasswordChar = true;
            }
            else
            {
                label_Adresa.Text   = "Adresa";
                label_Telefon.Text  = "Telefon";
                textBoxTelefon.Text = string.Empty;
                textBoxTelefon.UseSystemPasswordChar = false;
            }
        }

        private void button_Imagine_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();

            if (oFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageLocation = oFD.FileName;
                pictureBox.Image = Image.FromFile(imageLocation);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";

            Regex regex = new Regex(pattern);

            Match match = regex.Match(email);

            return match.Success;

        }

        private bool ValidatePassword(string password)
        {
            int minLength = 8;
            string specialCharacters = "!@#$%^&*()-=_+[]{}|;':,./<>?";

            bool hasValidCharachters   = password.Any(char.IsLetterOrDigit);
            bool hasMinimumLength      = password.Length >= minLength;
            bool hasUppercase          = password.Any(char.IsUpper);
            bool hasLowercase          = password.Any(char.IsLower);
            bool hasDigits             = password.Any(char.IsDigit);
            bool hasSpecialCharachters = password.Any(specialCharacters.Contains);

            return hasValidCharachters &&
                   hasMinimumLength &&
                   hasUppercase &&
                   hasLowercase &&
                   hasDigits &&
                   hasSpecialCharachters;
        }
    }
}

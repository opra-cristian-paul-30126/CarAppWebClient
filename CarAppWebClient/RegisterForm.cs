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
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarAppWebClient
{
    public partial class RegisterForm : Form
    {
        private CreateAccountService.CreateAccountSoapClient createAccountService = new CreateAccountService.CreateAccountSoapClient();
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
            InitializeComponent();
            this.lf = lf;
            lf.Enabled = false;
            textBoxParola.UseSystemPasswordChar = true;
            textBoxConfirmareParola.UseSystemPasswordChar = true;
        }

        // CLOSES WINDOW, RE-ENABLES LOGIN WINDOW
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
            lf.Enabled = true;
        }

        // CONVERTS IMAGE TO BYTE ARRAY
        private byte[] ConvertImageToByteArray(Image image, System.Drawing.Imaging.ImageFormat format)
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


        // REGISTERS A NEW ACCOUNT
        private void button_Ok_Click(object sender, EventArgs e)
        {
            // USER REGISTRATION
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

                if(!ValidatePassword(parola))
                {
                    // PASSWORD FORMAT NOT CORECT
                    new ErrorForm(1,6);
                    return;
                }

                if (!confirmareParola.Equals(parola))
                {
                    // PASSWORDS ARE NOT THE SAME
                    new ErrorForm(1, 5);
                    return;
                }

                if (String.IsNullOrEmpty(telefon))
                {
                    // TELEFON IS EMPTY
                    new ErrorForm(1, 9);
                    return;
                }

                if (String.IsNullOrEmpty(adresa))
                {
                    adresa = String.Empty;
                }

                // CONVERTS GIVEN PROFILE PICTURE
                byte[] userImage = ConvertImageToByteArray(pictureBox.Image, System.Drawing.Imaging.ImageFormat.Png);
                bool success = createAccountService.createUserAccount(nume, prenume, email, parola, adresa, telefon, userImage);

                if (success) Console.WriteLine("Contul a fost inregistrat cu success!");
                else
                {
                    // ACCOUNT ALREADY IN DATABASE
                    new ErrorForm(1,7);
                    return;
                }
            }
            // ADMIN REGISTRATION
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
                
                if (!ValidatePassword(parola))
                {
                    // PASSWORD FORMAT NOT CORRECT
                    new ErrorForm(1,6);
                    return;
                }

                if (!confirmareParola.Equals(parola))
                {
                    // PASSWORDS ARE NOT THE SAME
                    new ErrorForm(1, 5);
                    return;
                }

                if (String.IsNullOrEmpty(telefon))
                {
                    new ErrorForm(1, 7);
                    return;
                }

                if (String.IsNullOrEmpty(adresa))
                {
                    adresa = String.Empty;
                }

                // CONVERTS GIVEN PROFILE PICTURE
                byte[] userImage = ConvertImageToByteArray(pictureBox.Image, System.Drawing.Imaging.ImageFormat.Png);

                bool success = createAccountService.createAdminAccount(nume, prenume, email, parola, adresa, userImage);
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

            // CLOSE REGISTRATION WINDOW, RE-ENABLES LOGIN FORM
            this.Dispose();
            lf.Enabled = true;
            
        }

        // CHANGES BACK AND FORTH REGISTRATION TYPE
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

        // LOADS IMAGE FROM USER
        private void button_Imagine_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFD = new OpenFileDialog();

            if (oFD.ShowDialog() == DialogResult.OK)
            {
                imageLocation       = oFD.FileName;
                pictureBox.Image    = Image.FromFile(imageLocation);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        // CHECKS IF EMAIL IS IN CORRECT FORMAT (USERNAME@DOMAIN.TDL)
        private bool IsValidEmail(string email)
        {
            string pattern = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(email);
            return match.Success;
        }

        // CHECKS IF PASSWORD IS IN CORRECT FORMAT (LONGER THAN 8 CHARACTERS, AT LEAST 1 UPPER CHARACTER, 1 LOWER CHARACTER AND 1 SPECIAL CHARACTER)
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

        // RE-ENABLES LOGIN FORM IF CANCELED
        private void RegisterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            lf.Enabled = true;
        }

        // ENSURES THAT ONLY NUMBERS ARE INSERTED FOR TELEPHONE
        private void textBoxTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!checkBoxAdmin.Checked)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                    
            }
        }
    }
}

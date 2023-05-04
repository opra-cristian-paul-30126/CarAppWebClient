using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
        private string telefon;
        private string adresa;
        private string pass;
        private LoginForm lf;


        public RegisterForm(LoginForm lf)
        {
            this.lf = lf;
            InitializeComponent();
            lf.Visible = false;
            textBoxParola.UseSystemPasswordChar = true;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            lf.Visible=false;
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
                prenume = textBoxNume.Text;
                nume = textBoxPrenume.Text;
                email = textBoxEmail.Text;
                parola = textBoxParola.Text;
                telefon = textBoxTelefon.Text;
                adresa = textBoxAdresa.Text;

                if (String.IsNullOrEmpty(prenume))
                {
                    //numele nu poate fi nul
                    new ErrorForm(5);
                    return;
                }

                if (String.IsNullOrEmpty(nume))
                {
                    //prenumele nu poate fi nul
                    new ErrorForm(4);
                    return;
                }

                if (String.IsNullOrEmpty(email))
                {
                    //emailul nu poate fi nul
                    new ErrorForm(6);
                    return;
                }

                if (String.IsNullOrEmpty(parola))
                {
                    //parola nu poate fi nula
                    new ErrorForm(7);
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
                else Console.WriteLine("Eroare");
            }
            else if(createAccountService.checkPass(pass))
            {
                prenume = textBoxNume.Text;
                nume = textBoxPrenume.Text;
                email = textBoxEmail.Text;
                parola = textBoxParola.Text;
                pass = textBoxTelefon.Text;
                adresa = textBoxAdresa.Text;

                if (String.IsNullOrEmpty(prenume))
                {
                    //numele nu poate fi nul
                    new ErrorForm(5);
                    return;
                }

                if (String.IsNullOrEmpty(nume))
                {
                    //prenumele nu poate fi nul
                    new ErrorForm(4);
                    return;
                }

                if (String.IsNullOrEmpty(email))
                {
                    //emailul nu poate fi nul
                    new ErrorForm(6);
                    return;
                }

                if (String.IsNullOrEmpty(parola))
                {
                    //parola nu poate fi nula
                    new ErrorForm(7);
                    return;
                }

                if (String.IsNullOrEmpty(adresa))
                {
                    adresa = String.Empty;
                }

                byte[] userImage = ConvertImageToByteArray(pictureBox.Image, System.Drawing.Imaging.ImageFormat.Png);

                bool success = createAccountService.createAdminAcount(nume,prenume,email,parola,adresa,userImage);
                if (success) Console.WriteLine("Contul a fost inregistrat cu success!");
                else Console.WriteLine("Eroare");
            }
            else
            {
                new ErrorForm(8);
                return;
            }


            lf.Visible = true;
            this.Close();
        }

        private void checkBoxAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxAdmin.Checked)
            {
                label_Adresa.Text  = "Contact";
                label_Telefon.Text = "Permis";
                textBoxTelefon.Text = string.Empty;
                textBoxTelefon.UseSystemPasswordChar = true;
            }
            else
            {
                label_Adresa.Text  = "Adresa";
                label_Telefon.Text = "Telefon";
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
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}

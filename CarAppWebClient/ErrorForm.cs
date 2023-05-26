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
    public partial class ErrorForm : Form
    {
        int code;
        public ErrorForm(int code)
        {
            InitializeComponent();
            this.code = code;
            ShowError(code);
            this.Show();
        }

        public void ShowError(int ErrorCode)
        {
            switch (ErrorCode)
            {
                case 1:
                    labelError.Text = "Eroare: Parola incorecta!";
                    break;

                case 2:
                    labelError.Text = "Eroare: Emailul nu exista in baza de date!";
                    break;

                case 3:
                    labelError.Text = "Eroare: Emailul nu este in forma corecta!";
                    break;

                case 4:
                    labelError.Text = "Eroare: Prenumele nu poate fi nul!";
                    break;

                case 5:
                    labelError.Text = "Eroare: Numele nu poate fi nul!";
                    break;

                case 6:
                    labelError.Text = "Eroare: Emailul nu poate fi nul!";
                    break;

                case 7:
                    labelError.Text = "Eroare: Parola nu poate fi nula!";
                    break;
                case 8:
                    labelError.Text = "Nu stii passu'? Urat";
                    break;
                case 9:
                    labelError.Text = "Eroare: Parolele nu coincid!";
                    break;
                case 10:
                    labelError.Text = "Eroare: Emailul exista deja in baza de date!";
                    break;
                case 11:
                    labelError.Text = "Parola trebuie sa contina:\n" +
                      "- Minim 8 caractere\n" +
                      "- Cel putin o majuscula\n" +
                      "- Cel putin o litera mica\n" +
                      "- Cel putin o cifra\n" +
                      "- Cel putin un caracter special: (!@#$%^&*()-=_+[]{}|;':\",./<>?)";
                    break;
                case 13:
                    labelError.Text = "tesst";
                    break;
                default:
                    Console.WriteLine("Cod incorect");
                    break;
            }
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



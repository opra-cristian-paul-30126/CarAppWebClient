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
        private int code;
        private int form;
        public ErrorForm(int form ,int code)
        {
            InitializeComponent();
            this.form       = form;
            this.code       = code;
            ShowError(form, code);
            this.Show();
        }

        public void ShowError(int fromForm, int errorCode)
        {
            switch (fromForm)
            {
                // LOGIN FORM
            case 0:
                switch (errorCode)
                    {
                    // PRICE IS EMPTY 
                    case 0:
                        labelError.Text = "Pretul nu poate sa fie gol";
                        break;
                    // FIRST NAME IS EMPTY
                    case 1:
                        labelError.Text = "Prenumele nu poate fi gol";
                        break;
                    // EMAIL IS EMPTY
                    case 2:
                        labelError.Text = "Email-ul nu poate fi gol";
                        break;
                    // EMAIL FORMAT NOT CORRECT
                    case 3:
                        labelError.Text = "Email-ul nu este in formatul corect";
                        break;
                    // PASSWORD IS EMPTY
                    case 4:
                        labelError.Text = "Parola nu poate fi goala";
                        break;
                    // PASSWORDS ARE NOT THE SAME
                    case 5:
                       labelError.Text = "Parolele nu sunt la fel";
                       break;
                    // PASSWORD FORMAT NOT CORRECT
                    case 6:
                       labelError.Text = "Parola nu este in formatul corect";
                       break;
                    // ACCOUNT ALREADY IN DATABASE
                    case 7:
                       labelError.Text = "Contul este deja in data de baze";
                       break;
                    // WRONG ADMIN PASS
                    case 8:
                        labelError.Text = "Nu stii pass-ul? urat, foarte urat...";
                        break;
                    // DEFAULT
                    default:
                    break;
                }
                break; 
                // REGISTER FORM
            case 1:
                switch (errorCode)
                {
                    // LAST NAME IS EMPTY
                    case 0:
                        labelError.Text = "Numele nu poate fi gol";
                        break;
                    // FIRST NAME IS EMPTY
                    case 1:
                        labelError.Text = "Prenumele nu poate fi gol";
                        break;
                    // EMAIL IS EMPTY
                    case 2:
                        labelError.Text = "Email-ul nu poate fi gol";
                        break;
                    // EMAIL FORMAT NOT CORRECT
                    case 3:
                        labelError.Text = "Email-ul nu este in formatul corect";
                        break;
                    // PASSWORD IS EMPTY
                    case 4:
                        labelError.Text = "Parola nu poate fi goala";
                        break;
                    // PASSWORDS ARE NOT THE SAME
                    case 5:
                        labelError.Text = "Parolele nu sunt la fel";
                        break;
                    // PASSWORD FORMAT NOT CORRECT
                    case 6:
                        labelError.Text = "Parola nu este in formatul corect";
                        break;
                    // ACCOUNT ALREADY IN DATABASE
                    case 7:
                        labelError.Text = "Contul este deja in data de baze";
                        break;
                    // WRONG ADMIN PASS
                    case 8:
                        labelError.Text = "Nu stii pass-ul? urat, foarte urat...";
                        break;
                    // DEFAULT
                    default:
                    break;
                }
                break;
            // BROWSER FORM
            case 2:
                switch (errorCode)
                {
                    // DEFAULT
                    default:
                    break;
                }
            break;
            // MY ANNOUNCES FORM
            case 3:
                switch (errorCode)
                {
                    // NO SELECTION
                    case 1:
                       labelError.Text = "Nu ai selectat nici un anunt";
                       break;
                    // DEFAULT
                    default:
                    break;
                }
                break;
                // ADD/MODIFY FORM
            case 4:
                switch (errorCode)
                {
                    // PRICE IS EMPTY OR SOMEHOW IS NOT INT
                    case 0:
                        labelError.Text = "Pretul nu poate fi necompletat";
                        break;
                    // YEAR IS EMPTY OR SOMEHOW IS NOT INT
                    case 1:
                        labelError.Text = "Anul nu poate fi necompletat";
                        break;
                    // TOO OLD
                    case 2:
                        labelError.Text = "Cam vechi";
                        break;
                    // KM IS EMPTY OR SOMEHOW IS NOT INT
                    case 3:
                        labelError.Text = "Kilometrii nu pot fi necompletati";
                        break;
                    // PUTERECP IS EMPTY OR SOMEHOW IS NOT INT
                    case 4:
                        labelError.Text = "Puterea (CP) nu pot fi necompletata";
                        break;
                    // PUTEREKW IS EMPTY OR SOMEHOW IS NOT INT
                    case 5:
                        labelError.Text = "Puterea (KW) nu pot fi necompletata";
                        break;
                    case 6:
                    // CC IS EMPTY OR SOMEHOW IS NOT INT
                        labelError.Text = "CC nu pot fi necompletata";
                        break;
                    // DEFAULT
                    default:
                    break;
                    }
                 break;
            // VIEW ANNOUNCE
            case 5:
                break;
            // ADMIN TOOLS
            case 6:
                break;
            // DEFAULT
            default:
            break;

            }
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



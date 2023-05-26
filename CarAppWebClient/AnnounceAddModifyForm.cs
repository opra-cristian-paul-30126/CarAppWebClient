using System;
using CarAppWebClient.LoginService;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CarAppWebClient
{
    public partial class AnnounceAddModifyForm : Form
    {

        CarAppWebClient.CreateAnnouncementService.CreateAnnouncementSoapClient service
        = new CarAppWebClient.CreateAnnouncementService.CreateAnnouncementSoapClient();
        User user;
        //Announce announce;
        byte[] imageAnnounce;
        byte[] image1;
        byte[] image2;
        byte[] image3;


        public AnnounceAddModifyForm(User user)
        {
            this.user = user;
            InitializeComponent();
            init();
        }

        private void init()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            comboBoxCaroserie.Items.Clear();
            comboBoxCaroserie.Items.Add("Nespecificat");
            comboBoxCaroserie.Items.Add("Hatchback");
            comboBoxCaroserie.Items.Add("Sedan");
            comboBoxCaroserie.Items.Add("Combi");
            comboBoxCaroserie.Items.Add("Cabriolet");
            comboBoxCaroserie.Items.Add("Coupe");
            comboBoxCaroserie.Items.Add("Pick-up");
            comboBoxCaroserie.Items.Add("Off-road");
            comboBoxCaroserie.Items.Add("Alta caroserie");
            comboBoxCaroserie.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCaroserie.SelectedIndex = 0;

            comboBoxCuloare.Items.Clear();
            comboBoxCuloare.Items.Add("Nespecificat");
            comboBoxCuloare.Items.Add("Albastru");
            comboBoxCuloare.Items.Add("Rosu");
            comboBoxCuloare.Items.Add("Galben");
            comboBoxCuloare.Items.Add("Verde");
            comboBoxCuloare.Items.Add("Gri");
            comboBoxCuloare.Items.Add("Negru");
            comboBoxCuloare.Items.Add("Alb");
            comboBoxCuloare.Items.Add("Maro");
            comboBoxCuloare.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCuloare.SelectedIndex = 0;

            comboBoxCutieViteze.Items.Clear();
            comboBoxCutieViteze.Items.Add("Nespecificat");
            comboBoxCutieViteze.Items.Add("Manuala");
            comboBoxCutieViteze.Items.Add("Automata");
            comboBoxCutieViteze.Items.Add("Semi-automata");
            comboBoxCutieViteze.Items.Add("Secventiala");
            comboBoxCutieViteze.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCutieViteze.SelectedIndex = 0;

            comboBoxCombustibil.Items.Clear();
            comboBoxCombustibil.Items.Add("Nespecificat");
            comboBoxCombustibil.Items.Add("Benzina FTW");
            comboBoxCombustibil.Items.Add("Motorina");
            comboBoxCombustibil.Items.Add("GPL");
            comboBoxCombustibil.Items.Add("Hybrid");
            comboBoxCombustibil.Items.Add("Electric");
            comboBoxCombustibil.Items.Add("Altul");
            comboBoxCombustibil.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCombustibil.SelectedIndex = 0;
        }




        private void addOrModify(bool modify)
        {
            string marca = textBoxMarca.Text;
            string model = textBoxModel.Text;
            string varianta = textBoxVarianta.Text;
            string caroserie = comboBoxCaroserie.SelectedItem.ToString();
            string combustibil = comboBoxCombustibil.SelectedItem.ToString();
            string culoare = comboBoxCuloare.SelectedItem.ToString();
            string cutieViteze = comboBoxCutieViteze.SelectedItem.ToString();
            string descriere = richTextBoxDescriere.Text;
            string locatie = textBoxLocatie.Text;

            imageAnnounce = ConvertImageToByteArray(pictureBoxAnnounce.Image, System.Drawing.Imaging.ImageFormat.Png);
            image1 = ConvertImageToByteArray(pictureBox1.Image, System.Drawing.Imaging.ImageFormat.Png);
            image2 = ConvertImageToByteArray(pictureBox2.Image, System.Drawing.Imaging.ImageFormat.Png);
            image3 = ConvertImageToByteArray(pictureBox3.Image, System.Drawing.Imaging.ImageFormat.Png);



            int id = user.id;
            int km;
            int pret;
            int an;
            int putere;
            int putereKW;
            int cc;

            if (string.IsNullOrEmpty(marca)) marca = "Neselectat";
            if (string.IsNullOrEmpty(model)) model = "Neselectat";
            if (string.IsNullOrEmpty(varianta)) varianta = "Neselectat";
            if (string.IsNullOrEmpty(locatie)) locatie = user.adresa;


            if (!int.TryParse(textBoxPret.Text, out pret))
            {
                //Eroare nu se poate transforma pretul de vanzare din text in int
                new ErrorForm(10);
                return;
            }

            if (string.IsNullOrEmpty(textBoxAn.Text)) an = 1;
            else if (!int.TryParse(textBoxAn.Text, out an))
            {
                //Eroare nu se poate transforma anul de fabricatie din text in int
                new ErrorForm(12);
                return;
            }

            if (string.IsNullOrEmpty(textBoxKm.Text)) km = 1;
            else if (!int.TryParse(textBoxKm.Text, out km))
            {
                //Eroare nu se poate transforma km din text in int
                new ErrorForm(13);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPutere.Text)) putere = 1;
            else if (!int.TryParse(textBoxPutere.Text, out  putere))
            {
                //Eroare nu se poate transforma cp din text in int
                new ErrorForm(14);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPutereKW.Text)) putereKW = 1;
            else if (!int.TryParse(textBoxPutereKW.Text, out  putereKW))
            {
                //Eroare nu se poate transforma kw din text in int
                new ErrorForm(15);
                return;
            }

            if (string.IsNullOrEmpty(textBoxCC.Text)) cc = 1;
            else if (!int.TryParse(textBoxCC.Text, out cc))
            {
                //Eroare nu se poate transforma cc din text in int
                new ErrorForm(16);
                return;
            }

            if (modify)
                service.updateAnnouncee(id, caroserie, marca, model, varianta, pret, an, km, putere, putereKW, combustibil, cutieViteze, cc, culoare, locatie, descriere, imageAnnounce, image1, image2, image3);
            else
                service.addAnnounce(id, caroserie, marca, model, varianta, pret, an, km, putere,putereKW,combustibil,cutieViteze,cc,culoare,locatie,descriere,imageAnnounce,image1,image2,image3);

            Close();
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


        private void onlyNumbers(object sender, KeyPressEventArgs e)
        {
            // Allow digits, backspace, and decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


 





        private void buttonAction_Click(object sender, EventArgs e)
        {
         //   if(buttonAction.Text)
            addOrModify(false);

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }





        private void setImage(PictureBox pb)
        {
            OpenFileDialog oFD = new OpenFileDialog();
            if (oFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(oFD.FileName);
                pb.Image = img;
            }
        }

        private void buttonImagAnnounce_Click(object sender, EventArgs e)
        {
            setImage(pictureBoxAnnounce);

        }
        private void buttonImag1_Click(object sender, EventArgs e)
        {
            setImage(pictureBox1);
        }
        private void buttonImag2_Click(object sender, EventArgs e)
        {
            setImage(pictureBox2);
        }
        private void buttonImag3_Click(object sender, EventArgs e)
        {
            setImage(pictureBox3);
        }

        private void textBoxPret_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBoxAn_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender,e);
        }

        private void textBoxKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBoxPutere_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBoxPutereKW_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }

        private void textBoxCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumbers(sender, e);
        }
    }
}

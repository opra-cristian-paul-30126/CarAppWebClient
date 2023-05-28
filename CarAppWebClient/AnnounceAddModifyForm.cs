using System;
using CarAppWebClient.LoginService;
using CarAppWebClient.BrowseService;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace CarAppWebClient
{
    public partial class AnnounceAddModifyForm : Form
    {

        CreateAnnouncementService.CreateAnnouncementSoapClient service
        = new CreateAnnouncementService.CreateAnnouncementSoapClient();
        User user;
        private Announce announce;
        private byte[] imageAnnounce;
        private byte[] image1;
        private byte[] image2;
        private byte[] image3;
        bool modify;

        public AnnounceAddModifyForm(User user)
        {
            InitializeComponent();
            this.user         = user;
            announce          = null;
            modify            = false;
            buttonAction.Text = "Adauga";

            init();
        }

        
        public AnnounceAddModifyForm(Announce announce, User user)
        {
            InitializeComponent();
            this.user         = user;
            this.announce     = announce;
            modify            = true;
            buttonAction.Text = "Modifica";
            initAlt();
        }
        

        private void init()
        {
            pictureBoxAnnounce.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.SizeMode        = PictureBoxSizeMode.CenterImage;
            pictureBox2.SizeMode        = PictureBoxSizeMode.CenterImage;
            pictureBox3.SizeMode        = PictureBoxSizeMode.CenterImage;

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
        
        private void initAlt()
        {
            init();
            textBoxMarca.Text         = announce.marca;
            textBoxModel.Text         = announce.model;
            textBoxVarianta.Text      = announce.varianta;
            textBoxAn.Text            = announce.an.ToString();
            textBoxKm.Text            = announce.km.ToString();
            textBoxPutere.Text        = announce.putere.ToString();
            textBoxPutereKW.Text      = announce.putereKw.ToString();

            textBoxCC.Text            = announce.cc.ToString(); ;

            richTextBoxDescriere.Text = announce.descriere;
            textBoxLocatie.Text       = announce.locatie;
            imageAnnounce             = announce.imagAnunt;
            image1                    = announce.imag1;
          
            pictureBoxAnnounce.Image = ConvertByteArrayToImage(announce.imagAnunt);
            pictureBox1.Image        = ConvertByteArrayToImage(announce.imag1);
            pictureBox2.Image        = ConvertByteArrayToImage(announce.imag2);
            pictureBox3.Image        = ConvertByteArrayToImage(announce.imag3);


        }
        

        public System.Drawing.Image ConvertByteArrayToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            System.Drawing.Image rez = System.Drawing.Image.FromStream(ms);
            return rez;
        }



        private byte[] ConvertImageToByteArray(System.Drawing.Image image, System.Drawing.Imaging.ImageFormat format)
        {
            byte[] rez;
            if(image == null)
            {
                return null;
            }
            else
            {
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
        }

        private void addOrModify(bool modify)
        {
            string marca       = textBoxMarca.Text;
            string model       = textBoxModel.Text;
            string varianta    = textBoxVarianta.Text;
            string caroserie   = comboBoxCaroserie.SelectedItem.ToString();
            string combustibil = comboBoxCombustibil.SelectedItem.ToString();
            string culoare     = comboBoxCuloare.SelectedItem.ToString();
            string cutieViteze = comboBoxCutieViteze.SelectedItem.ToString();
            string descriere   = richTextBoxDescriere.Text;
            string locatie     = textBoxLocatie.Text;

            imageAnnounce = ConvertImageToByteArray(pictureBoxAnnounce.Image, System.Drawing.Imaging.ImageFormat.Png);
            image1        = ConvertImageToByteArray(pictureBox1.Image,        System.Drawing.Imaging.ImageFormat.Png);
            image2        = ConvertImageToByteArray(pictureBox2.Image,        System.Drawing.Imaging.ImageFormat.Png);
            image3        = ConvertImageToByteArray(pictureBox3.Image,        System.Drawing.Imaging.ImageFormat.Png);

            int id = user.id;
            int km;
            int pret;
            int an;
            int putere;
            int putereKW;
            int cc;


            if (string.IsNullOrEmpty(marca))       marca = "Neselectat";
            if (string.IsNullOrEmpty(model))       model = "Neselectat";
            if (string.IsNullOrEmpty(varianta)) varianta = "Neselectat";

            if (string.IsNullOrEmpty(culoare))
                if (string.IsNullOrEmpty(user.adresa))
                    locatie = "Nespecificat";
                else
                    locatie = user.adresa;
            else
                locatie = textBoxLocatie.Text;

            if (string.IsNullOrEmpty(textBoxPret.Text) || !int.TryParse(textBoxPret.Text, out pret))
            {
                // PRICE IS EMPTY OR SOMEHOW IS NOT INT
                new ErrorForm(4,0);
                return;
            }

            if (string.IsNullOrEmpty(textBoxAn.Text) || !int.TryParse(textBoxAn.Text, out an))
            {
                // YEAR IS EMPTY OR SOMEHOW IS NOT INT
                new ErrorForm(4,1);
                return;
            } 
            else if (an <1900)
            {
                // TOO OLD
                new ErrorForm(4,2);
                return;
            }

            if (string.IsNullOrEmpty(textBoxKm.Text) || !int.TryParse(textBoxKm.Text, out km))
            {
                // KM IS EMPTY OR SOMEHOW NOT INT
                new ErrorForm(4,3);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPutere.Text) || !int.TryParse(textBoxPutere.Text, out  putere))
            {
                // PUTERE (CP) IS EMPTY OR SOMEHOW NOT INT
                new ErrorForm(4,4);
                return;
            }

            if (string.IsNullOrEmpty(textBoxPutereKW.Text)|| !int.TryParse(textBoxPutereKW.Text, out putereKW))
            {
                // PUTERE(KW) IS EMPTY OR SOMEHOW NOT INT
                new ErrorForm(4,5);
                return;
            }

            if (string.IsNullOrEmpty(textBoxCC.Text) || !int.TryParse(textBoxCC.Text, out cc)) 
            {
                // CC IS EMPTY OR SOMEHOW NOT INT
                new ErrorForm(4,6);
                return;
            }

            if (modify)
            {
                int idAnnounce = announce.idAnunt;
                service.updateAnnouncee(idAnnounce, caroserie, marca, model, varianta, pret, an, km,
                putere, putereKW, combustibil, cutieViteze, cc, culoare, locatie, descriere,
                imageAnnounce, image1, image2, image3);
            }
            else
                service.addAnnounce(id, caroserie, marca, model, varianta, pret, an, km,
                putere, putereKW, combustibil, cutieViteze, cc, culoare, locatie, descriere,
                imageAnnounce, image1, image2, image3);

            Close();
        }

        private void buttonAction_Click(object sender, EventArgs e)
        {
            addOrModify(modify);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void buttonImagAnnounce_Click(object sender, EventArgs e) { setImage(pictureBoxAnnounce); }
        private void buttonImag1_Click(object sender, EventArgs e)        { setImage(pictureBox1); }
        private void buttonImag2_Click(object sender, EventArgs e)        { setImage(pictureBox2); }
        private void buttonImag3_Click(object sender, EventArgs e)        { setImage(pictureBox3); }


        private void onlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBoxPret_KeyPress(object sender, KeyPressEventArgs e)     { onlyNumbers(sender, e); }
        private void textBoxAn_KeyPress(object sender, KeyPressEventArgs e)       { onlyNumbers(sender, e); }
        private void textBoxKm_KeyPress(object sender, KeyPressEventArgs e)       { onlyNumbers(sender, e); }
        private void textBoxPutere_KeyPress(object sender, KeyPressEventArgs e)   { onlyNumbers(sender, e); }
        private void textBoxPutereKW_KeyPress(object sender, KeyPressEventArgs e) { onlyNumbers(sender, e); }
        private void textBoxCC_KeyPress(object sender, KeyPressEventArgs e)       { onlyNumbers(sender, e); }

        private void textBoxPutere_TextChanged(object sender, EventArgs e)
        {
            textBoxPutereKW.TextChanged -= textBoxPutereKW_TextChanged;
            if (int.TryParse(textBoxPutere.Text, out int cp))
            {
                textBoxPutereKW.Text = Math.Truncate(cp * 0.745).ToString();
            }
            textBoxPutereKW.TextChanged += textBoxPutereKW_TextChanged;
        }

        private void textBoxPutereKW_TextChanged(object sender, EventArgs e)
        {
            textBoxPutere.TextChanged -= textBoxPutere_TextChanged;
            if (int.TryParse(textBoxPutereKW.Text, out int kw))
            {
                textBoxPutere.Text = Math.Truncate(kw / 0.745).ToString();
            }
            textBoxPutere.TextChanged += textBoxPutere_TextChanged;
        }
    }
}

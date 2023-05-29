using CarAppWebClient.BrowseService;
using System;
using System.Windows.Forms;
using CarAppWebClient.LoginService;
using System.IO;
using System.Collections;

namespace CarAppWebClient
{
    public partial class ViewAnnounceForm : Form
    {
        private Announce announce;
        private User user;
        private Admin admin;
        public ViewAnnounceForm()
        {
            InitializeComponent();
        }

        public ViewAnnounceForm(Announce announce, User user)
        {
            InitializeComponent();
            this.user = user;
            this.announce = announce;
            init();
        }



        public ViewAnnounceForm(Announce announce, Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            this.announce = announce;
            init();
        }


        private void init()
        {
            pictureBoxAnnounce.Image = ConvertByteArrayToImage(announce.imagAnunt);
            pictureBoxImage1.Image = ConvertByteArrayToImage(announce.imag1);
            pictureBoxImage2.Image = ConvertByteArrayToImage(announce.imag2);
            pictureBoxImage3.Image = ConvertByteArrayToImage(announce.imag3);


            string announceData = $"Marca: {announce.marca}\n";
            announceData += "\n";
            announceData += $"Model: {announce.model}\n";
            announceData += "\n";
            announceData += $"Varianta: {announce.varianta}\n";
            announceData += "\n";
            announceData += $"Caroserie: {announce.caroserie}\n";
            announceData += "\n";
            announceData += $"Culoare: {announce.culoare}\n";
            announceData += "\n";
            announceData += $"An fabricatie: {announce.an}\n";
            announceData += "\n";
            announceData += $"Locatie: {announce.locatie}\n";
            announceData += "\n";
            announceData += $"Pret: {announce.pret}\n";
            announceData += "\n";
            announceData += $"Telefon: {announce.telefon}\n";
            announceData += "\n";
            announceData += $"Kilometraj: {announce.km}\n";
            announceData += "\n";
            announceData += $"Combustibil: {announce.combustibil}\n";
            announceData += "\n";
            announceData += $"Capacitate cilindrica: {announce.cc}\n";
            announceData += "\n";
            announceData += $"Putere: {announce.putere}\n";
            announceData += "\n";
            announceData += $"PutereKw: {announce.putereKw}\n";
            announceData += "\n";
            announceData += $"Cutie de viteze: {announce.cutieViteze}\n";
            announceData += "\n";
            announceData += $"Descriere: {announce.descriere}\n";
            announceData += "\n";

            richTextBox1.Text = announceData;

        }

        public System.Drawing.Image ConvertByteArrayToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            System.Drawing.Image rez = System.Drawing.Image.FromStream(ms);
            return rez;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (admin != null)
            {
                this.Dispose();
                new BrowserForm(admin).Show();
            }
            else
            {
                this.Dispose();
                new BrowserForm(user).Show();
            }
        }


        private void fullPicture(PictureBox pb)
        {
            if (pb.Image != null)
            {
                System.Drawing.Image image = pb.Image;
                int width = image.Width;
                int height = image.Height;
                PictureForm pf = new PictureForm(image);
                pf.ShowDialog();
            }
        }

        private void pictureBoxAnnounce_DoubleClick(object sender, EventArgs e)
        {
            fullPicture(pictureBoxAnnounce);
        }

        private void pictureBoxImage1_DoubleClick(object sender, EventArgs e)
        {
            fullPicture(pictureBoxImage1);
        }

        private void pictureBoxImage2_DoubleClick(object sender, EventArgs e)
        {
            fullPicture(pictureBoxImage2);
        }

        private void pictureBoxImage3_DoubleClick(object sender, EventArgs e)
        {
            fullPicture(pictureBoxImage3);
        }

        private void ViewAnnounceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

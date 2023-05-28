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
            Console.WriteLine(announce.imagAnunt.Length);
            foreach (byte b in announce.imagAnunt)
            {
                Console.Write($"{b}");
            }
            Console.WriteLine();
            pictureBoxAnnounce.Image = ConvertByteArrayToImage(announce.imagAnunt);
            pictureBoxImage1.Image   = ConvertByteArrayToImage(announce.imag1);
            pictureBoxImage2.Image   = ConvertByteArrayToImage(announce.imag2);
            pictureBoxImage3.Image   = ConvertByteArrayToImage(announce.imag3);
            richTextBox1.Text = announce.ToString();
        }



        public ViewAnnounceForm(Announce announce, Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            this.announce = announce;
            //pictureBoxAnnounce.Image = ConvertByteArrayToImage(announce.imagAnunt);
            //pictureBoxImage1.Image = ConvertByteArrayToImage(announce.imag1);
            //pictureBoxImage2.Image = ConvertByteArrayToImage(announce.imag2);
            //pictureBoxImage3.Image = ConvertByteArrayToImage(announce.imag3);
        }


        public System.Drawing.Image ConvertByteArrayToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            System.Drawing.Image rez = System.Drawing.Image.FromStream(ms);
            return rez;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
            if (admin != null)
            {
                BrowserForm bf = new BrowserForm(admin);
                bf.ShowDialog();
            }
            else
            {
                BrowserForm bf = new BrowserForm(user);
                bf.ShowDialog();
            }

        }


        private void fullPicture(object sender, MouseEventArgs e)
        {
            if (pictureBoxAnnounce.Image != null)
            {
                System.Drawing.Image image = pictureBoxAnnounce.Image;
                int width = image.Width;
                int height = image.Height;
                PictureForm pf = new PictureForm(width, height, image);
                pf.ShowDialog();
            }
        }

        private void pictureBoxAnnounce_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}

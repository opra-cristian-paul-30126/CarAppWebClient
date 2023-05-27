using CarAppWebClient.BrowseService;
using System;
using System.Windows.Forms;
using CarAppWebClient.LoginService;
using System.IO;

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
           // pictureBoxAnnounce.Image = ConvertByteArrayToImage(announce.imagAnunt);
           // pictureBoxImage1.Image   = ConvertByteArrayToImage(announce.imag1);
           // pictureBoxImage2.Image   = ConvertByteArrayToImage(announce.imag2);
           // pictureBoxImage3.Image   = ConvertByteArrayToImage(announce.imag3);
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
    }
}

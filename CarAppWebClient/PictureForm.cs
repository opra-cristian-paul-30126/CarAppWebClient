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
    public partial class PictureForm : Form
    {
        public PictureForm(System.Drawing.Image image)
        {
            InitializeComponent();
            panel.Dock = DockStyle.Fill;
            panel.AutoScroll = true;
            panel.AutoScrollMinSize = new Size(0, 0);

            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Image = image;

            panel.Controls.Add(pictureBox);
            Controls.Add(panel);
            AdjustFormSize();
        }
        private void AdjustFormSize()
        {
            int maxWidth = 1920;
            int maxHeight = 1080;

            Size imageSize = pictureBox.Image.Size;
            int formWidth = Math.Min(imageSize.Width, maxWidth);
            int formHeight = Math.Min(imageSize.Height, maxHeight);
            ClientSize= new Size(formWidth, formHeight);
        }
    }
}

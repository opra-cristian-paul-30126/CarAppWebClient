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
        public PictureForm(int width, int height, System.Drawing.Image image)
        {
            InitializeComponent();
            pictureBox.Image = image;
            pictureBox.Width= width; pictureBox.Height = height;
            this.Height = height+40;
            this.Width = width+20;
        }
    }
}

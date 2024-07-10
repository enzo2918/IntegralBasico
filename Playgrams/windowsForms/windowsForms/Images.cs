using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windowsForms
{
    public partial class Images : Form
    {
        public int indice;
        public Images()
        {
            InitializeComponent();
            indice = 0;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            var imagen = Image.FromFile("images.png");
            pictureBox1.Image = imagen;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            if (indice > 1) indice = 0;

            btnImagen.ImageIndex = indice;

            

            
            indice++;

            btnImagen.Enabled = true;
        }
    }
}

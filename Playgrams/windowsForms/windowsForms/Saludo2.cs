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
    public partial class Saludo2 : Form
    {
        public Saludo2()
        {
            InitializeComponent();
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void Saludo2_Load(object sender, EventArgs e)
        {
            lblSaludar.Text = string.Empty;
        }

        private void lblSaludar_Click(object sender, EventArgs e)
        {

        }

        private void btSaludar_Click(object sender, EventArgs e)
        {
            lblSaludar.Text = "Hola " + txtNombre.Text;
        }
    }
}

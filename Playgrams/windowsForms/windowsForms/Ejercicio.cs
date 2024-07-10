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
    public partial class Ejercicio : Form
    {
        public Ejercicio()
        {
            InitializeComponent();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCotizar_Click(object sender, EventArgs e)
        {
            var costo = 0.0;

            if (rbBasico.Checked)
            {
                costo = costo + 500;
            }
            else if (rbTerceros.Checked)
            {
                costo = costo + 700;
            }
            else if (rbCompleto.Checked)
            {
                costo = costo + 1000;
            }

            if (chkAire.Checked)
            {
                costo = costo + 300;
            }
            if (ChkAudio.Checked)
            {
                costo = costo + 200;
            }

            lblCostoCotizado.Text = costo.ToString();
        }

        private void Ejercicio_Load(object sender, EventArgs e)
        {
            lblCostoCotizado.Text = string.Empty;
        }
    }
}

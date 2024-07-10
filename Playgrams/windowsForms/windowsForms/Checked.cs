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
    public partial class Checked : Form
    {
        public Checked(double numero)
        {
            InitializeComponent();

            txtA.Text = numero.ToString();
        }

        public double numeroA { get; set; }
        public double numeroB { get; set; }
        private void chkMonitor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMonitor.Checked)
            {
                lblSeleccion.Text = chkMonitor.Text;
            }
            else lblSeleccion.Text = string.Empty;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            var total = 0;
            var a = double.Parse(txtA.Text);
            var b = double.Parse(txtB.Text);
            var r = 0.0;

            if (chkMonitor.Checked)
            {
                total = total + 250;
            }
            if (chkTeclado.Checked)
            {
                total = total + 50;
            }
            if (chkMouse.Checked)
            {
                total = total + 20;
            }

            if (rbSuma.Checked)
            {
                r = a + b;
            }
            else if (rbResta.Checked)
            {
                r = a - b;
            }
            else if (rbMulti.Checked)
            {
                r = a * b;
            }

            MessageBox.Show($"El total de la compra es ${total}");
            MessageBox.Show($"El total de la operacion es ${r}");



        }

        private void Checked_Load(object sender, EventArgs e)
        {
            lblSeleccion.Text = string.Empty;
            txtA.Text = numeroA.ToString();
            txtB.Text = numeroB.ToString();
        }

        private void chkTeclado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTeclado.Checked)
            {
                lblSeleccion.Text = chkTeclado.Text;
            }
            else lblSeleccion.Text = string.Empty;
        }

        private void Checked_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

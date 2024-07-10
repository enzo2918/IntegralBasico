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
    public partial class Saludo1 : Form
    {
        public Saludo1()
        {
            InitializeComponent();
        }

        private void btnSaludo_Click(object sender, EventArgs e)
        {
            lblSaludo.Text = "Hola a todos";
        }

        private void btnDespedir_Click(object sender, EventArgs e)
        {
            lblSaludo.Text = "Chau";
            this.Text = lblSaludo.Text + " Amigo";
        }

        private void Saludo1_Load(object sender, EventArgs e)
        {
            lblSaludo.Text = string.Empty;
        }
    }
}

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
    public partial class Calculadora : Form
    {
        public Checked checkedForm;
        public Calculadora()
        {
            InitializeComponent();

            var lblNew = new System.Windows.Forms.Label();
            lblNew.AutoSize = true;
            lblNew.Location = new System.Drawing.Point(171, 91);
            lblNew.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblNew.Name = "lblA";
            lblNew.Size = new System.Drawing.Size(16, 16);
            lblNew.TabIndex = 0;
            lblNew.Text = "C";
            Controls.Add(lblNew);
        }


        private void btnSuma_Click(object sender, EventArgs e)
        {
            var a = double.Parse(txtA.Text);
            var b = double.Parse(txtB.Text);

            var r = a + b;

            lblResult.Text = r.ToString();
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            try
            {
                var a = double.Parse(txtA.Text);
                var b = double.Parse(txtB.Text);
                if (b == 0)
                {
                    throw new Exception("La division por cero no esta definida");
                }
                var r = a / b;                
                lblResult.Text = r.ToString();
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }                        
        }

        private void lblB_Click(object sender, EventArgs e)
        {

        }

        private void Calculadora_Load(object sender, EventArgs e)
        {
            lblResult.Text = string.Empty;
            txtA.Text = "0";
            txtB.Text = "0";

        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            var a = double.Parse(txtA.Text);
            var b = double.Parse(txtB.Text);

            var r = a - b;

            lblResult.Text = r.ToString();
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            var a = double.Parse(txtA.Text);
            var b = double.Parse(txtB.Text);

            var r = a * b;

            lblResult.Text = r.ToString();
        }

        private void lblB_Enter(object sender, EventArgs e)
        {

        }

        private void btnChecked_Click(object sender, EventArgs e)
        {
            checkedForm = new Checked(0);
            checkedForm.numeroA = double.Parse(txtA.Text);
            checkedForm.numeroB = double.Parse(txtB.Text);
            checkedForm.Show();
            
        }
    }
}

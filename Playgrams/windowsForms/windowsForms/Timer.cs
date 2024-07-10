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
    public partial class Timer : Form
    {
        private int conteo;
        public Timer()
        {
            InitializeComponent();
            conteo = 0;
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            conteo++;
            lblContador.Text = conteo.ToString();
        }

        private void btnComenzar_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            conteo = 0;
            lblContador.Text = conteo.ToString();
        }

        private void Timer_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void Timer_Load(object sender, EventArgs e)
        {
            lblContador.Text = "0";
            cbxIntervalos.Items.Add(new Intervalo(0.5, "Cada medio segundo"));
            cbxIntervalos.Items.Add(new Intervalo(1, "Cada un segundo"));
            cbxIntervalos.Items.Add(new Intervalo(5, "Cada cinco segundos"));
            cbxIntervalos.Items.Add(new Intervalo(10, "Cada diez segundos"));
        }

        private void cbxIntervalos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var segundosIntervalo = (cbxIntervalos.Items[cbxIntervalos.SelectedIndex] as Intervalo).Segundos;
            timer1.Interval = (int)(segundosIntervalo * 1000);

            //if ((cbxIntervalos.Items[cbxIntervalos.SelectedIndex] as Intervalo).Descripcion == "Cada medio segundo")
            //{                
            //    timer1.Interval = 500;
            //} 
            //else if (cbxIntervalos.SelectedIndex == 1)
            //{
            //    timer1.Interval = 1000;
            //}
            //else if (cbxIntervalos.SelectedIndex == 2)
            //{
            //    timer1.Interval = 5000;
            //}
            //else if (cbxIntervalos.SelectedIndex == 3)
            //{
            //    timer1.Interval = 10000;
            //}
        }
    }

    class Intervalo
    {
        public double Segundos { get; set; }
        public string Descripcion { get; set; }
        public Intervalo(double segundos, string descripcion)
        {
            Segundos = segundos;
            Descripcion = descripcion;
        }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}

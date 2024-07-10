namespace windowsForms
{
    partial class Timer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblContador = new System.Windows.Forms.Label();
            this.btnComenzar = new System.Windows.Forms.Button();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbxIntervalos = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblContador
            // 
            this.lblContador.AutoSize = true;
            this.lblContador.Location = new System.Drawing.Point(90, 67);
            this.lblContador.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(35, 13);
            this.lblContador.TabIndex = 0;
            this.lblContador.Text = "label1";
            // 
            // btnComenzar
            // 
            this.btnComenzar.Location = new System.Drawing.Point(223, 50);
            this.btnComenzar.Margin = new System.Windows.Forms.Padding(2);
            this.btnComenzar.Name = "btnComenzar";
            this.btnComenzar.Size = new System.Drawing.Size(63, 19);
            this.btnComenzar.TabIndex = 1;
            this.btnComenzar.Text = "Comenzar";
            this.btnComenzar.UseVisualStyleBackColor = true;
            this.btnComenzar.Click += new System.EventHandler(this.btnComenzar_Click);
            // 
            // btnTerminar
            // 
            this.btnTerminar.Location = new System.Drawing.Point(223, 86);
            this.btnTerminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(63, 20);
            this.btnTerminar.TabIndex = 2;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.UseVisualStyleBackColor = true;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // cbxIntervalos
            // 
            this.cbxIntervalos.FormattingEnabled = true;
            this.cbxIntervalos.Location = new System.Drawing.Point(106, 171);
            this.cbxIntervalos.Name = "cbxIntervalos";
            this.cbxIntervalos.Size = new System.Drawing.Size(198, 21);
            this.cbxIntervalos.TabIndex = 3;
            this.cbxIntervalos.Text = "Intervalos";
            this.cbxIntervalos.SelectedIndexChanged += new System.EventHandler(this.cbxIntervalos_SelectedIndexChanged);
            // 
            // Timer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.cbxIntervalos);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.btnComenzar);
            this.Controls.Add(this.lblContador);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Timer";
            this.Text = "Timer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Timer_FormClosing);
            this.Load += new System.EventHandler(this.Timer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Button btnComenzar;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cbxIntervalos;
    }
}
namespace windowsForms
{
    partial class Ejercicio
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
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.grpSeguro = new System.Windows.Forms.GroupBox();
            this.rbCompleto = new System.Windows.Forms.RadioButton();
            this.rbTerceros = new System.Windows.Forms.RadioButton();
            this.rbBasico = new System.Windows.Forms.RadioButton();
            this.lblSeguro = new System.Windows.Forms.Label();
            this.grpAccesorios = new System.Windows.Forms.GroupBox();
            this.ChkAudio = new System.Windows.Forms.CheckBox();
            this.chkAire = new System.Windows.Forms.CheckBox();
            this.lblAccesorio = new System.Windows.Forms.Label();
            this.lblCosto = new System.Windows.Forms.Label();
            this.btnCotizar = new System.Windows.Forms.Button();
            this.lblCostoCotizado = new System.Windows.Forms.Label();
            this.grpSeguro.SuspendLayout();
            this.grpAccesorios.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(67, 34);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 16);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(173, 31);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(132, 22);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // grpSeguro
            // 
            this.grpSeguro.Controls.Add(this.rbCompleto);
            this.grpSeguro.Controls.Add(this.rbTerceros);
            this.grpSeguro.Controls.Add(this.rbBasico);
            this.grpSeguro.Controls.Add(this.lblSeguro);
            this.grpSeguro.Location = new System.Drawing.Point(71, 82);
            this.grpSeguro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpSeguro.Name = "grpSeguro";
            this.grpSeguro.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpSeguro.Size = new System.Drawing.Size(236, 149);
            this.grpSeguro.TabIndex = 2;
            this.grpSeguro.TabStop = false;
            this.grpSeguro.Text = "Seguros";
            // 
            // rbCompleto
            // 
            this.rbCompleto.AutoSize = true;
            this.rbCompleto.Location = new System.Drawing.Point(103, 102);
            this.rbCompleto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbCompleto.Name = "rbCompleto";
            this.rbCompleto.Size = new System.Drawing.Size(83, 20);
            this.rbCompleto.TabIndex = 3;
            this.rbCompleto.TabStop = true;
            this.rbCompleto.Text = "Completo";
            this.rbCompleto.UseVisualStyleBackColor = true;
            // 
            // rbTerceros
            // 
            this.rbTerceros.AutoSize = true;
            this.rbTerceros.Location = new System.Drawing.Point(103, 75);
            this.rbTerceros.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbTerceros.Name = "rbTerceros";
            this.rbTerceros.Size = new System.Drawing.Size(80, 20);
            this.rbTerceros.TabIndex = 2;
            this.rbTerceros.TabStop = true;
            this.rbTerceros.Text = "Terceros";
            this.rbTerceros.UseVisualStyleBackColor = true;
            // 
            // rbBasico
            // 
            this.rbBasico.AutoSize = true;
            this.rbBasico.Checked = true;
            this.rbBasico.Location = new System.Drawing.Point(103, 47);
            this.rbBasico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbBasico.Name = "rbBasico";
            this.rbBasico.Size = new System.Drawing.Size(67, 20);
            this.rbBasico.TabIndex = 1;
            this.rbBasico.TabStop = true;
            this.rbBasico.Text = "Basico";
            this.rbBasico.UseVisualStyleBackColor = true;
            // 
            // lblSeguro
            // 
            this.lblSeguro.AutoSize = true;
            this.lblSeguro.Location = new System.Drawing.Point(31, 32);
            this.lblSeguro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeguro.Name = "lblSeguro";
            this.lblSeguro.Size = new System.Drawing.Size(68, 16);
            this.lblSeguro.TabIndex = 0;
            this.lblSeguro.Text = "Opciones:";
            // 
            // grpAccesorios
            // 
            this.grpAccesorios.Controls.Add(this.ChkAudio);
            this.grpAccesorios.Controls.Add(this.chkAire);
            this.grpAccesorios.Controls.Add(this.lblAccesorio);
            this.grpAccesorios.Location = new System.Drawing.Point(497, 82);
            this.grpAccesorios.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAccesorios.Name = "grpAccesorios";
            this.grpAccesorios.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpAccesorios.Size = new System.Drawing.Size(292, 149);
            this.grpAccesorios.TabIndex = 3;
            this.grpAccesorios.TabStop = false;
            this.grpAccesorios.Text = "Accesorios";
            // 
            // ChkAudio
            // 
            this.ChkAudio.AutoSize = true;
            this.ChkAudio.Location = new System.Drawing.Point(111, 75);
            this.ChkAudio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChkAudio.Name = "ChkAudio";
            this.ChkAudio.Size = new System.Drawing.Size(131, 20);
            this.ChkAudio.TabIndex = 2;
            this.ChkAudio.Text = "Sistema de audio";
            this.ChkAudio.UseVisualStyleBackColor = true;
            // 
            // chkAire
            // 
            this.chkAire.AutoSize = true;
            this.chkAire.Location = new System.Drawing.Point(111, 47);
            this.chkAire.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkAire.Name = "chkAire";
            this.chkAire.Size = new System.Drawing.Size(143, 20);
            this.chkAire.TabIndex = 1;
            this.chkAire.Text = "Aire acondicionado";
            this.chkAire.UseVisualStyleBackColor = true;
            // 
            // lblAccesorio
            // 
            this.lblAccesorio.AutoSize = true;
            this.lblAccesorio.Location = new System.Drawing.Point(29, 31);
            this.lblAccesorio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccesorio.Name = "lblAccesorio";
            this.lblAccesorio.Size = new System.Drawing.Size(68, 16);
            this.lblAccesorio.TabIndex = 0;
            this.lblAccesorio.Text = "Opciones:";
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(67, 267);
            this.lblCosto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(45, 16);
            this.lblCosto.TabIndex = 4;
            this.lblCosto.Text = "Costo:";
            // 
            // btnCotizar
            // 
            this.btnCotizar.Location = new System.Drawing.Point(452, 252);
            this.btnCotizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCotizar.Name = "btnCotizar";
            this.btnCotizar.Size = new System.Drawing.Size(67, 46);
            this.btnCotizar.TabIndex = 5;
            this.btnCotizar.Text = "Cotizar";
            this.btnCotizar.UseVisualStyleBackColor = true;
            this.btnCotizar.Click += new System.EventHandler(this.btnCotizar_Click);
            // 
            // lblCostoCotizado
            // 
            this.lblCostoCotizado.AutoSize = true;
            this.lblCostoCotizado.Location = new System.Drawing.Point(223, 266);
            this.lblCostoCotizado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCostoCotizado.Name = "lblCostoCotizado";
            this.lblCostoCotizado.Size = new System.Drawing.Size(44, 16);
            this.lblCostoCotizado.TabIndex = 6;
            this.lblCostoCotizado.Text = "label5";
            // 
            // Ejercicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lblCostoCotizado);
            this.Controls.Add(this.btnCotizar);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.grpAccesorios);
            this.Controls.Add(this.grpSeguro);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Ejercicio";
            this.Text = "Ejercicio";
            this.Load += new System.EventHandler(this.Ejercicio_Load);
            this.grpSeguro.ResumeLayout(false);
            this.grpSeguro.PerformLayout();
            this.grpAccesorios.ResumeLayout(false);
            this.grpAccesorios.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.GroupBox grpSeguro;
        private System.Windows.Forms.RadioButton rbCompleto;
        private System.Windows.Forms.RadioButton rbTerceros;
        private System.Windows.Forms.RadioButton rbBasico;
        private System.Windows.Forms.Label lblSeguro;
        private System.Windows.Forms.GroupBox grpAccesorios;
        private System.Windows.Forms.CheckBox ChkAudio;
        private System.Windows.Forms.CheckBox chkAire;
        private System.Windows.Forms.Label lblAccesorio;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Button btnCotizar;
        private System.Windows.Forms.Label lblCostoCotizado;
    }
}
namespace windowsForms
{
    partial class Checked
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
            this.chkMonitor = new System.Windows.Forms.CheckBox();
            this.chkTeclado = new System.Windows.Forms.CheckBox();
            this.chkMouse = new System.Windows.Forms.CheckBox();
            this.lblSeleccion = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.groupOperaciones = new System.Windows.Forms.GroupBox();
            this.rbMulti = new System.Windows.Forms.RadioButton();
            this.rbResta = new System.Windows.Forms.RadioButton();
            this.rbSuma = new System.Windows.Forms.RadioButton();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupOperaciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkMonitor
            // 
            this.chkMonitor.AutoSize = true;
            this.chkMonitor.Checked = true;
            this.chkMonitor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMonitor.Location = new System.Drawing.Point(213, 127);
            this.chkMonitor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkMonitor.Name = "chkMonitor";
            this.chkMonitor.Size = new System.Drawing.Size(70, 20);
            this.chkMonitor.TabIndex = 0;
            this.chkMonitor.Text = "Monitor";
            this.chkMonitor.UseVisualStyleBackColor = true;
            this.chkMonitor.CheckedChanged += new System.EventHandler(this.chkMonitor_CheckedChanged);
            // 
            // chkTeclado
            // 
            this.chkTeclado.AutoSize = true;
            this.chkTeclado.Location = new System.Drawing.Point(213, 156);
            this.chkTeclado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkTeclado.Name = "chkTeclado";
            this.chkTeclado.Size = new System.Drawing.Size(77, 20);
            this.chkTeclado.TabIndex = 1;
            this.chkTeclado.Text = "Teclado";
            this.chkTeclado.UseVisualStyleBackColor = true;
            this.chkTeclado.CheckedChanged += new System.EventHandler(this.chkTeclado_CheckedChanged);
            // 
            // chkMouse
            // 
            this.chkMouse.AutoSize = true;
            this.chkMouse.Location = new System.Drawing.Point(213, 186);
            this.chkMouse.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkMouse.Name = "chkMouse";
            this.chkMouse.Size = new System.Drawing.Size(67, 20);
            this.chkMouse.TabIndex = 2;
            this.chkMouse.Text = "Mouse";
            this.chkMouse.UseVisualStyleBackColor = true;
            // 
            // lblSeleccion
            // 
            this.lblSeleccion.AutoSize = true;
            this.lblSeleccion.Location = new System.Drawing.Point(252, 272);
            this.lblSeleccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeleccion.Name = "lblSeleccion";
            this.lblSeleccion.Size = new System.Drawing.Size(44, 16);
            this.lblSeleccion.TabIndex = 3;
            this.lblSeleccion.Text = "label1";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(429, 186);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(100, 28);
            this.btnCalcular.TabIndex = 4;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // groupOperaciones
            // 
            this.groupOperaciones.Controls.Add(this.rbMulti);
            this.groupOperaciones.Controls.Add(this.rbResta);
            this.groupOperaciones.Controls.Add(this.rbSuma);
            this.groupOperaciones.Location = new System.Drawing.Point(587, 217);
            this.groupOperaciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupOperaciones.Name = "groupOperaciones";
            this.groupOperaciones.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupOperaciones.Size = new System.Drawing.Size(340, 204);
            this.groupOperaciones.TabIndex = 5;
            this.groupOperaciones.TabStop = false;
            this.groupOperaciones.Text = "Operaciones";
            // 
            // rbMulti
            // 
            this.rbMulti.AutoSize = true;
            this.rbMulti.Location = new System.Drawing.Point(35, 102);
            this.rbMulti.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbMulti.Name = "rbMulti";
            this.rbMulti.Size = new System.Drawing.Size(106, 20);
            this.rbMulti.TabIndex = 2;
            this.rbMulti.Text = "Multiplicacion";
            this.rbMulti.UseVisualStyleBackColor = true;
            // 
            // rbResta
            // 
            this.rbResta.AutoSize = true;
            this.rbResta.Location = new System.Drawing.Point(35, 73);
            this.rbResta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbResta.Name = "rbResta";
            this.rbResta.Size = new System.Drawing.Size(61, 20);
            this.rbResta.TabIndex = 1;
            this.rbResta.Text = "Resta";
            this.rbResta.UseVisualStyleBackColor = true;
            // 
            // rbSuma
            // 
            this.rbSuma.AutoSize = true;
            this.rbSuma.Checked = true;
            this.rbSuma.Location = new System.Drawing.Point(35, 44);
            this.rbSuma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbSuma.Name = "rbSuma";
            this.rbSuma.Size = new System.Drawing.Size(60, 20);
            this.rbSuma.TabIndex = 0;
            this.rbSuma.TabStop = true;
            this.rbSuma.Text = "Suma";
            this.rbSuma.UseVisualStyleBackColor = true;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(623, 79);
            this.txtA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(132, 22);
            this.txtA.TabIndex = 6;
            this.txtA.Text = "0";
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(623, 127);
            this.txtB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(132, 22);
            this.txtB.TabIndex = 7;
            this.txtB.Text = "0";
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(429, 344);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Checked
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.groupOperaciones);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblSeleccion);
            this.Controls.Add(this.chkMouse);
            this.Controls.Add(this.chkTeclado);
            this.Controls.Add(this.chkMonitor);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Checked";
            this.Text = "Checked";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Checked_FormClosing);
            this.Load += new System.EventHandler(this.Checked_Load);
            this.groupOperaciones.ResumeLayout(false);
            this.groupOperaciones.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMonitor;
        private System.Windows.Forms.CheckBox chkTeclado;
        private System.Windows.Forms.CheckBox chkMouse;
        private System.Windows.Forms.Label lblSeleccion;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.GroupBox groupOperaciones;
        private System.Windows.Forms.RadioButton rbMulti;
        private System.Windows.Forms.RadioButton rbResta;
        private System.Windows.Forms.RadioButton rbSuma;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Button btnSalir;
    }
}
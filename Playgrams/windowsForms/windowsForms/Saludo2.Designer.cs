namespace windowsForms
{
    partial class Saludo2
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
            this.btSaludar = new System.Windows.Forms.Button();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblSaludar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btSaludar
            // 
            this.btSaludar.Location = new System.Drawing.Point(414, 73);
            this.btSaludar.Name = "btSaludar";
            this.btSaludar.Size = new System.Drawing.Size(75, 23);
            this.btSaludar.TabIndex = 0;
            this.btSaludar.Text = "Saludar";
            this.btSaludar.UseVisualStyleBackColor = true;
            this.btSaludar.Click += new System.EventHandler(this.btSaludar_Click);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(117, 82);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(185, 75);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(193, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // lblSaludar
            // 
            this.lblSaludar.AutoSize = true;
            this.lblSaludar.Location = new System.Drawing.Point(120, 134);
            this.lblSaludar.Name = "lblSaludar";
            this.lblSaludar.Size = new System.Drawing.Size(35, 13);
            this.lblSaludar.TabIndex = 3;
            this.lblSaludar.Text = "label1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSaludar);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btSaludar);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Saludo2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSaludar;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblSaludar;
    }
}
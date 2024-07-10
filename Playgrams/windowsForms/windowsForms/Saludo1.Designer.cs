namespace windowsForms
{
    partial class Saludo1
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
            this.btnSaludo = new System.Windows.Forms.Button();
            this.lblSaludo = new System.Windows.Forms.Label();
            this.btnDespedir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaludo
            // 
            this.btnSaludo.Location = new System.Drawing.Point(488, 63);
            this.btnSaludo.Name = "btnSaludo";
            this.btnSaludo.Size = new System.Drawing.Size(75, 23);
            this.btnSaludo.TabIndex = 0;
            this.btnSaludo.Text = "Saludar";
            this.btnSaludo.UseVisualStyleBackColor = true;
            this.btnSaludo.Click += new System.EventHandler(this.btnSaludo_Click);
            // 
            // lblSaludo
            // 
            this.lblSaludo.AutoSize = true;
            this.lblSaludo.Location = new System.Drawing.Point(162, 73);
            this.lblSaludo.Name = "lblSaludo";
            this.lblSaludo.Size = new System.Drawing.Size(35, 13);
            this.lblSaludo.TabIndex = 1;
            this.lblSaludo.Text = "label1";
            // 
            // btnDespedir
            // 
            this.btnDespedir.Location = new System.Drawing.Point(488, 127);
            this.btnDespedir.Name = "btnDespedir";
            this.btnDespedir.Size = new System.Drawing.Size(75, 23);
            this.btnDespedir.TabIndex = 2;
            this.btnDespedir.Text = "Despedir";
            this.btnDespedir.UseVisualStyleBackColor = true;
            this.btnDespedir.Click += new System.EventHandler(this.btnDespedir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDespedir);
            this.Controls.Add(this.lblSaludo);
            this.Controls.Add(this.btnSaludo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Saludo1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaludo;
        private System.Windows.Forms.Label lblSaludo;
        private System.Windows.Forms.Button btnDespedir;
    }
}


namespace windowsForms
{
    partial class Calculadora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculadora));
            this.lblA = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.btnSuma = new System.Windows.Forms.Button();
            this.btnResta = new System.Windows.Forms.Button();
            this.btnDiv = new System.Windows.Forms.Button();
            this.btnMult = new System.Windows.Forms.Button();
            this.btnChecked = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(171, 81);
            this.lblA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(16, 16);
            this.lblA.TabIndex = 0;
            this.lblA.Text = "A";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(171, 134);
            this.lblB.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(16, 16);
            this.lblB.TabIndex = 1;
            this.lblB.Text = "B";
            this.lblB.Click += new System.EventHandler(this.lblB_Click);
            this.lblB.DoubleClick += new System.EventHandler(this.lblB_Enter);
            this.lblB.Enter += new System.EventHandler(this.lblB_Enter);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(259, 182);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(44, 16);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "label3";
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(219, 73);
            this.txtA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(132, 22);
            this.txtA.TabIndex = 3;
            this.txtA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(219, 126);
            this.txtB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(132, 22);
            this.txtB.TabIndex = 4;
            this.txtB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSuma
            // 
            this.btnSuma.Location = new System.Drawing.Point(415, 69);
            this.btnSuma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSuma.Name = "btnSuma";
            this.btnSuma.Size = new System.Drawing.Size(100, 28);
            this.btnSuma.TabIndex = 5;
            this.btnSuma.Text = "+";
            this.btnSuma.UseVisualStyleBackColor = true;
            this.btnSuma.Click += new System.EventHandler(this.btnSuma_Click);
            // 
            // btnResta
            // 
            this.btnResta.Location = new System.Drawing.Point(537, 69);
            this.btnResta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnResta.Name = "btnResta";
            this.btnResta.Size = new System.Drawing.Size(100, 28);
            this.btnResta.TabIndex = 6;
            this.btnResta.Text = "-";
            this.btnResta.UseVisualStyleBackColor = true;
            this.btnResta.Click += new System.EventHandler(this.btnResta_Click);
            // 
            // btnDiv
            // 
            this.btnDiv.Location = new System.Drawing.Point(537, 121);
            this.btnDiv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.Size = new System.Drawing.Size(100, 28);
            this.btnDiv.TabIndex = 8;
            this.btnDiv.Text = "/";
            this.btnDiv.UseVisualStyleBackColor = true;
            this.btnDiv.Click += new System.EventHandler(this.btnDiv_Click);
            // 
            // btnMult
            // 
            this.btnMult.Location = new System.Drawing.Point(415, 122);
            this.btnMult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMult.Name = "btnMult";
            this.btnMult.Size = new System.Drawing.Size(100, 28);
            this.btnMult.TabIndex = 7;
            this.btnMult.Text = "*";
            this.btnMult.UseVisualStyleBackColor = true;
            this.btnMult.Click += new System.EventHandler(this.btnMult_Click);
            // 
            // btnChecked
            // 
            this.btnChecked.Location = new System.Drawing.Point(472, 209);
            this.btnChecked.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChecked.Name = "btnChecked";
            this.btnChecked.Size = new System.Drawing.Size(100, 28);
            this.btnChecked.TabIndex = 9;
            this.btnChecked.Text = "Checked";
            this.btnChecked.UseVisualStyleBackColor = true;
            this.btnChecked.Click += new System.EventHandler(this.btnChecked_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(732, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.btnSuma_Click);
            // 
            // Calculadora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 289);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnChecked);
            this.Controls.Add(this.btnDiv);
            this.Controls.Add(this.btnMult);
            this.Controls.Add(this.btnResta);
            this.Controls.Add(this.btnSuma);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblA);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Calculadora";
            this.Text = "Calculadora";
            this.Load += new System.EventHandler(this.Calculadora_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Button btnSuma;
        private System.Windows.Forms.Button btnResta;
        private System.Windows.Forms.Button btnDiv;
        private System.Windows.Forms.Button btnMult;
        private System.Windows.Forms.Button btnChecked;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}
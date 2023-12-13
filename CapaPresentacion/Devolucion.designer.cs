namespace CapaPresentacion
{
    partial class Devolucion
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbNumeroCarnet = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLibrosDevueltos = new System.Windows.Forms.ComboBox();
            this.btnIntroducirNumero = new System.Windows.Forms.Button();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "DEVOLUCION";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tbNumeroCarnet
            // 
            this.tbNumeroCarnet.Location = new System.Drawing.Point(222, 140);
            this.tbNumeroCarnet.Name = "tbNumeroCarnet";
            this.tbNumeroCarnet.Size = new System.Drawing.Size(100, 22);
            this.tbNumeroCarnet.TabIndex = 1;
            this.tbNumeroCarnet.Text = "N Carnet";
            this.tbNumeroCarnet.TextChanged += new System.EventHandler(this.tbNumeroCarnet_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero Carnet : ";
            // 
            // cbLibrosDevueltos
            // 
            this.cbLibrosDevueltos.FormattingEnabled = true;
            this.cbLibrosDevueltos.Location = new System.Drawing.Point(465, 140);
            this.cbLibrosDevueltos.Name = "cbLibrosDevueltos";
            this.cbLibrosDevueltos.Size = new System.Drawing.Size(121, 24);
            this.cbLibrosDevueltos.TabIndex = 3;
            this.cbLibrosDevueltos.Text = "cbLibrosDevolucion";
            // 
            // btnIntroducirNumero
            // 
            this.btnIntroducirNumero.Location = new System.Drawing.Point(185, 218);
            this.btnIntroducirNumero.Name = "btnIntroducirNumero";
            this.btnIntroducirNumero.Size = new System.Drawing.Size(162, 34);
            this.btnIntroducirNumero.TabIndex = 4;
            this.btnIntroducirNumero.Text = "Introduce Numero Carnet";
            this.btnIntroducirNumero.UseVisualStyleBackColor = true;
            this.btnIntroducirNumero.Click += new System.EventHandler(this.btnIntroducirNumero_Click);
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(465, 218);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(130, 34);
            this.btnDevolver.TabIndex = 5;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // Devoluvion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 441);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.btnIntroducirNumero);
            this.Controls.Add(this.cbLibrosDevueltos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNumeroCarnet);
            this.Controls.Add(this.label1);
            this.Name = "Devoluvion";
            this.Text = "Devoluvion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNumeroCarnet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLibrosDevueltos;
        private System.Windows.Forms.Button btnIntroducirNumero;
        private System.Windows.Forms.Button btnDevolver;
    }
}
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
            this.cbLibrosDevueltos = new System.Windows.Forms.ListBox();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnIntroducirNumero = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNumeroCarnet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbLibrosDevueltos
            // 
            this.cbLibrosDevueltos.FormattingEnabled = true;
            this.cbLibrosDevueltos.ItemHeight = 16;
            this.cbLibrosDevueltos.Location = new System.Drawing.Point(331, 182);
            this.cbLibrosDevueltos.Name = "cbLibrosDevueltos";
            this.cbLibrosDevueltos.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.cbLibrosDevueltos.Size = new System.Drawing.Size(209, 148);
            this.cbLibrosDevueltos.TabIndex = 12;
            this.cbLibrosDevueltos.Click += new System.EventHandler(this.cbLibrosDevueltos_SelectedIndexChanged);
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(331, 354);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(209, 34);
            this.btnDevolver.TabIndex = 11;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // btnIntroducirNumero
            // 
            this.btnIntroducirNumero.Location = new System.Drawing.Point(505, 119);
            this.btnIntroducirNumero.Name = "btnIntroducirNumero";
            this.btnIntroducirNumero.Size = new System.Drawing.Size(162, 34);
            this.btnIntroducirNumero.TabIndex = 10;
            this.btnIntroducirNumero.Text = "Mostrar Libros Prestados";
            this.btnIntroducirNumero.UseVisualStyleBackColor = true;
            this.btnIntroducirNumero.Click += new System.EventHandler(this.btnIntroducirNumero_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Numero Carnet : ";
            // 
            // tbNumeroCarnet
            // 
            this.tbNumeroCarnet.Location = new System.Drawing.Point(250, 122);
            this.tbNumeroCarnet.Name = "tbNumeroCarnet";
            this.tbNumeroCarnet.Size = new System.Drawing.Size(100, 22);
            this.tbNumeroCarnet.TabIndex = 8;
            this.tbNumeroCarnet.Text = "N Carnet";
            this.tbNumeroCarnet.Click += new System.EventHandler(this.tbNumeroCarnet_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "DEVOLUCION";
            // 
            // Devolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 441);
            this.Controls.Add(this.cbLibrosDevueltos);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.btnIntroducirNumero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNumeroCarnet);
            this.Controls.Add(this.label1);
            this.Name = "Devolucion";
            this.Text = "Devoluvion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox cbLibrosDevueltos;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Button btnIntroducirNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNumeroCarnet;
        private System.Windows.Forms.Label label1;
    }
}
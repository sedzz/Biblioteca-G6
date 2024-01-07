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
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbLibrosDevueltos
            // 
            this.cbLibrosDevueltos.FormattingEnabled = true;
            this.cbLibrosDevueltos.Location = new System.Drawing.Point(248, 148);
            this.cbLibrosDevueltos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbLibrosDevueltos.Name = "cbLibrosDevueltos";
            this.cbLibrosDevueltos.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.cbLibrosDevueltos.Size = new System.Drawing.Size(158, 121);
            this.cbLibrosDevueltos.TabIndex = 12;
            this.cbLibrosDevueltos.Click += new System.EventHandler(this.cbLibrosDevueltos_SelectedIndexChanged);
            // 
            // btnDevolver
            // 
            this.btnDevolver.Location = new System.Drawing.Point(248, 288);
            this.btnDevolver.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(157, 28);
            this.btnDevolver.TabIndex = 11;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // btnIntroducirNumero
            // 
            this.btnIntroducirNumero.Location = new System.Drawing.Point(379, 97);
            this.btnIntroducirNumero.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIntroducirNumero.Name = "btnIntroducirNumero";
            this.btnIntroducirNumero.Size = new System.Drawing.Size(122, 28);
            this.btnIntroducirNumero.TabIndex = 10;
            this.btnIntroducirNumero.Text = "Mostrar Libros Prestados";
            this.btnIntroducirNumero.UseVisualStyleBackColor = true;
            this.btnIntroducirNumero.Click += new System.EventHandler(this.btnIntroducirNumero_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 104);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Numero Carnet : ";
            // 
            // tbNumeroCarnet
            // 
            this.tbNumeroCarnet.Location = new System.Drawing.Point(188, 99);
            this.tbNumeroCarnet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbNumeroCarnet.Name = "tbNumeroCarnet";
            this.tbNumeroCarnet.Size = new System.Drawing.Size(76, 20);
            this.tbNumeroCarnet.TabIndex = 8;
            this.tbNumeroCarnet.Text = "N Carnet";
            this.tbNumeroCarnet.Click += new System.EventHandler(this.tbNumeroCarnet_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "DEVOLUCION";
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(54, 293);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 13;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // Devolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 358);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.cbLibrosDevueltos);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.btnIntroducirNumero);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbNumeroCarnet);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Button btnVolver;
    }
}
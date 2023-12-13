namespace CapaPresentacion
{
    partial class FrmAutores
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
            this.txtNombreAutor = new System.Windows.Forms.TextBox();
            this.btnAñadirAutor = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(276, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "AÑADIR AUTOR";
            // 
            // txtNombreAutor
            // 
            this.txtNombreAutor.Location = new System.Drawing.Point(301, 142);
            this.txtNombreAutor.Name = "txtNombreAutor";
            this.txtNombreAutor.Size = new System.Drawing.Size(168, 20);
            this.txtNombreAutor.TabIndex = 1;
            // 
            // btnAñadirAutor
            // 
            this.btnAñadirAutor.Location = new System.Drawing.Point(319, 213);
            this.btnAñadirAutor.Name = "btnAñadirAutor";
            this.btnAñadirAutor.Size = new System.Drawing.Size(136, 44);
            this.btnAñadirAutor.TabIndex = 2;
            this.btnAñadirAutor.Text = "Añadir Autor";
            this.btnAñadirAutor.UseVisualStyleBackColor = true;
            this.btnAñadirAutor.Click += new System.EventHandler(this.btnAñadirAutor_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(28, 377);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(121, 43);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // FrmAutores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAñadirAutor);
            this.Controls.Add(this.txtNombreAutor);
            this.Controls.Add(this.label1);
            this.Name = "FrmAutores";
            this.Text = "FrmAutores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreAutor;
        private System.Windows.Forms.Button btnAñadirAutor;
        private System.Windows.Forms.Button btnVolver;
    }
}
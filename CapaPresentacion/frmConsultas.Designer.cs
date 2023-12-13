namespace CapaPresentacion
{
    partial class frmConsultas
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCategoriaId = new System.Windows.Forms.Button();
            this.btnCategoriaNombre = new System.Windows.Forms.Button();
            this.btnTodasCategorias = new System.Windows.Forms.Button();
            this.btnAutorId = new System.Windows.Forms.Button();
            this.btnAutorTrozoNombre = new System.Windows.Forms.Button();
            this.btnPorId = new System.Windows.Forms.Button();
            this.btnLectorTrozoNombre = new System.Windows.Forms.Button();
            this.btnPorIsbn = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLibroTrozoNombre = new System.Windows.Forms.Button();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(82, 40);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(99, 16);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "RESULTADOS";
            // 
            // btnCategoriaId
            // 
            this.btnCategoriaId.Location = new System.Drawing.Point(448, 404);
            this.btnCategoriaId.Name = "btnCategoriaId";
            this.btnCategoriaId.Size = new System.Drawing.Size(104, 45);
            this.btnCategoriaId.TabIndex = 2;
            this.btnCategoriaId.Text = "Categoría Por Id";
            this.btnCategoriaId.UseVisualStyleBackColor = true;
            // 
            // btnCategoriaNombre
            // 
            this.btnCategoriaNombre.Location = new System.Drawing.Point(448, 343);
            this.btnCategoriaNombre.Name = "btnCategoriaNombre";
            this.btnCategoriaNombre.Size = new System.Drawing.Size(104, 46);
            this.btnCategoriaNombre.TabIndex = 3;
            this.btnCategoriaNombre.Text = "Categoría Por Nombre";
            this.btnCategoriaNombre.UseVisualStyleBackColor = true;
            // 
            // btnTodasCategorias
            // 
            this.btnTodasCategorias.Location = new System.Drawing.Point(572, 376);
            this.btnTodasCategorias.Name = "btnTodasCategorias";
            this.btnTodasCategorias.Size = new System.Drawing.Size(104, 48);
            this.btnTodasCategorias.TabIndex = 4;
            this.btnTodasCategorias.Text = "Todas Las Categorías";
            this.btnTodasCategorias.UseVisualStyleBackColor = true;
            this.btnTodasCategorias.Click += new System.EventHandler(this.btnTodasCategorias_Click);
            // 
            // btnAutorId
            // 
            this.btnAutorId.Location = new System.Drawing.Point(328, 408);
            this.btnAutorId.Name = "btnAutorId";
            this.btnAutorId.Size = new System.Drawing.Size(104, 36);
            this.btnAutorId.TabIndex = 5;
            this.btnAutorId.Text = "Autor Por Id";
            this.btnAutorId.UseVisualStyleBackColor = true;
            // 
            // btnAutorTrozoNombre
            // 
            this.btnAutorTrozoNombre.Location = new System.Drawing.Point(328, 343);
            this.btnAutorTrozoNombre.Name = "btnAutorTrozoNombre";
            this.btnAutorTrozoNombre.Size = new System.Drawing.Size(104, 59);
            this.btnAutorTrozoNombre.TabIndex = 6;
            this.btnAutorTrozoNombre.Text = "Autor Por Trozo De Nombre";
            this.btnAutorTrozoNombre.UseVisualStyleBackColor = true;
            // 
            // btnPorId
            // 
            this.btnPorId.Location = new System.Drawing.Point(208, 408);
            this.btnPorId.Name = "btnPorId";
            this.btnPorId.Size = new System.Drawing.Size(104, 36);
            this.btnPorId.TabIndex = 7;
            this.btnPorId.Text = "Lector Por Id";
            this.btnPorId.UseVisualStyleBackColor = true;
            // 
            // btnLectorTrozoNombre
            // 
            this.btnLectorTrozoNombre.Location = new System.Drawing.Point(208, 345);
            this.btnLectorTrozoNombre.Name = "btnLectorTrozoNombre";
            this.btnLectorTrozoNombre.Size = new System.Drawing.Size(104, 57);
            this.btnLectorTrozoNombre.TabIndex = 8;
            this.btnLectorTrozoNombre.Text = "Lector Por Trozo De Nombre";
            this.btnLectorTrozoNombre.UseVisualStyleBackColor = true;
            // 
            // btnPorIsbn
            // 
            this.btnPorIsbn.Location = new System.Drawing.Point(85, 408);
            this.btnPorIsbn.Name = "btnPorIsbn";
            this.btnPorIsbn.Size = new System.Drawing.Size(104, 36);
            this.btnPorIsbn.TabIndex = 9;
            this.btnPorIsbn.Text = "Libro Por Isbn";
            this.btnPorIsbn.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(373, 34);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(273, 22);
            this.txtBuscar.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Buscar: ";
            // 
            // btnLibroTrozoNombre
            // 
            this.btnLibroTrozoNombre.Location = new System.Drawing.Point(85, 343);
            this.btnLibroTrozoNombre.Name = "btnLibroTrozoNombre";
            this.btnLibroTrozoNombre.Size = new System.Drawing.Size(104, 59);
            this.btnLibroTrozoNombre.TabIndex = 12;
            this.btnLibroTrozoNombre.Text = "Libro Por Trozo De Nombre";
            this.btnLibroTrozoNombre.UseVisualStyleBackColor = true;
            this.btnLibroTrozoNombre.Click += new System.EventHandler(this.btnLibroTrozoNombre_Click);
            // 
            // dgvResultados
            // 
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(72, 88);
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.RowHeadersWidth = 51;
            this.dgvResultados.RowTemplate.Height = 24;
            this.dgvResultados.Size = new System.Drawing.Size(603, 240);
            this.dgvResultados.TabIndex = 13;
            this.dgvResultados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResultados_CellContentClick);
            // 
            // frmConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 477);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.btnLibroTrozoNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnPorIsbn);
            this.Controls.Add(this.btnLectorTrozoNombre);
            this.Controls.Add(this.btnPorId);
            this.Controls.Add(this.btnAutorTrozoNombre);
            this.Controls.Add(this.btnAutorId);
            this.Controls.Add(this.btnTodasCategorias);
            this.Controls.Add(this.btnCategoriaNombre);
            this.Controls.Add(this.btnCategoriaId);
            this.Controls.Add(this.lblTitulo);
            this.Name = "frmConsultas";
            this.Text = "frmConsultas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCategoriaId;
        private System.Windows.Forms.Button btnCategoriaNombre;
        private System.Windows.Forms.Button btnTodasCategorias;
        private System.Windows.Forms.Button btnAutorId;
        private System.Windows.Forms.Button btnAutorTrozoNombre;
        private System.Windows.Forms.Button btnPorId;
        private System.Windows.Forms.Button btnLectorTrozoNombre;
        private System.Windows.Forms.Button btnPorIsbn;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLibroTrozoNombre;
        private System.Windows.Forms.DataGridView dgvResultados;
    }
}
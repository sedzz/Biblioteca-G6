namespace CapaPresentacion
{
    partial class FrmLectores
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
            this.dgvSocios = new System.Windows.Forms.DataGridView();
            this.btnMostrarTodos = new System.Windows.Forms.Button();
            this.btnBuscarNombre = new System.Windows.Forms.Button();
            this.btnBuscarId = new System.Windows.Forms.Button();
            this.txtTrozoNombre = new System.Windows.Forms.TextBox();
            this.txtNumCarnet = new System.Windows.Forms.TextBox();
            this.btnNuevoSocio = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(193, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(682, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "SOCIOS DE LA BIBLIOTECA";
            // 
            // dgvSocios
            // 
            this.dgvSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSocios.Location = new System.Drawing.Point(50, 80);
            this.dgvSocios.Name = "dgvSocios";
            this.dgvSocios.RowHeadersWidth = 51;
            this.dgvSocios.RowTemplate.Height = 24;
            this.dgvSocios.Size = new System.Drawing.Size(978, 289);
            this.dgvSocios.TabIndex = 1;
            // 
            // btnMostrarTodos
            // 
            this.btnMostrarTodos.Location = new System.Drawing.Point(95, 401);
            this.btnMostrarTodos.Name = "btnMostrarTodos";
            this.btnMostrarTodos.Size = new System.Drawing.Size(133, 63);
            this.btnMostrarTodos.TabIndex = 2;
            this.btnMostrarTodos.Text = "Mostrar tod@s";
            this.btnMostrarTodos.UseVisualStyleBackColor = true;
            this.btnMostrarTodos.Click += new System.EventHandler(this.btnMostrarTodos_Click);
            // 
            // btnBuscarNombre
            // 
            this.btnBuscarNombre.Location = new System.Drawing.Point(308, 401);
            this.btnBuscarNombre.Name = "btnBuscarNombre";
            this.btnBuscarNombre.Size = new System.Drawing.Size(144, 63);
            this.btnBuscarNombre.TabIndex = 3;
            this.btnBuscarNombre.Text = "Buscar por trozo de nombre";
            this.btnBuscarNombre.UseVisualStyleBackColor = true;
            this.btnBuscarNombre.Click += new System.EventHandler(this.btnBuscarNombre_Click);
            // 
            // btnBuscarId
            // 
            this.btnBuscarId.Location = new System.Drawing.Point(721, 401);
            this.btnBuscarId.Name = "btnBuscarId";
            this.btnBuscarId.Size = new System.Drawing.Size(133, 63);
            this.btnBuscarId.TabIndex = 4;
            this.btnBuscarId.Text = "Buscar por número de carnet";
            this.btnBuscarId.UseVisualStyleBackColor = true;
            this.btnBuscarId.Click += new System.EventHandler(this.btnBuscarId_Click);
            // 
            // txtTrozoNombre
            // 
            this.txtTrozoNombre.Location = new System.Drawing.Point(458, 421);
            this.txtTrozoNombre.Name = "txtTrozoNombre";
            this.txtTrozoNombre.Size = new System.Drawing.Size(180, 22);
            this.txtTrozoNombre.TabIndex = 5;
            // 
            // txtNumCarnet
            // 
            this.txtNumCarnet.Location = new System.Drawing.Point(860, 421);
            this.txtNumCarnet.Name = "txtNumCarnet";
            this.txtNumCarnet.Size = new System.Drawing.Size(168, 22);
            this.txtNumCarnet.TabIndex = 6;
            // 
            // btnNuevoSocio
            // 
            this.btnNuevoSocio.Location = new System.Drawing.Point(227, 514);
            this.btnNuevoSocio.Name = "btnNuevoSocio";
            this.btnNuevoSocio.Size = new System.Drawing.Size(146, 65);
            this.btnNuevoSocio.TabIndex = 7;
            this.btnNuevoSocio.Text = "NUEVO SOCIO";
            this.btnNuevoSocio.UseVisualStyleBackColor = true;
            this.btnNuevoSocio.Click += new System.EventHandler(this.btnNuevoSocio_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(626, 514);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 65);
            this.button1.TabIndex = 8;
            this.button1.Text = "VOLVER";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmLectores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNuevoSocio);
            this.Controls.Add(this.txtNumCarnet);
            this.Controls.Add(this.txtTrozoNombre);
            this.Controls.Add(this.btnBuscarId);
            this.Controls.Add(this.btnBuscarNombre);
            this.Controls.Add(this.btnMostrarTodos);
            this.Controls.Add(this.dgvSocios);
            this.Controls.Add(this.label1);
            this.Name = "FrmLectores";
            this.Text = "FrmLectores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvSocios;
        private System.Windows.Forms.Button btnMostrarTodos;
        private System.Windows.Forms.Button btnBuscarNombre;
        private System.Windows.Forms.Button btnBuscarId;
        private System.Windows.Forms.TextBox txtTrozoNombre;
        private System.Windows.Forms.TextBox txtNumCarnet;
        private System.Windows.Forms.Button btnNuevoSocio;
        private System.Windows.Forms.Button button1;
    }
}
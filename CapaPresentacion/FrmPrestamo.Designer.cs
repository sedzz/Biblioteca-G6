namespace CapaPresentacion
{
    partial class FrmPrestamo
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
            this.btnPedirLibro = new System.Windows.Forms.Button();
            this.txtNumCarnet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPedirLibro
            // 
            this.btnPedirLibro.Location = new System.Drawing.Point(275, 297);
            this.btnPedirLibro.Name = "btnPedirLibro";
            this.btnPedirLibro.Size = new System.Drawing.Size(163, 58);
            this.btnPedirLibro.TabIndex = 2;
            this.btnPedirLibro.Text = "Hacer Prestamo";
            this.btnPedirLibro.UseVisualStyleBackColor = true;
            // 
            // txtNumCarnet
            // 
            this.txtNumCarnet.Location = new System.Drawing.Point(132, 108);
            this.txtNumCarnet.Name = "txtNumCarnet";
            this.txtNumCarnet.Size = new System.Drawing.Size(115, 20);
            this.txtNumCarnet.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Num Carnet";
            // 
            // FrmPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumCarnet);
            this.Controls.Add(this.btnPedirLibro);
            this.Name = "FrmPrestamo";
            this.Text = "FrmPrestamo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPedirLibro;
        private System.Windows.Forms.TextBox txtNumCarnet;
        private System.Windows.Forms.Label label1;
    }
}
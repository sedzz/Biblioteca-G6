using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace CapaPresentacion
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            // todo Trabajando directamente con gestion de Program
            //if (!string.IsNullOrEmpty(errores))
            //{
            //    MessageBox.Show(errores, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            // todo El DataGridView genera las columnas en función de las propiedades de la colección que recibe
            //dgvUsuarios.DataSource = null; // todo quito los que tuviera
            //if (usuarios.Count == 0)
            //{
            //    MessageBox.Show("No hay ninguno", "Atenció ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //dgvUsuarios.DataSource = usuarios;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

        }
    }
}

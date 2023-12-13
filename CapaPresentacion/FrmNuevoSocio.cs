using System;
using System.Collections.Generic;
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
    public partial class FrmNuevoSocio : Form
    {
        public FrmNuevoSocio()
        {
            InitializeComponent();
        }
        //Este botón es el que añade nuevos socios lectores a la base de datos
        private void btnAñadir_Click(object sender, EventArgs e)
        {
            //Compruebo que no queden campos vacíos.
            if (string.IsNullOrWhiteSpace(txtNombre.Text)||string.IsNullOrWhiteSpace(txtContraseña.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("No pueden quedar campos vacíos"); return;
            }
            //Añado el nuevo socio, y si hay errores los muestro, si no, muestro que se ha añadido correctamente.
            GestorBiblioteca gestor = new GestorBiblioteca();
            string errores;
            gestor.AñadirLector(out errores, txtNombre.Text, txtContraseña.Text, txtTelefono.Text, txtEmail.Text);
            if (errores != "")
            {
                MessageBox.Show(errores);
            }
            else
            {
                MessageBox.Show("Socio añadido correctamente");
            } 
            FrmLectores frmLectores = new FrmLectores();
            frmLectores.Show();
            Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Hide();
            FrmLectores frmLectores = new FrmLectores();
            frmLectores.Show();
        }
    }
}

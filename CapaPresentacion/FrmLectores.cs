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
using Entidades;

namespace CapaPresentacion
{
    public partial class FrmLectores : Form
    {
        public FrmLectores()
        {
            InitializeComponent();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            string errores;
            List<Lector> lectores = Consultas.ObtenerTodosLosLectores(out errores);
            dgvSocios.DataSource = lectores;
            if (errores != "")
            {
                MessageBox.Show(errores);
            }
        }

        private void btnBuscarNombre_Click(object sender, EventArgs e)
        {
            string errores;
            List<Lector> lectores = Consultas.BuscarLectorPorPorcionNombre(txtTrozoNombre.Text, out errores);
            dgvSocios.DataSource = lectores;
            if (errores != "")
            {
                MessageBox.Show(errores);
            }
        }

        private void btnBuscarId_Click(object sender, EventArgs e)
        {
            string errores;
            List<Lector> lector = new List<Lector>();
            lector.Add(Consultas.BuscarLectorPorID(txtNumCarnet.Text, out errores));
            dgvSocios.DataSource = lector;
            if (errores != "")
            {
                MessageBox.Show(errores);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();

            this.Close();

            
        }

        private void btnNuevoSocio_Click(object sender, EventArgs e)
        {
            FrmNuevoSocio frmNuevoSocio = new FrmNuevoSocio();
            frmNuevoSocio.Show();
            Hide();
        }
    }
}

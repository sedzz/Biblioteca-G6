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
        }
    }
}

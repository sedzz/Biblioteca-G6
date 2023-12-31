﻿using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class FrmMorosos : Form
    {
        public FrmMorosos()
        {
            InitializeComponent();
        }

        private void FrmMorosos_Load(object sender, EventArgs e)
        {
            List<Lector> morosos = Program.gestion.Morosos(out string errores);
            if (morosos.Count == 0)
            {
                MessageBox.Show(errores, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmMenu frmMenu = new FrmMenu();
                frmMenu.Show();
                this.Close();
            }
            else
            {
                dgvUsuarios.DataSource = morosos;
            }
        
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}

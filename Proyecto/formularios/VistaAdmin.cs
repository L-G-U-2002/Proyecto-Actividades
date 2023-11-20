using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.formularios
{
    public partial class VistaAdmin : Form
    {
        public VistaAdmin()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loginEmpleado devolver = new loginEmpleado();
            // Mostrar el formulario y ocultar el primero
            devolver.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listaEmpleado devolver = new listaEmpleado();
            // Mostrar el formulario y ocultar el primero
            devolver.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Actividades devolver = new Actividades();
            // Mostrar el formulario y ocultar el primero
            devolver.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultarActividades devolver = new ConsultarActividades();
            // Mostrar el formulario y ocultar el primero
            devolver.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Proyecto devolver = new Proyecto();
            // Mostrar el formulario y ocultar el primero
            devolver.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listatareas devolver = new listatareas();
            // Mostrar el formulario y ocultar el primero
            devolver.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cargo devolver = new Cargo();
            // Mostrar el formulario y ocultar el primero
            devolver.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            areaEmpresa devolver = new areaEmpresa();
            // Mostrar el formulario y ocultar el primero
            devolver.Show();
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            

        }
        
        private void consultarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BusquedaEmpleado devolver = new BusquedaEmpleado();
            // Mostrar el formulario y ocultar el primero
            devolver.Show();
            this.Hide();
        }
        private Form formularioHijoAbierto = null;
        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // Verificar si ya hay un formulario hijo abierto y cerrarlo si es necesario.
            if (formularioHijoAbierto != null)
            {
                formularioHijoAbierto.Close();
            }

            // Establecer el nuevo formulario hijo y mostrarlo.
            formularioHijoAbierto = formularioHijo;
            formularioHijo.MdiParent = this; // Esto asume que el formulario padre es un formulario MDI.
            formularioHijo.Show();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (formularioRegistrarPersonal == null || formularioRegistrarPersonal.IsDisposed)
            {
                if (isHijaMinimizada)
                {
                    formularioRegistrarPersonal = new VsAcTxEmple();
                    //formularioRegistrarPersonal.WindowMinimized += FormularioRegistrarPersonal_WindowMinimized;
                    formularioRegistrarPersonal.Show();
                    isHijaMinimizada = false;
                }
                else
                {
                    formularioRegistrarPersonal = new VsAcTxEmple();
                    formularioRegistrarPersonal.Show();
                }
            }
            else
            {
                formularioRegistrarPersonal.WindowState = FormWindowState.Normal;
                formularioRegistrarPersonal.BringToFront();
            }
        }
        private bool isHijaMinimizada = false;
        private VsAcTxEmple formularioRegistrarPersonal;
        private void FormularioRegistrarPersonal_WindowMinimized(object sender, EventArgs e)
        {
            isHijaMinimizada = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de cerrar Sesion?", "aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Close();
        }

        private void VistaAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        
    }
}

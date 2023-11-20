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
            devolver.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listaEmpleado devolver = new listaEmpleado();
            // Mostrar el formulario y ocultar el primero
            devolver.ShowDialog();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Actividades devolver = new Actividades();
            // Mostrar el formulario y ocultar el primero
            devolver.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConsultarActividades devolver = new ConsultarActividades();
            // Mostrar el formulario y ocultar el primero
            devolver.ShowDialog();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Proyecto devolver = new Proyecto();
            // Mostrar el formulario y ocultar el primero
            devolver.ShowDialog();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listatareas devolver = new listatareas();
            // Mostrar el formulario y ocultar el primero
            devolver.ShowDialog();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cargo devolver = new Cargo();
            // Mostrar el formulario y ocultar el primero
            devolver.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            areaEmpresa devolver = new areaEmpresa();
            // Mostrar el formulario y ocultar el primero
            devolver.ShowDialog();
           
        }

        
        
        private void consultarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BusquedaEmpleado devolver = new BusquedaEmpleado();
            // Mostrar el formulario y ocultar el primero
            devolver.ShowDialog();
            
        }
       
        private void button9_Click(object sender, EventArgs e)
        {
            VsAcTxEmple dm =new VsAcTxEmple();
            dm.ShowDialog();

        }
        
        

        private void button10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro de cerrar Sesion?", "aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Close();

        }

        private void VistaAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void VistaAdmin_Load(object sender, EventArgs e)
        {
            MessageBox.Show(lblCargo.Text);
            if (lblCargo.Text.Trim().ToUpper() == "emple")
            {
                button1.Enabled = false;
                consultasToolStripMenuItem.Enabled = false;
                button1.Enabled = false;
                button6.Enabled = false;
                button5.Enabled = false;
                button3.Enabled= false;
                button8.Enabled = false;
                button7.Enabled = false;
                button4.Enabled = false;
                button2.Enabled = false;

                //--acceso
                button9.Visible = true;

            }
                     
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

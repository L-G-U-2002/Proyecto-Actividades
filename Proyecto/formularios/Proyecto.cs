using Proyecto.capadatos;
using Proyecto.capalogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.formularios
{
    public partial class Proyecto : Form
    {
        public Proyecto()
        {
            InitializeComponent();
        }

        void nuevo()
        {
            txtIDproyecto.Clear();
            txtnomproyecto.Clear();
            txtIDproyecto.Focus();
        }

        private void Proyecto_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VistaAdmin devolver = new VistaAdmin();
            // Mostrar el formulario y ocultar el primero
            Close();
            devolver.Show();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MetodoProyecto Gl = new MetodoProyecto();
            Gl.id_proyecto = txtIDproyecto.Text;
            try
            {
                ClsProyecto.BuscarProyecto(Gl);
            }
            catch (Exception) { MessageBox.Show("Codigo no encontrado"); }
            txtnomproyecto.Text = Gl.nom_proyecto;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Rpt;

            Rpt = MessageBox.Show("¿Deseas grabar nuevo proyecto?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Rpt == DialogResult.Yes)
            {
                MetodoProyecto Gl = new MetodoProyecto();
                Gl.id_proyecto = txtIDproyecto.Text;
                Gl.nom_proyecto = txtnomproyecto.Text;
                ClsProyecto.InsertarProyecto(Gl);

                MessageBox.Show("Se Ingreso Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            nuevo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult Rpt;

            Rpt = MessageBox.Show("¿Deseas actualizar el proyecto asignado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Rpt == DialogResult.Yes)
            {
                MetodoProyecto Gl = new MetodoProyecto();
                Gl.id_proyecto = txtIDproyecto.Text;
                Gl.nom_proyecto = txtnomproyecto.Text;
                ClsProyecto.EditarProyecto(Gl);

                MessageBox.Show("Se actualizó correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nuevo();
        }
    }
}

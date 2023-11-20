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
    public partial class listatareas : Form
    {
        public listatareas()
        {
            InitializeComponent();
        }

        void nuevo()
        {
            txtIDtarea.Clear();
            txtnomtarea.Clear();
            txtIDtarea.Focus();
        }

        private void listatareas_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MetodoTarea Gl = new MetodoTarea();
            Gl.id_tarea = txtIDtarea.Text;
            try
            {
                ClsTarea.BuscarTarea(Gl);
            }
            catch (Exception) { MessageBox.Show("Codigo no encontrado"); }
            txtnomtarea.Text = Gl.nom_tarea;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VistaAdmin devolver = new VistaAdmin();
            // Mostrar el formulario y ocultar el primero
            Close();
            devolver.Show();
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Rpt;

            Rpt = MessageBox.Show("¿Deseas grabar nueva tarea?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Rpt == DialogResult.Yes)
            {
                MetodoTarea Gl = new MetodoTarea();
                Gl.id_tarea = txtIDtarea.Text;
                Gl.nom_tarea = txtnomtarea.Text;
                ClsTarea.InsertarTarea(Gl);

                MessageBox.Show("Se Ingreso Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult Rpt;

            Rpt = MessageBox.Show("¿Deseas actualizar esta tarea?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Rpt == DialogResult.Yes)
            {
                MetodoTarea Gl = new MetodoTarea();
                Gl.id_tarea = txtIDtarea.Text;
                Gl.nom_tarea = txtnomtarea.Text;
                ClsTarea.EditarTarea(Gl);

                MessageBox.Show("Se actualizó correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nuevo();
        }
    }
}

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
    public partial class areaEmpresa : Form
    {
        public areaEmpresa()
        {
            InitializeComponent();
        }

        void nuevo()
        {
            txtIDarea.Clear();
            txtnomarea.Clear();
            txtIDarea.Focus();
        }

        private void areaEmpresa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // Mostrar el formulario y ocultar el primero
            Close();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MetodoAreaEmpresa Gl = new MetodoAreaEmpresa();
            Gl.id_area = txtIDarea.Text;
            try
            {
                ClsAreaEmpresa.BuscarAreaEmpresa(Gl);
            }
            catch (Exception) { MessageBox.Show("Codigo no encontrado"); }
            txtnomarea.Text = Gl.nom_area;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult Rpt;

            Rpt = MessageBox.Show("¿Deseas actualizar el área de la empresa?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Rpt == DialogResult.Yes)
            {
                MetodoAreaEmpresa Gl = new MetodoAreaEmpresa();
                Gl.id_area = txtIDarea.Text;
                Gl.nom_area = txtnomarea.Text;
                ClsAreaEmpresa.EditarAreaEmpresa(Gl);

                MessageBox.Show("Se actualizó correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Rpt;

            Rpt = MessageBox.Show("¿Deseas grabar nueva área?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Rpt == DialogResult.Yes)
            {
                MetodoAreaEmpresa Gl = new MetodoAreaEmpresa();
                Gl.id_area = txtIDarea.Text;
                Gl.nom_area = txtnomarea.Text;
                ClsAreaEmpresa.InsertarAreaEmpresa(Gl);

                MessageBox.Show("Se Ingreso Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

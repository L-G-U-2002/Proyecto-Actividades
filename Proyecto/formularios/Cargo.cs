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
    public partial class Cargo : Form
    {
        public Cargo()
        {
            InitializeComponent();
        }

        void nuevo()
        {
            txtIDcargo.Clear();
            txtnomcargo.Clear();
            txtIDcargo.Focus();
        }

        private void Cargo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            // Mostrar el formulario y ocultar el primero
            Close();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MetodoCargo Gl = new MetodoCargo();
            Gl.id_cargo = txtIDcargo.Text;
            try
            {
                ClsCargo.BuscarCargo(Gl);
            }
            catch (Exception) { MessageBox.Show("Codigo no encontrado"); }
            txtnomcargo.Text = Gl.nom_cargo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Rpt;

            Rpt = MessageBox.Show("¿Deseas grabar nuevo cargo?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Rpt == DialogResult.Yes)
            {
                MetodoCargo Gl = new MetodoCargo();
                Gl.id_cargo = txtIDcargo.Text;
                Gl.nom_cargo = txtnomcargo.Text;
                ClsCargo.InsertarCargo(Gl);

                MessageBox.Show("Se Ingreso Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult Rpt;

            Rpt = MessageBox.Show("¿Deseas actualizar el cargo asignado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Rpt == DialogResult.Yes)
            {
                MetodoCargo Gl = new MetodoCargo();
                Gl.id_cargo = txtIDcargo.Text;
                Gl.nom_cargo = txtnomcargo.Text;
                ClsCargo.EditarCargo(Gl);

                MessageBox.Show("Se actualizó correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nuevo();
        }
    }
}

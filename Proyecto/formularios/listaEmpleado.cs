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
    public partial class listaEmpleado : Form
    {
        public listaEmpleado()
        {
            InitializeComponent();
        }

        void nuevo()
        {
            txtIDempleado.Clear();
            txtnom_ape.Clear();
            txtdni.Clear();
            txtdireccion.Clear();
            txttelefono.Clear();
            txtcorreo.Clear();
            cbarea.Text = "Seleccionar";
            cbcargo.Text = "Seleccionar";
            txtIDempleado.Focus();
        }

        private void LlenarArea()
        {
            ClsAreaEmpresa.LLenarcomboboxA();
            cbarea.DataSource = ClsAreaEmpresa.dt;
            cbarea.DisplayMember = "nom_area";
            cbarea.ValueMember = "id_area";
            cbarea.Text = "Seleccionar";
        }
        private void LlenarCargo()
        {
            ClsCargo.LLenarcomboboxC();
            cbcargo.DataSource = ClsCargo.dt;
            cbcargo.DisplayMember = "nom_cargo";
            cbcargo.ValueMember = "id_cargo";
            cbcargo.Text = "Seleccionar";
        }

        private void listaEmpleado_Load(object sender, EventArgs e)
        {
            LlenarArea();
            LlenarCargo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VistaAdmin devolver = new VistaAdmin();
            // Mostrar el formulario y ocultar el primero
            Close();
            devolver.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nuevo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MetodoEmpleado Gl = new MetodoEmpleado();
            Gl.id_empleado = txtIDempleado.Text;
            try
            {
                ClsEmpleado.BuscarEmpleado(Gl);
            }
            catch (Exception) { MessageBox.Show("Empleado no encontrado"); }
            txtnom_ape.Text = Gl.nombre_apellido;
            txtdni.Text = Gl.dni;
            txtdireccion.Text = Gl.direccion;
            txttelefono.Text = Gl.telefono;
            txtcorreo.Text = Gl.correo;
            cbarea.FormatString = Gl.id_area;
            cbcargo.FormatString = Gl.id_cargo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Rpt;

            Rpt = MessageBox.Show("¿Deseas grabar nuevo empleado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Rpt == DialogResult.Yes)
            {
                MetodoEmpleado Gl = new MetodoEmpleado();
                Gl.id_empleado = txtIDempleado.Text;
                Gl.nombre_apellido = txtnom_ape.Text;
                Gl.dni = txtdni.Text;
                Gl.direccion = txtdireccion.Text;
                Gl.telefono = txttelefono.Text;
                Gl.correo = txtcorreo.Text;
                Gl.id_area = cbarea.SelectedValue.ToString();
                Gl.id_cargo = cbcargo.SelectedValue.ToString();

                ClsEmpleado.InsertarEmpleado(Gl);

                MessageBox.Show("Se Ingreso Empleado Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            nuevo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult Rpt;

            Rpt = MessageBox.Show("¿Deseas actualizar los datos del empleado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Rpt == DialogResult.Yes)
            {
                MetodoEmpleado Gl = new MetodoEmpleado();
                Gl.id_empleado = txtIDempleado.Text;
                Gl.nombre_apellido = txtnom_ape.Text;
                Gl.dni = txtdni.Text;
                Gl.direccion = txtdireccion.Text;
                Gl.telefono = txttelefono.Text;
                Gl.correo = txtcorreo.Text;
                Gl.id_area = cbarea.SelectedValue.ToString();
                Gl.id_cargo = cbcargo.SelectedValue.ToString();
                ClsEmpleado.EditarEmpleado(Gl);

                MessageBox.Show("Se actualizó correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}

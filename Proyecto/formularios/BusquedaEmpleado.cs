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
    public partial class BusquedaEmpleado : Form
    {
        public BusquedaEmpleado()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            // Mostrar el formulario y ocultar el primero
            Close();
          
            
        }

        private void BusquedaEmpleado_Load(object sender, EventArgs e)
        {
            cbelegir.Items.Add("Nombres y Apellidos");
            cbelegir.Items.Add("Cargo");
            cbelegir.Items.Add("Área");

            ClsEmpleado.ListarEmpleado();
            digitoEmpleados.DataSource = ClsEmpleado.ds;
            digitoEmpleados.DataMember = "Cargar Empleados";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MetodoEmpleado Gl = new MetodoEmpleado();
            if (cbelegir.SelectedIndex == 0)
            {
                Gl.nombre_apellido = txtbuscar.Text;
                ClsEmpleado.ConsultarEmpleadoNombre(Gl);
                digitoEmpleados.DataSource = ClsEmpleado.ds;
                digitoEmpleados.DataMember = "Cargar Nombre y Apellido";
            }
            if (cbelegir.SelectedIndex == 1)
            {
                Gl.cargo = txtbuscar.Text;
                ClsEmpleado.ConsultarEmpleadoCargo(Gl);
                digitoEmpleados.DataSource = ClsEmpleado.ds;
                digitoEmpleados.DataMember = "Cargar Cargo";
            }
            if (cbelegir.SelectedIndex == 2)
            {
                Gl.area_empresa = txtbuscar.Text;
                ClsEmpleado.ConsultarEmpleadoArea(Gl);
                digitoEmpleados.DataSource = ClsEmpleado.ds;
                digitoEmpleados.DataMember = "Cargar Area de Empresa";
            }
        }

        private void cbelegir_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

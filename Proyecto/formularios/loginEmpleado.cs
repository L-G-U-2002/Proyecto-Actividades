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
    public partial class loginEmpleado : Form
    {
        public loginEmpleado()
        {
            InitializeComponent();
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
            DialogResult resultado = MessageBox.Show("¿Deseas crear un nuevo usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Obtén los datos del formulario
                MetodoUsuario MU = new MetodoUsuario();
                MU.id_empleado = txtIDemp.Text;
                MU.usuario = txtus.Text;
                MU.clave = txtclave.Text;

                // Llama al procedimiento almacenado
                string mensaje = ClsUsuario.CrearUsuario(MU);

                // Verifica el resultado del procedimiento y muestra el mensaje adecuado
                if (mensaje == "Se ha registrado un nuevo usuario.")
                {
                    MessageBox.Show("Usuario registrado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (mensaje == "El ID Empleado no existe.")
                {
                    MessageBox.Show("El ID Empleado no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (mensaje == "El ID Empleado ya tiene una cuenta registrada.")
                {
                    MessageBox.Show("El ID Empleado ya tiene una cuenta registrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

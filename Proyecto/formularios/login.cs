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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
        public VistaAdmin InstanciaInicio { get; private set; }
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var Usuario = txtus.Text;
                var Clave = txtclave.Text;
                DataTable Datos = ClsUsuario.Login(Usuario, Clave);

                InstanciaInicio = new VistaAdmin();
                InstanciaInicio.label3.Text = Datos.Rows[0][0].ToString();
                InstanciaInicio.lblCargo.Text = Datos.Rows[0][2].ToString();
                InstanciaInicio.lblUsuario.Text = Datos.Rows[0][1].ToString();
                if (Datos.Rows.Count > 0)
                {
                    
                    Hide();
                    InstanciaInicio.FormClosed += cerrar;
                   
                    InstanciaInicio.ShowDialog();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Usuario no encontrado");
            }
            //txtus.Text = Gl.usuario;
            //txtclave.Text = Gl.clave;
        }
        private void cerrar(object sender, FormClosedEventArgs e)
        {
            txtus.Clear();
            txtclave .Clear();
            
            Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtclave.PasswordChar == '*')
            {
                // Mostrar el texto de la contraseña
                txtclave.PasswordChar = '\0'; // El carácter nulo desactiva la máscara de contraseña
            }
            else
            {
                // Ocultar el texto de la contraseña
                txtclave.PasswordChar = '*';
            }
        }
    }
}

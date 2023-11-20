using Proyecto.capadatos;
using Proyecto.capalogica;
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
    public partial class ConsultarActividades : Form
    {
        public static SqlConnection Cn;

        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;
        public void LLenartabladata()
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cn.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = Cn;
            da.SelectCommand.CommandText = "listar_actividades";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            da.Fill(dt);
            digitoActividades.DataSource = dt;
            digitoActividades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Cn.Close();
        }
        public ConsultarActividades()
        {
            InitializeComponent();
        }

        private void ConsultarActividades_Load(object sender, EventArgs e)
        {
            LLenartabladata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VistaAdmin devolver = new VistaAdmin();
            // Mostrar el formulario y ocultar el primero
            Close();
            devolver.Show();
          
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbuscar.Text))
            {
                LLenartabladata();
            }
            else
            {
                MetodoActividades Gl = new MetodoActividades();
                Gl.actividad = txtbuscar.Text;
                ClsActividades.ConsultarLista(Gl);
                digitoActividades.DataSource = ClsActividades.ds;
                digitoActividades.DataMember = "Cargar Lista";
            }
        }
    }
}

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto.formularios
{
    public partial class VsAcTxEmple : Form
    {
        public static SqlConnection Cn;

        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;
        public VsAcTxEmple()
        {
            InitializeComponent();
        }

        private void LLenarcomboboxES()
        {
            ClsActividades.LLenarcomboboxES();
            cbestado.DataSource = ClsActividades.dt;
            cbestado.DisplayMember = "nom_estado";
            cbestado.ValueMember = "id_estado";
            cbestado.Text = "Activado";
        }

        public  void ListActividad(string ID)
        {

            ((DataTable)dataActiXemple.DataSource)?.Clear();
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cn.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = Cn;
            da.SelectCommand.CommandText = "VsAcTxEmple";
            da.SelectCommand.Parameters.AddWithValue("@empleado",ID);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            ds = new DataSet();
            da.Fill(ds, "Cargar Actividad");
            DataTable dataTable = ds.Tables["Cargar Actividad"];

            dataActiXemple.DataSource = dataTable;
            Cn.Close();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
           

            lblCantidad.Text = "TOTAL DE ACTIVIDADES " + dataActiXemple.Rows.Count;
        }

        private void txtbuscID_TextChanged(object sender, EventArgs e)
        {

        }

        private void VsAcTxEmple_Load(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)dataActiXemple.DataSource;
            if (dataTable != null)
            {
                LimpiarDataActiXemple();
            }
            VistaAdmin LG = ((login)Application.OpenForms["login"]).InstanciaInicio;
            string ID = LG.label3.Text;
            ListActividad(ID);
            LLenarcomboboxES();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
          Close();
        }
        public void LimpiarDataActiXemple()
        {
            DataTable dataTable = (DataTable)dataActiXemple.DataSource;
            dataTable.Clear();
            dataTable.Dispose();
            dataActiXemple.DataSource = null;
            
        }

        private void dataActiXemple_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lbltarea.Text = this.dataActiXemple.Rows[e.RowIndex].Cells[3].Value.ToString();
            lblproyecto.Text = this.dataActiXemple.Rows[e.RowIndex].Cells[2].Value.ToString();
            lblFechaI.Text = this.dataActiXemple.Rows[e.RowIndex].Cells[6].Value.ToString();
            lblFechaF.Text = this.dataActiXemple.Rows[e.RowIndex].Cells[7].Value.ToString();
            lblDescripcion.Text = this.dataActiXemple.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void lblCantidad_Click(object sender, EventArgs e)
        {

        }
    }
}

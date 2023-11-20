using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.capadatos;

namespace Proyecto.capalogica
{
    public class ClsActividades
    {
        public static SqlConnection Cn;
        public static SqlCommand Cm;
        public static SqlDataReader dr;
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;

        public static void LLenarcomboboxES()
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cn.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = Cn;
            da.SelectCommand.CommandText = "EstadoIn";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            da.Fill(dt);

            Cn.Close();
        }
        public static void InsertarActividades(MetodoActividades c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandText = "InsertarActividades";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.Add(new SqlParameter("@remitente", SqlDbType.VarChar));
            Cm.Parameters["@remitente"].Value = c.remitente;
            Cm.Parameters.Add(new SqlParameter("@id_empleado", SqlDbType.VarChar));
            Cm.Parameters["@id_empleado"].Value = c.id_empleado;
            Cm.Parameters.Add(new SqlParameter("@id_proyecto", SqlDbType.VarChar));
            Cm.Parameters["@id_proyecto"].Value = c.id_proyecto;
            Cm.Parameters.Add(new SqlParameter("@id_tarea", SqlDbType.VarChar));
            Cm.Parameters["@id_tarea"].Value = c.id_tarea;

            Cm.Parameters.Add(new SqlParameter("@id_estado", SqlDbType.Int));
            Cm.Parameters["@id_estado"].Value = c.estado;

            Cm.Parameters.Add(new SqlParameter("@descripcion", SqlDbType.VarChar));
            Cm.Parameters["@descripcion"].Value = c.descripcion;
            Cm.Parameters.Add(new SqlParameter("@fecha_inicio", SqlDbType.Date));
            Cm.Parameters["@fecha_inicio"].Value = c.fecha_inicio;
            Cm.Parameters.Add(new SqlParameter("@fecha_fin", SqlDbType.Date));
            Cm.Parameters["@fecha_fin"].Value = c.fecha_fin;
            Cn.Open();
            Cm.ExecuteNonQuery();
            Cn.Close();
        }

    }
}

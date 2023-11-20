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
    public class ClsTarea
    {
        public static SqlConnection Cn;
        public static SqlCommand Cm;
        public static SqlDataReader dr;
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;

        public static void LLenarcomboboxT()
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cn.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = Cn;
            da.SelectCommand.CommandText = "ListarTarea";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            da.Fill(dt);

            Cn.Close();
        }

        public static void InsertarTarea(MetodoTarea c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandText = "InsertarTarea";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.Add(new SqlParameter("@id_tarea", SqlDbType.VarChar));
            Cm.Parameters["@id_tarea"].Value = c.id_tarea;
            Cm.Parameters.Add(new SqlParameter("@nom_tarea", SqlDbType.VarChar));
            Cm.Parameters["@nom_tarea"].Value = c.nom_tarea;
            Cn.Open();
            Cm.ExecuteNonQuery();
            Cn.Close();
        }
        public static void EditarTarea(MetodoTarea c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandText = "EditarTarea";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.Add(new SqlParameter("@id_tarea", SqlDbType.VarChar));
            Cm.Parameters["@id_tarea"].Value = c.id_tarea;
            Cm.Parameters.Add(new SqlParameter("@nom_tarea", SqlDbType.VarChar));
            Cm.Parameters["@nom_tarea"].Value = c.nom_tarea;
            Cn.Open();
            Cm.ExecuteNonQuery();
            Cn.Close();
        }

        public static void BuscarTarea(MetodoTarea c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cn.Open();
            Cm.CommandText = "BuscarTarea";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.AddWithValue("@id_tarea", c.id_tarea);
            dr = Cm.ExecuteReader();
            if (dr.HasRows == false)
            {
                throw new Exception("Tarea Inexistente");
            }
            while (dr.Read())
            {
                c.id_tarea = dr[0].ToString();
                c.nom_tarea = dr[1].ToString();
            }
            Cn.Close();

        }
    }
}

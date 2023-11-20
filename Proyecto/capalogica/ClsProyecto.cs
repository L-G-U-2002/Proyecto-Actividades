using Proyecto.capadatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.capalogica
{
    public class ClsProyecto
    {
        public static SqlConnection Cn;
        public static SqlCommand Cm;
        public static SqlDataReader dr;
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;

        public static void LLenarcomboboxP()
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cn.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = Cn;
            da.SelectCommand.CommandText = "ListarProyecto";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            da.Fill(dt);

            Cn.Close();
        }

        public static void InsertarProyecto(MetodoProyecto c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandText = "InsertarProyecto";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.Add(new SqlParameter("@id_proyecto", SqlDbType.VarChar));
            Cm.Parameters["@id_proyecto"].Value = c.id_proyecto;
            Cm.Parameters.Add(new SqlParameter("@nom_proyecto", SqlDbType.VarChar));
            Cm.Parameters["@nom_proyecto"].Value = c.nom_proyecto;
            Cn.Open();
            Cm.ExecuteNonQuery();
            Cn.Close();
        }
        public static void EditarProyecto(MetodoProyecto c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandText = "EditarProyecto";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.Add(new SqlParameter("@id_proyecto", SqlDbType.VarChar));
            Cm.Parameters["@id_proyecto"].Value = c.id_proyecto;
            Cm.Parameters.Add(new SqlParameter("@nom_proyecto", SqlDbType.VarChar));
            Cm.Parameters["@nom_proyecto"].Value = c.nom_proyecto;
            Cn.Open();
            Cm.ExecuteNonQuery();
            Cn.Close();
        }

        public static void BuscarProyecto(MetodoProyecto c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cn.Open();
            Cm.CommandText = "BuscarProyecto";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.AddWithValue("@id_proyecto", c.id_proyecto);
            dr = Cm.ExecuteReader();
            if (dr.HasRows == false)
            {
                throw new Exception("Proyecto Inexistente");
            }
            while (dr.Read())
            {
                c.id_proyecto = dr[0].ToString();
                c.nom_proyecto = dr[1].ToString();
            }
            Cn.Close();
        }
    }
}

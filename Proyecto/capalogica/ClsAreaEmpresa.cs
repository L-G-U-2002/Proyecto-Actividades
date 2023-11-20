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
    public class ClsAreaEmpresa
    {
        public static SqlConnection Cn;
        public static SqlCommand Cm;
        public static SqlDataReader dr;
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;

        public static void LLenarcomboboxA()
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cn.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = Cn;
            da.SelectCommand.CommandText = "ListarAreaEmpleado";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            da.Fill(dt);

            Cn.Close();
        }
        public static void InsertarAreaEmpresa(MetodoAreaEmpresa c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandText = "InsertarAreaEmpresa";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.Add(new SqlParameter("@id_area", SqlDbType.VarChar));
            Cm.Parameters["@id_area"].Value = c.id_area;
            Cm.Parameters.Add(new SqlParameter("@nom_area", SqlDbType.VarChar));
            Cm.Parameters["@nom_area"].Value = c.nom_area;
            Cn.Open();
            Cm.ExecuteNonQuery();
            Cn.Close();
        }
        public static void EditarAreaEmpresa(MetodoAreaEmpresa c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandText = "EditarAreaEmpresa";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.Add(new SqlParameter("@id_area", SqlDbType.VarChar));
            Cm.Parameters["@id_area"].Value = c.id_area;
            Cm.Parameters.Add(new SqlParameter("@nom_area", SqlDbType.VarChar));
            Cm.Parameters["@nom_area"].Value = c.nom_area;
            Cn.Open();
            Cm.ExecuteNonQuery();
            Cn.Close();
        }

        public static void BuscarAreaEmpresa(MetodoAreaEmpresa c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cn.Open();
            Cm.CommandText = "BuscarAreaEmpresa";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.AddWithValue("@id_area", c.id_area);
            dr = Cm.ExecuteReader();
            if (dr.HasRows == false)
            {
                throw new Exception("Area de Empresa Inexistente");
            }
            while (dr.Read())
            {
                c.id_area = dr[0].ToString();
                c.nom_area = dr[1].ToString();
            }
            Cn.Close();

        }

    }
}

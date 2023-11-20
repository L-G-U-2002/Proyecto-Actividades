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
    public class ClsCargo
    {
        public static SqlConnection Cn;
        public static SqlCommand Cm;
        public static SqlDataReader dr;
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;

        public static void LLenarcomboboxC()
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cn.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = Cn;
            da.SelectCommand.CommandText = "ListarCargo";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            da.Fill(dt);

            Cn.Close();
        }

        public static void InsertarCargo(MetodoCargo c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandText = "InsertarCargo";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.Add(new SqlParameter("@id_cargo", SqlDbType.VarChar));
            Cm.Parameters["@id_cargo"].Value = c.id_cargo;
            Cm.Parameters.Add(new SqlParameter("@nom_cargo", SqlDbType.VarChar));
            Cm.Parameters["@nom_cargo"].Value = c.nom_cargo;
            Cn.Open();
            Cm.ExecuteNonQuery();
            Cn.Close();
        }
        public static void EditarCargo(MetodoCargo c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandText = "EditarCargo";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.Add(new SqlParameter("@id_cargo", SqlDbType.VarChar));
            Cm.Parameters["@id_cargo"].Value = c.id_cargo;
            Cm.Parameters.Add(new SqlParameter("@nom_cargo", SqlDbType.VarChar));
            Cm.Parameters["@nom_cargo"].Value = c.nom_cargo;
            Cn.Open();
            Cm.ExecuteNonQuery();
            Cn.Close();
        }

        public static void BuscarCargo(MetodoCargo c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cn.Open();
            Cm.CommandText = "BuscarCargo";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.AddWithValue("@id_cargo", c.id_cargo);
            dr = Cm.ExecuteReader();
            if (dr.HasRows == false)
            {
                throw new Exception("Area de Empresa Inexistente");
            }
            while (dr.Read())
            {
                c.id_cargo = dr[0].ToString();
                c.nom_cargo = dr[1].ToString();
            }
            Cn.Close();

        }
    }
}

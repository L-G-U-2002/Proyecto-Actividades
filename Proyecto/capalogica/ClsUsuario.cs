using Proyecto.capadatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.capalogica
{
    public class ClsUsuario
    {
        public static SqlConnection Cn;
        public static SqlCommand Cm;
        public static SqlDataReader dr;
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable Login(string usuario, string password)
        {
            MetodoUsuario Obj = new MetodoUsuario();
            Obj.usuario = usuario;
            Obj.clave = password;
            return Obj.Login(Obj);
        }
        public static string CrearUsuario(MetodoUsuario u)
        {
            String resultado = "";

            using (SqlConnection Cn = new SqlConnection(ClsConexion.cnCadena()))
            {
                try{
                    SqlCommand Cm = new SqlCommand("CrearUsuario", Cn);
                    Cm.Parameters.AddWithValue("@id_empleado", u.id_empleado);
                    Cm.Parameters.AddWithValue("@usuario", u.usuario);
                    Cm.Parameters.AddWithValue("@clave", u.clave);
                    Cm.CommandType = CommandType.StoredProcedure;
                    Cn.Open();

                    SqlDataReader dr = Cm.ExecuteReader();

                    if (dr.Read())
                    {
                        resultado = dr["resultado"].ToString();
                    }

                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se puede buscarCuenta, error: " + ex);
                }


            }

            return resultado; // Devuelve un mensaje de error por defecto si no se puede determinar la causa del error
        }

        
    }
}

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
    public class ClsEmpleado
    {
        public static SqlConnection Cn;
        public static SqlCommand Cm;
        public static SqlDataReader dr;
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;

        public static void LLenarcomboboxAd()
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cn.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = Cn;
            da.SelectCommand.CommandText = "ListarRemitente";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            da.Fill(dt);

            Cn.Close();
        }

        public static void LLenarcomboboxEm()
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cn.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = Cn;
            da.SelectCommand.CommandText = "ListarDestinatario";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            dt = new DataTable();
            da.Fill(dt);

            Cn.Close();
        }

        public static void InsertarEmpleado(MetodoEmpleado c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandText = "InsertarEmpleado";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.Add(new SqlParameter("@id_empleado", SqlDbType.VarChar));
            Cm.Parameters["@id_empleado"].Value = c.id_empleado;
            Cm.Parameters.Add(new SqlParameter("@nombre_apellido", SqlDbType.VarChar));
            Cm.Parameters["@nombre_apellido"].Value = c.nombre_apellido;
            Cm.Parameters.Add(new SqlParameter("@dni", SqlDbType.VarChar));
            Cm.Parameters["@dni"].Value = c.dni;
            Cm.Parameters.Add(new SqlParameter("@direccion", SqlDbType.VarChar));
            Cm.Parameters["@direccion"].Value = c.direccion;
            Cm.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar));
            Cm.Parameters["@telefono"].Value = c.telefono;
            Cm.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar));
            Cm.Parameters["@correo"].Value = c.correo;
            Cm.Parameters.Add(new SqlParameter("@id_area", SqlDbType.VarChar));
            Cm.Parameters["@id_area"].Value = c.id_area;
            Cm.Parameters.Add(new SqlParameter("@id_cargo", SqlDbType.VarChar));
            Cm.Parameters["@id_cargo"].Value = c.id_cargo;
            Cn.Open();
            Cm.ExecuteNonQuery();
            Cn.Close();
        }

        public static void EditarEmpleado(MetodoEmpleado c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandText = "EditarEmpleado";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.Add(new SqlParameter("@id_empleado", SqlDbType.VarChar));
            Cm.Parameters["@id_empleado"].Value = c.id_empleado;
            Cm.Parameters.Add(new SqlParameter("@nombre_apellido", SqlDbType.VarChar));
            Cm.Parameters["@nombre_apellido"].Value = c.nombre_apellido;
            Cm.Parameters.Add(new SqlParameter("@dni", SqlDbType.VarChar));
            Cm.Parameters["@dni"].Value = c.dni;
            Cm.Parameters.Add(new SqlParameter("@direccion", SqlDbType.VarChar));
            Cm.Parameters["@direccion"].Value = c.direccion;
            Cm.Parameters.Add(new SqlParameter("@telefono", SqlDbType.VarChar));
            Cm.Parameters["@telefono"].Value = c.telefono;
            Cm.Parameters.Add(new SqlParameter("@correo", SqlDbType.VarChar));
            Cm.Parameters["@correo"].Value = c.correo;
            Cm.Parameters.Add(new SqlParameter("@id_area", SqlDbType.VarChar));
            Cm.Parameters["@id_area"].Value = c.id_area;
            Cm.Parameters.Add(new SqlParameter("@id_cargo", SqlDbType.VarChar));
            Cm.Parameters["@id_cargo"].Value = c.id_cargo;
            Cn.Open();
            Cm.ExecuteNonQuery();
            Cn.Close();
        }

        public static void BuscarEmpleado(MetodoEmpleado c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cn.Open();
            Cm.CommandText = "BuscarEmpleado";
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.Parameters.AddWithValue("@id_empleado", c.id_empleado);
            dr = Cm.ExecuteReader();
            if (dr.HasRows == false)
            {
                throw new Exception("Empleado no Encontrado");
            }
            while (dr.Read())
            {
                c.id_empleado = dr[0].ToString();
                c.nombre_apellido = dr[1].ToString();
                c.dni = dr[2].ToString();
                c.direccion = dr[3].ToString();
                c.telefono = dr[4].ToString();
                c.correo = dr[5].ToString();
                c.id_area = dr[6].ToString();
                c.id_cargo = dr[7].ToString();
            }
            Cn.Close();
        }

        public static void ListarEmpleado()
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cn.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = Cn;
            da.SelectCommand.CommandText = "listar_empleado";

            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            ds = new DataSet();
            da.Fill(ds, "Cargar Empleados");

            Cn.Close();
        }
        public static void ConsultarEmpleadoNombre(MetodoEmpleado c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cn.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = Cn;
            da.SelectCommand.CommandText = "VConsultar_Empleado_Nombre";
            da.SelectCommand.Parameters.AddWithValue("@nombre_apellido", c.nombre_apellido);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            ds = new DataSet();
            da.Fill(ds, "Cargar Nombre y Apellido");

            Cn.Close();
        }
        public static void ConsultarEmpleadoCargo(MetodoEmpleado c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cn.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = Cn;
            da.SelectCommand.CommandText = "VConsultar_Empleado_Cargo";
            da.SelectCommand.Parameters.AddWithValue("@nom_cargo", c.cargo);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            ds = new DataSet();
            da.Fill(ds, "Cargar Cargo");

            Cn.Close();
        }
        public static void ConsultarEmpleadoArea(MetodoEmpleado c)
        {
            Cn = new SqlConnection();
            Cn.ConnectionString = ClsConexion.cnCadena();
            Cn.Open();
            da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = Cn;
            da.SelectCommand.CommandText = "VConsultar_Empleado_Area";
            da.SelectCommand.Parameters.AddWithValue("@nom_area", c.area_empresa);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            ds = new DataSet();
            da.Fill(ds, "Cargar Area de Empresa");

            Cn.Close();
        }

        
    }
}

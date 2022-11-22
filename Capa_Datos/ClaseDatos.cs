using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using Capa_Logica;


namespace Capa_Datos
{
    public class ClaseDatos
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public DataTable D_listar_productos()
        {
            SqlCommand cmd = new SqlCommand("pa_listar_productos", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;


        }
        public DataTable D_buscar_producto(ClaseLogica objeto)
        {
            SqlCommand cmd = new SqlCommand("pa_buscar_producto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", objeto.Nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }

        public String D_CUD(ClaseLogica objeto)
        {
            String accion = "";
            SqlCommand cmd = new SqlCommand("pa_CUD", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_producto", objeto.ID_producto);
            cmd.Parameters.AddWithValue("@Nombre", objeto.Nombre);
            cmd.Parameters.AddWithValue("@Cantidad", objeto.Cantidad);
            cmd.Parameters.AddWithValue("@Proveedor", objeto.Proveedor);
            cmd.Parameters.AddWithValue("@Precio", objeto.Precio);

            cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = objeto.accion;
            cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            cmd.ExecuteNonQuery();
            accion = cmd.Parameters["@accion"].Value.ToString();
            cn.Close();
            return accion;

        }

        public void registroEnFactura(DateTime fecha, string Productos,
            string NombreCliente, int Cedula)
        {

            
                SqlCommand cmd = new SqlCommand("spRegistroEnFactura", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Fecha_Generada_Factura", fecha);
                cmd.Parameters.AddWithValue("@Productos", Productos);
                cmd.Parameters.AddWithValue("@Nombre_Cliente", NombreCliente);
                cmd.Parameters.AddWithValue("@cedula", Cedula);
                
                if (cn.State == ConnectionState.Open) cn.Close();
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            
        }
        
        public DataTable D_listar_productosFactura(string nombre)
        {
            

            SqlCommand cmd = new SqlCommand("pa_listar_productosFactura", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@nombre_cliente", nombre);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;


        }
    }
}

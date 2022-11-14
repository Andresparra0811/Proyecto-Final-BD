using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;


namespace Proyecto_Final_Supermercado
{
    class SQL_Control_Login
    {
        private SqlConnection conexion =
           new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public int Login(string usuario, string pass)
        {

            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("spLogin", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@pass", pass);

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }
            finally
            {
                conexion.Close();
            }


            return -1;
        }
    }

    class SQL_IngresoUsuario
    {
        private SqlConnection conexion =
           new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

        public void Ingreso(string usuario, DateTime fecha)
        {

            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("sp_FechaSesion", conexion);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@fecha", fecha);

                

                if (conexion.State == ConnectionState.Open) conexion.Close();
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); ;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CONASIS.DAL
{
    class Conexion
    {
        SqlConnection cn;
        private string cadenacnx;

        public Conexion()
        {

            string cnString;
            //Data Source=.;Initial Catalog=asistenciaue1;Integrated Security=True
            cnString = "Data Source=DESKTOP-A3FQ2FD\\SQLEXPRESS;Initial Catalog=asistenciaue1;Integrated Security=True;MultipleActiveResultSets=True";


            cn = new SqlConnection(cnString);
        }

        public Conexion(string cadenacnx)
        {
            this.cadenacnx = cadenacnx;
            cn = new SqlConnection(cadenacnx);  // ← esto faltaba
        }


        public void AbrirConexion()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al establecer conexion con el servidor de la base de datos. " + ex.Message);
            }
        }
        public void CerrarConexion()
        {
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexion con el servidor de base de datos. " + ex.Message);
            }
        }
        public SqlConnection ObtenerConexion()
        {
            return cn;
        }
        public DataSet execSQLDataSet(Conexion cn, String sql)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlCommand SqlCmd = new SqlCommand(sql, cn.ObtenerConexion());
                SqlCmd.CommandType = CommandType.Text;
                SqlDataAdapter sda = new SqlDataAdapter(SqlCmd);
                sda.Fill(ds);
                return ds;
            }
            catch
            {
                throw new Exception("Error al ejecutar una sentencia SQL no valida");
            }
        }
        public bool execSqlBool(Conexion cn, String sql)
        {
            bool resultado = false;
            try
            {
                DataSet ds = new DataSet();
                SqlCommand SqlCmd = new SqlCommand(sql, cn.ObtenerConexion());
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.ExecuteNonQuery();
                resultado = true;
            }
            catch
            {
                throw new Exception("Error al ejecutar una sentencia SQL no válida.");
            }
            return resultado;
        }
        
    }
}

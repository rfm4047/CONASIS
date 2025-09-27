using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CONASIS.DAL
{
    public class DAL_Cargo
    {
        private readonly Conexion cn = new Conexion();

        public int Agregar(string nombre)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion","AGREGAR"),
                new SqlParameter("@nomcargo",nombre),
                new SqlParameter("@codcargo",SqlDbType.Int)
                { Direction = ParameterDirection.Output }
            };
            cn.EjecutarSPNonQuery("sp_Cargo_CRUD", parametros);
            return (int)parametros[2].Value;
        }

        public void Editar(int id, string nombre)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion","EDITAR"),
                new SqlParameter("@codcargo",id),
                new SqlParameter("@nomcargo",nombre)
            };
            cn.EjecutarSPNonQuery("sp_Cargo_CRUD", parametros);
        }

        public void Eliminar(int id)
        {
            var parametros = new List<SqlParameter>
            {
                new SqlParameter("@Accion","ELIMINAR"),
                new SqlParameter("@codcargo",id)
            };
            cn.EjecutarSPNonQuery("sp_Cargo_CRUD", parametros);
        }

        public DataTable Listar()
        {
            return cn.EjecutarSP("sp_Cargo_Listar");
        }
    }
}

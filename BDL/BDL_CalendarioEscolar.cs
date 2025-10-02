using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CONASIS.DAL;


namespace CONASIS.BDL
{
    public class BDL_CalendarioEscolar
    {
        private DAL_CalendarioEscolar dal = new DAL_CalendarioEscolar();

        public DataTable Mostrar()
        {
            return dal.Mostrar();
        }

        public void Agregar(DateTime fecha, int idtipodia, string motivo, int cod_gestion)
        {
            dal.Agregar(fecha, idtipodia, motivo, cod_gestion);
        }

        public void Modificar(int idcalendario, DateTime fecha, int idtipodia, string motivo)
        {
            dal.Modificar(idcalendario, fecha, idtipodia, motivo);
        }

        public void Eliminar(int idcalendario)
        {
            dal.Eliminar(idcalendario);
        }

        public DataTable Buscar(int idcalendario)
        {
            return dal.Buscar(idcalendario);
        }
        public DataTable MostrarPorGestion(int cod_gestion)
        {
            return dal.MostrarPorGestion(cod_gestion);
        }

    }
}

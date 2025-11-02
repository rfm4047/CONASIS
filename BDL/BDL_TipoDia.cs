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
    public class BDL_TipoDia
    {
        private readonly DAL_TipoDia dal = new DAL_TipoDia();

        public int Agregar(int cod_gestion, int cod_cattipo, string descripcion, DateTime fechaInicio, DateTime fechaFin)
        {
            return dal.Agregar(cod_gestion, cod_cattipo, descripcion, fechaInicio, fechaFin);
        }

        public int Modificar(int cod_tipodia, int cod_gestion, int cod_cattipo, string descripcion, DateTime fechaInicio, DateTime fechaFin)
        {
            return dal.Modificar(cod_tipodia, cod_gestion, cod_cattipo, descripcion, fechaInicio, fechaFin);
        }

        public int Eliminar(int cod_tipodia)
        {
            return dal.Eliminar(cod_tipodia);
        }

        public DataTable Mostrar(int cod_gestion)
        {
            return dal.MostrarPorGestion(cod_gestion);
        }


    }
}

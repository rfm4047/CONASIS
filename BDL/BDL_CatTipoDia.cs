using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CONASIS.DAL;
using System.Data;
using System.Data.SqlClient;

namespace CONASIS.BDL
{
    public class BDL_CatTipoDia
    {
        private readonly DAL_CatTipoDia dal = new DAL_CatTipoDia();

        public DataTable Mostrar()
        {
            return dal.Mostrar();
        }

        public int Agregar(string nombre, string descripcion, bool estado)
        {
            DAL_CatTipoDia dal = new DAL_CatTipoDia();
            return dal.Agregar(nombre, descripcion, estado);
        }

        public int Modificar(int cod_cattipo, string nombre, bool estado)
        {
            DAL_CatTipoDia dal = new DAL_CatTipoDia();
            return dal.Modificar(cod_cattipo, nombre, estado); // ✅ devuelve int
        }

        public bool Eliminar(int cod_cattipo)
        {
            return dal.Eliminar(cod_cattipo);
        }
    }
}

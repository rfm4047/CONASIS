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
    public class BDL_Administrativo
    {
        private DAL_Administrativo adm = new DAL_Administrativo();

        public DataTable mostrarAdministrativo()
        {
            DataTable tabla = new DataTable();
            tabla = adm.Mostrar();
            return tabla;
        }

        public void agregarAdministrativo(int idplantelf, string cargoadmi)
        {
            adm.AgregarAdministrativo(Convert.ToInt32(idplantelf), cargoadmi);
        }

        public void editarAdministrativo(string Cargoadm, int idplantelf)
        {
            adm.EditarAdministrativo(Cargoadm, Convert.ToInt32(idplantelf));
        }

        public string ultimocodigoplantel()
        {
            return adm.UltimocodigoPlantel();
        }

    }
}

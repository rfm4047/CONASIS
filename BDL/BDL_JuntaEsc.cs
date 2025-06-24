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
    public class BDL_JuntaEsc
    {
        private DAL_JuntaEsc je = new DAL_JuntaEsc();

        public DataTable mostrarJuntaEscolar()
        {
            DataTable tabla = new DataTable();
            tabla = je.Mostrar();
            return tabla;
        }

        public void agregarJuntaE(int codrepje, string nombrerje, string apprje, string apmrje, string cirje,string extrje, string telfrje, string cargorje)
        {
            je.InsertarJuntaEsc(Convert.ToInt32(codrepje), nombrerje, apprje, apmrje, cirje, extrje, telfrje, cargorje);
        }

    }
}

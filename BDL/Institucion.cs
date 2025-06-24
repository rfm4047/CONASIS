using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CONASIS.DAL;
using CONASIS.PDL;

namespace CONASIS.BDL
{

    public class Institucion
    {
        private DAL_Institucion Inst = new DAL_Institucion();

        public DataTable MostrarInstitucion()
        {
            DataTable Tabla = new DataTable();
            Tabla = Inst.Mostrar();
            return Tabla;
        }
        
    
    public bool ModificarInstitucion(
    string nominst, string dptoinst, string nivelinst, string turnoinst,
    string nservicioinst, string nprogramainst, string nsieinst, string mejorarinst,
    string direccioninst, string nucleoescinst, string subdistinst, string uvinst,
    string mzinst, string distedinst, string distmuninst, string telfuniedinst,
    string telfdirectorainst, int codinst)
    {


        return Inst.Modificar(nominst, dptoinst, nivelinst, turnoinst, nservicioinst,
            nprogramainst, nsieinst, mejorarinst, direccioninst, nucleoescinst, subdistinst,
            uvinst, mzinst, distedinst, distmuninst, telfuniedinst, telfdirectorainst, codinst);
    }
    }
}

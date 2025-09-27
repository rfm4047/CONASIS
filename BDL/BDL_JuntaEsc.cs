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
    public class JuntaEscolar
    {

        public int CodJe { get; set; }
        public string Codigo { get; set; }
        public string NomJe { get; set; }
        public string ApPaternoJe { get; set; }
        public string ApMaternoJe { get; set; }
        public string CiJe { get; set; }
        public string ExtJe { get; set; }
        public decimal? TelfJe { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int CodCargo { get; internal set; }
        public string NomCargo { get; set; }

        private readonly DAL_JuntaEsc dal = new DAL_JuntaEsc();

        

    }
}

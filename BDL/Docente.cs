using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONASIS.BDL
{
    public class Docente
    {
        public int IdDocente { get; set; }
        public int IdPlantelF { get; set; }
        public string HoraPlanilla { get; set; }
        public string CargaHorariaDocente { get; set; }
    }
}

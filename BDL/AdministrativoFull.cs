using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONASIS.BDL
{
    public class AdministrativoFull
    {
        //Administrativo
        public int IdAdm { get; set; }
        public int IdPlantelF { get; set; }
        public string CPlant { get; set; }
        public string CargoAdm { get; set; }

        //Plantel
        public int? CodPlantel { get; set; }
        public string NomPlantel { get; set; }
        public string ApPlantel { get; set; }
        public string AmPlantel { get; set; }
        public string CIPlantel { get; set; }
        public string ExtPlantel { get; set; }
        public DateTime? FechaNacPlantel { get; set; }
        public string DireccionPlantel { get; set; }
        public string GeneroPlantel { get; set; }
        public string TelfPlantel { get; set; }
        public string EspecialidadPlantel { get; set; }
        public string ItemPlantel { get; set; }
        public string RdaPlantel { get; set; }
        public string EstadoPlantel { get; set; }
    }

}

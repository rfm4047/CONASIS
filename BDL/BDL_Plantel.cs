using System;
using System.Text.RegularExpressions;
using CONASIS.DAL;

namespace CONASIS.BDL
{
    public class Plantel
    {
        public int CodPlantel { get; set; }
        public string CPlant { get; set; }
        public string NomPlantel { get; set; }         
        public string ApPlantel { get; set; }          
        public string AmPlantel { get; set; }          
        public string GeneroPlantel { get; set; }      
        public string CIPlantel { get; set; }       
        public string ExtPlantel { get; set; }       
        public string TelfPlantel { get; set; }
        public DateTime FechaNacPlantel { get; set; }
        public string DireccionPlantel { get; set; }
        public string EspecialidadPlantel { get; set; }
        public string ItemPlantel { get; set; }
        public string RdaPlantel { get; set; }
        public string EstadoPlantel { get; set; }
        public int? IdPlantel_Reemplaza { get; set; }

    }
}

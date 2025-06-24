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
    public class BDL_Plantel
    {
        private DAL_Plantel pla = new DAL_Plantel();

        public void agregarplantel(string NombrePlantel, string ApPaternoPlantel, string ApMaternoPlantel, string GeneroPlantel,
            string CiPlantel, string ExtensionPlantel, string TelfPlantel, string FechaNacPlantel, string DireccionPlantel,
            string EspecialidadPlantel, string ItemPlantel, string RdaPlantel)
        {
            pla.AgregarPlantel(NombrePlantel, ApPaternoPlantel, ApMaternoPlantel, GeneroPlantel, CiPlantel, ExtensionPlantel,
                       TelfPlantel, Convert.ToDateTime(FechaNacPlantel), DireccionPlantel, EspecialidadPlantel, ItemPlantel,
                       RdaPlantel);
        }

        public void editarplantel(string NombrePlantel, string ApPaternoPlantel, string ApMaternoPlantel, string GeneroPlantel,
            string CiPlantel, string ExtensionPlantel, string TelfPlantel, string FechaNacPlantel, string DireccionPlantel,
            string EspecialidadPlantel, string ItemPlantel, string RdaPlantel, string CodPlantel)
        {
            pla.editarPlantel(NombrePlantel, ApPaternoPlantel, ApMaternoPlantel, GeneroPlantel, CiPlantel, ExtensionPlantel,
                       TelfPlantel, Convert.ToDateTime(FechaNacPlantel), DireccionPlantel, EspecialidadPlantel, ItemPlantel,
                       RdaPlantel, Convert.ToInt32(CodPlantel));
        }

    }
}

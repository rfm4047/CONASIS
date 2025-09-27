using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CONASIS.DAL;
using System.Data;

namespace CONASIS.BDL
{
    public class BDL_Reemplazo
    {
        private readonly DAL_Reemplazo dalReemplazo = new DAL_Reemplazo();

        // Agregar reemplazo con validación
        public void Agregar(int idPlantelSolicita, int? idReemplazante, int? idPlantelReemplazante,
                            DateTime fechaSolicitud, DateTime fechaInicio, DateTime fechaFin, int idMotivo)
        {
            DAL_Reemplazo dal = new DAL_Reemplazo();
            dal.Agregar(idPlantelSolicita, idReemplazante, idPlantelReemplazante,
                        fechaSolicitud, fechaInicio, fechaFin, idMotivo);
        }

        // Listar reemplazos
        public DataTable Listar()
        {
            return dalReemplazo.Listar();
        }

        // (Opcional) Eliminar reemplazo
        public int Eliminar(int idReemplazo)
        {
            DAL_Reemplazo dal = new DAL_Reemplazo();
            return dal.Eliminar(idReemplazo);
        }


        // (Opcional) Modificar reemplazo
        public void Modificar(int idReemplazo, int idPlantelSolicita,
                      int? codReemplazante, int? codPlantelReemplazante,
                      DateTime fechaSolicitud, DateTime fechaInicio, DateTime fechaFin, int idMotivo)
        {
            DAL_Reemplazo dal = new DAL_Reemplazo();
            dal.Modificar(idReemplazo, idPlantelSolicita, codReemplazante, codPlantelReemplazante,
                          fechaSolicitud, fechaInicio, fechaFin, idMotivo);
        }

    }

}

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
    public class BDL_CalendarioEscolar
    {
        private DAL_CalendarioEscolar dal = new DAL_CalendarioEscolar();

        public DataTable Mostrar()
        {
            return dal.Mostrar();
        }

        public void Agregar(DateTime fecha, int cod_tipodia, string motivo, int cod_gestion)
        {
            dal.Agregar(fecha, cod_tipodia, motivo, cod_gestion);
        }

        public void Modificar(int idcalendario, DateTime fecha, int cod_tipodia, string motivo)
        {
            dal.Modificar(idcalendario, fecha, cod_tipodia, motivo);
        }

        public void Eliminar(int idcalendario)
        {
            dal.Eliminar(idcalendario);
        }

        public DataTable Buscar(int idcalendario)
        {
            return dal.Buscar(idcalendario);
        }
        public DataTable MostrarPorGestion(int cod_gestion)
        {
            return dal.MostrarPorGestion(cod_gestion);
        }

        public void ModificarPorRango(DateTime fechaInicio, DateTime fechaFin, int cod_tipodia, string motivo, int codGestion)
        {
            dal.ModificarPorRango(fechaInicio, fechaFin, cod_tipodia, motivo, codGestion);
        }
        public void InsertarDesdeTipoDia(int codGestion, int codTipoDia, DateTime fechaInicio, DateTime fechaFin, string motivo)
        {
            dal.InsertarDesdeTipoDia(codGestion, codTipoDia, fechaInicio, fechaFin, motivo);
        }

        public void Eliminarpordia(int codCalendario)
        {
            dal.Eliminarpordia(codCalendario);
        }

    }
}

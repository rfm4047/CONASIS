using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CONASIS.DAL;
using System.Data;
using System.Data.SqlClient;

namespace CONASIS.BDL
{
    public class BDL_Asignacion
    {
        private DAL_Asignacion dal = new DAL_Asignacion();

        public int Insertar(string dia, TimeSpan horaInicio, TimeSpan horaFin, int idmateria, int idcurso, int iddocente)
        {
            return dal.Insertar(dia, horaInicio, horaFin, idmateria, idcurso, iddocente);
        }

        public void Modificar(int codasignacion, string dia, TimeSpan horaInicio, TimeSpan horaFin, int idmateria, int idcurso, int iddocente)
        {
            dal.Modificar(codasignacion, dia, horaInicio, horaFin, idmateria, idcurso, iddocente);
        }

        public void Eliminar(int codasignacion)
        {
            dal.Eliminar(codasignacion);
        }

        public DataTable Mostrar()
        {
            return dal.Mostrar();
        }

        public DataTable Buscar(int codasignacion)
        {
            return dal.Buscar(codasignacion);
        }
    }
}

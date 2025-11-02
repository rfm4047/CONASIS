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
    public class BDL_HorarioDocente
    {
        private DAL_HorarioDocente dal = new DAL_HorarioDocente();

        public DataTable Mostrar()
        {
            return dal.Mostrar();
        }

        public void Insertar(int iddocente, int codmateria, int codcurso, int codparalelo, string diaSemana,
                             TimeSpan horaInicio, TimeSpan horaFin, TimeSpan? horaRecesoInicio, TimeSpan? horaRecesoFin, int tolerancia)
        {
            dal.Insertar(iddocente, codmateria, codcurso, codparalelo, diaSemana, horaInicio, horaFin, horaRecesoInicio, horaRecesoFin, tolerancia);
        }

        public void Actualizar(int idhorariodoc, int iddocente, int codmateria, int codcurso, int codparalelo, string diaSemana,
                               TimeSpan horaInicio, TimeSpan horaFin, TimeSpan? horaRecesoInicio, TimeSpan? horaRecesoFin, int tolerancia)
        {
            dal.Actualizar(idhorariodoc, iddocente, codmateria, codcurso, codparalelo, diaSemana, horaInicio, horaFin, horaRecesoInicio, horaRecesoFin, tolerancia);
        }

        public void Eliminar(int idhorariodoc)
        {
            dal.Eliminar(idhorariodoc);
        }
        public DataTable MostrarMensual()
        {
            return dal.MostrarMensual();
        }
    }
}


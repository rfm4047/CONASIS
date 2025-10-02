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
    public class BDL_HorarioAdministrativo
    {
        private DAL_HorarioAdministrativo dalHorario = new DAL_HorarioAdministrativo();

        // Mostrar todos los horarios
        public DataTable Mostrar()
        {
            return dalHorario.Mostrar();
        }

        // Insertar nuevo horario
        public void Agregar(int idadm, string diaSemana, TimeSpan horaEntrada, TimeSpan horaSalida, TimeSpan? recesoInicio, TimeSpan? recesoFin, int toleranciaMinutos)
        {
            dalHorario.Agregar(idadm, diaSemana, horaEntrada, horaSalida, recesoInicio, recesoFin, toleranciaMinutos);
        }

        // Editar horario existente (con tolerancia)
        public void Modificar(int idhorarioadm, int idadm, string diaSemana, TimeSpan horaEntrada, TimeSpan horaSalida, TimeSpan? recesoInicio, TimeSpan? recesoFin, int toleranciaMinutos)
        {
            dalHorario.Modificar(idhorarioadm, idadm, diaSemana, horaEntrada, horaSalida, recesoInicio, recesoFin, toleranciaMinutos);
        }

        // Eliminar horario
        public void Eliminar(int idhorarioadm)
        {
            dalHorario.Eliminar(idhorarioadm);
        }

        // Buscar un horario específico
        public DataTable Buscar(int idhorarioadm)
        {
            return dalHorario.Buscar(idhorarioadm);
        }
        public DataTable MostrarResumen()
        {
            return dalHorario.MostrarResumen();
        }
        public void EliminarTodos(int idadm)
        {
            dalHorario.EliminarTodos(idadm);
        }


    }
}

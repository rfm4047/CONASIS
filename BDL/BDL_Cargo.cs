    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CONASIS.DAL;
    using System.Data;

    namespace CONASIS.BDL
    {
        public class BDL_Cargo
        {        
            private readonly DAL_Cargo dal = new DAL_Cargo();
            public int CrearCargo(string nombre) => dal.Agregar(nombre);
            public void ModificarCargo(int id, string nombre) => dal.Editar(id, nombre);
            public void BorrarCargo(int id) => dal.Eliminar(id);
            public DataTable ObtenerCargos() => dal.Listar();
        }
        

    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CONASIS.DAL;
using CONASIS.SEGURIDAD;

namespace CONASIS.SEGURIDAD
{
    public class UserBussines
    {
        UserData userdata = new UserData();
        public bool LoginUser(string user, string pass)
        { 
        return userdata.Login(user, pass);
        }
    }
}

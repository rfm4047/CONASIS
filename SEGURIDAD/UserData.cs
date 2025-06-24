﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CONASIS.DAL;

namespace CONASIS.SEGURIDAD
{
    public class UserData : ConexionSeg
    {
        public bool Login(string user, string pass)
        { 
            using (var connection = GetSqlConnection())
             {
               connection.Open();
              using (var command  = new SqlCommand())
              {
                  command.Connection= connection;
                  command.CommandText = " ";
                  command.Parameters.AddWithValue("@user", user);
                  command.Parameters.AddWithValue("@pass", pass);
                  command.CommandType = CommandType.Text;
                  SqlDataReader reader = command.ExecuteReader();
                  if(reader.HasRows)
                  {
                    return true;
                  }
                   else
                  return false;
            }
    }

        }
    }
}
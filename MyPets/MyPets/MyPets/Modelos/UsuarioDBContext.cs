using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MyPets.Modelos
{
   public class UsuarioDBContext
    {
        public SQLiteAsyncConnection Conexion { get; set; }

        public UsuarioDBContext(String sqlitepath)
        {
            try
            {
                this.Conexion = new SQLiteAsyncConnection(sqlitepath);
                this.Conexion.CreateTableAsync<Usuario>().Wait();
            }
            catch (Exception ex)
            {
                Debug.Print("Error : " + ex.Message);

            }
        }
    }
}

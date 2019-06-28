using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MyPets.Modelos
{
  public  class VeterinarioDBContext
    {
        public SQLiteAsyncConnection Conexion { get; set; }

        public VeterinarioDBContext(String sqlitepath)
        {
            try
            {
                this.Conexion = new SQLiteAsyncConnection(sqlitepath);
                this.Conexion.CreateTableAsync<VeterinarioInsert>().Wait();
            }
            catch (Exception ex)
            {
                Debug.Print("Error : " + ex.Message);

            }
        }
    }
}

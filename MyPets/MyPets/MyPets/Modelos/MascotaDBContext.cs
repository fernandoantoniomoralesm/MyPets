using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
namespace MyPets.Modelos
{
  public class MascotaDBContext
    {
        public SQLiteAsyncConnection Conexion { get; set; }

        public MascotaDBContext(String sqlitepath)
        {
            try
            {
                this.Conexion = new SQLiteAsyncConnection(sqlitepath);
                this.Conexion.CreateTableAsync<Mascota>().Wait();
            }
            catch (Exception ex)
            {
                Debug.Print("Error : " + ex.Message);

            }
        }
    }
}

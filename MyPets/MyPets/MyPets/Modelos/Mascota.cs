using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace MyPets.Modelos
{
   public class Mascota
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string RegMascota { get; set; }
        public string RegEspecie { get; set; }
        public string RegGenero { get; set; }
        public string RegRaza { get; set; }
        public string RegFechaNac { get; set; }

        private MascotaDBContext db;

        public Mascota() { }

        public Mascota(MascotaDBContext BaseDatos)
        {
            this.db = BaseDatos;
        }

        //Metodo para Guardar
        public Task<bool> GuardarTablaAsincrona(Mascota tabla)
        {
            if (this.db.Conexion.InsertAsync(tabla).Result == 1)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        //Metodo para la ejecucion de Query
        public Task<List<Mascota>> QueryAsincrona(string query)
        {
            return this.db.Conexion.QueryAsync<Mascota>(query);
        }

        //Metodo para Eliminar 
        public Task<bool> EliminarTablaAsincrona(Mascota tabla)
        {
            if (this.db.Conexion.DeleteAsync(tabla).Result == 1)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        //Metodo Actualizar
        public Task<bool> ActualizarTablaAsincrona(Mascota tabla)
        {
            if (this.db.Conexion.UpdateAsync(tabla).Result == 1)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}




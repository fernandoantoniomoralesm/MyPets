using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace MyPets.Modelos
{
    class VeterinarioInsert
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string RegFoto { get; set; }
        public string RegNomVete { get; set; }
        public string RegDireccion { get; set; }
        public string RegTel { get; set; }
        public string RegHorario { get; set; }

        private VeterinarioDBContext db;

        public VeterinarioInsert() { }

        public VeterinarioInsert(VeterinarioDBContext BaseDatos)
        {
            this.db = BaseDatos;
        }


        //Metodo para Guardar
        public Task<bool> GuardarTablaAsincrona(VeterinarioInsert tabla)
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
        public Task<List<VeterinarioInsert>> QueryAsincrona(string query)
        {
            return this.db.Conexion.QueryAsync<VeterinarioInsert>(query);
        }

        //Metodo para Eliminar 
        public Task<bool> EliminarTablaAsincrona(VeterinarioInsert tabla)
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
        public Task<bool> ActualizarTablaAsincrona(VeterinarioInsert tabla)
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

using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPets.Modelos
{
   public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string RegNombre { get; set; }
        public string RegEmail { get; set; }
        public string RegContrasena { get; set; }

        private UsuarioDBContext db;

        public Usuario() { }

        public Usuario(UsuarioDBContext BaseDatos)
        {
            this.db = BaseDatos;
        }

        //Metodo para Guardar
        public Task<bool> GuardarTablaAsincrona(Usuario tabla)
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
        public Task<List<Usuario>> QueryAsincrona(string query)
        {
            return this.db.Conexion.QueryAsync<Usuario>(query);
        }

        //Metodo para Eliminar 
        public Task<bool> EliminarTablaAsincrona(Usuario tabla)
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
        public Task<bool> ActualizarTablaAsincrona(Usuario tabla)
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

using Android.Widget;
namespace MyPets.VistaModelo
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Vistas;
    using Modelos;
    using SQLite;
    using System;
    using System.IO;

    public partial class RegistrarseVistaModelo : BaseVistaModelo
    {
        private UsuarioDBContext db;
        private String baseDatos = "dbVeterinaria.db3";
        private String ubicacion = "";

        public RegistrarseVistaModelo()
        {
            ubicacion = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
                this.baseDatos);
            this.db = new UsuarioDBContext(this.ubicacion);
        }
       
        #region atributos
        private string usuario;
        private string email;
     
        #endregion
        
        #region Propiedades
        public string Usuario
        {
            get { return this.usuario; }
            set { SetValue(ref this.usuario, value); }
        }
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
       
        #endregion



        #region Comados
        public ICommand RegistrarUsuarioCommand
        {
            get
            {
                return new RelayCommand(RegistrarUsuario);
            }

        }
       

       

        private async void RegistrarUsuario()
        {
            if (string.IsNullOrEmpty(this.Usuario))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese su Usuario",
                    "Aceptar");
                return;
            }
            else if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese su Correo",
                    "Aceptar");
                return;
            }
            else {
               /* Usuario ConsultaUsuario = new Usuario(this.db);
                var usuario1 =ConsultaUsuario.QueryAsincrona(
               "SELECT RegNombre,RegEmail FROM [Usuario]").Result;
                if (!(usuario1.Count==0))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Usuario o Email ya existe", "Aceptar");
                }*/
                Usuario nuevoUsuario = new Usuario(this.db);
                nuevoUsuario.RegNombre = this.usuario;
                nuevoUsuario.RegEmail = this.email;
                bool resultado =
                    await nuevoUsuario.GuardarTablaAsincrona(nuevoUsuario);
                if (resultado)
                {
                    await Application.Current.MainPage.DisplayAlert("Exito", "Usuario Agregado", "Aceptar");
                    MainVistaModelo.GetInstance().MasterPage = new MasterDetailVistaModelo();
                    await Application.Current.MainPage.Navigation.PushAsync(new MasterPage());
                    this.Usuario = "";
                    this.Email = "";

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Usuario no Agregado", "Aceptar");
                    this.Usuario = "";
                    this.Email = "";
                }
                
            }
        }
                

           

        public ICommand CancelarCommand
        {
            get
            {
                return new RelayCommand(Cancelar);
            }
           
        }

        private void Cancelar()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());

        }
        #endregion
    }
}

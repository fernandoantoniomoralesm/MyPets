
using MyPets.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPets.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AggMascota : ContentPage
	{
        private string baseDatos = "dbVeterinaria.db3";
        private string ubicacion;
        private MascotaDBContext db;

        public AggMascota ()
		{
			InitializeComponent ();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#0E3042");
            
            
            ubicacion = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), this.baseDatos);
            this.db = new MascotaDBContext(this.ubicacion);

        }

        
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            Mascota nuevaMascota = new Mascota(this.db);
            nuevaMascota.RegMascota = nombre.Text;
            nuevaMascota.RegEspecie = especie.Text;
            nuevaMascota.RegGenero = genero.Text;
            nuevaMascota.RegRaza = raza.Text;
            nuevaMascota.RegFechaNac = fechanac.Text;
            if (string.IsNullOrEmpty(nombre.Text))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese el nombre de su mascota",
                    "Aceptar");
                return;
            }
            else if (string.IsNullOrEmpty(especie.Text))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese la especie",
                    "Aceptar");
                return;
            }
            else if (string.IsNullOrEmpty(raza.Text))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Ingrese la raza",
                    "Aceptar");
                return;
            }
            else
            {


                bool resultado = await nuevaMascota.GuardarTablaAsincrona(nuevaMascota);
                if (resultado)
                {
                    await DisplayAlert("Exito", "Mascota agregada con exito", "Aceptar");
                }
                else
                {
                    await DisplayAlert("Error", "Mascota no agregada", "Aceptar");

                }

                this.nombre.Text = "";
                this.genero.Text = "";
                this.raza.Text = "";
                this.especie.Text = "";
            }

            }

       
    }
}
using MyPets.Modelos;
using MyPets.VistaModelo;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPets.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Veterinario : ContentPage
	{
        private VeterinarioDBContext db;
        private String baseDatos = "dbVeterinaria.db3";
        private String ubicacion = "";
        ObservableCollection<VeterinarioInsert> Veterinariolista;
        public Veterinario ()
		{
			InitializeComponent ();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#0E3042");

            ubicacion = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),this.baseDatos);
            this.db = new VeterinarioDBContext(this.ubicacion);
            CargarVeterinarios();
        }

        //Metodo para Cargar la listview
        void CargarVeterinarios()
        {
            VeterinarioInsert nuevoVeterinario = new VeterinarioInsert(this.db);
            nuevoVeterinario.RegFoto ="img1.png";
            nuevoVeterinario.RegNomVete = "Karina";
            nuevoVeterinario.RegDireccion = "Por aqui";
            nuevoVeterinario.RegTel = "5689-8443";
            nuevoVeterinario.RegHorario = "7-9";

            nuevoVeterinario.RegFoto = "img2.png";
            nuevoVeterinario.RegNomVete = "Karina";
            nuevoVeterinario.RegDireccion = "Por alla";
            nuevoVeterinario.RegTel = "5689-8443";
            nuevoVeterinario.RegHorario = "7-9";

            var Veterinari = nuevoVeterinario.QueryAsincrona(
                "SELECT * FROM [VeterinarioInsert]").Result;
            if (!(Veterinari.Count == 0))
            {
                Veterinariolista = new ObservableCollection<VeterinarioInsert>();
                foreach (var item in Veterinari)
                {
                    Veterinariolista.Add(item);
                }
                listaVeterinario.ItemsSource = Veterinariolista;
            }
        }

    }
}
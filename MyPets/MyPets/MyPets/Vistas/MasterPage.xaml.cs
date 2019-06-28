using MyPets.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyPets.Vistas;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.IO;
using Rg.Plugins.Popup.Services;

namespace MyPets.Vistas
{
    public partial class MasterPage : MasterDetailPage
    {
       /* private String baseDatos = "dbVeterinaria.db3";
        private String ubicacion = "";
        private UsuarioDBContext db;*/
        public List<MasterPageItem> MenuList { get; set; }

        public MasterPage()
        {
            InitializeComponent();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#0E3042");
            /* ubicacion = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), this.baseDatos);
             this.db = new UsuarioDBContext(this.ubicacion);
             Usuario Usuario = new Usuario(this.db);
             var User = Usuario.QueryAsincrona(
                 "SELECT RegNombre,RegEmail FROM [Usuario] WHERE Id=1").Result;
             if (!(User.Count == 0))
             {

             }
             */
            MenuList = new List<MasterPageItem>();
            // Adding menu items to menuList and you can define title ,page and icon  
            MenuList.Add(new MasterPageItem()
            {
                Title = "Inicio",
                Icon = "home.png",
                TargetType = typeof(Inicio)
            });
            MenuList.Add(new MasterPageItem()
            {
                Title = "Perfil",
                Icon = "usuari.png",
                TargetType = typeof(Registrarse)
            });
           
            MenuList.Add(new MasterPageItem()
            {
                Title = "Tareas",
                Icon = "tarea.png",
                TargetType = typeof(MostrarTareas)
            });
            MenuList.Add(new MasterPageItem()
            {
                Title = "Consultas",
                Icon = "consu.png",
                TargetType = typeof(ConsultasAgg)
            });
            MenuList.Add(new MasterPageItem()
            {
                Title = "Contáctanos",
                Icon = "mail.png",
                TargetType = typeof(Contactos)
            });

            // Setting our list to be ItemSource for ListView in MainPage.xaml  
            navigationDrawerList.ItemsSource = MenuList;
            // Initial navigation, this can be used for our home page  
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Inicio)));
        }


        // Event for Menu Item selection, here we are going to handle navigation based  
        // on user selection in menu ListView  
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    } 
    }
	

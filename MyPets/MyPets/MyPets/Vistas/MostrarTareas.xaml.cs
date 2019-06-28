using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPets.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MostrarTareas : ContentPage
	{
		public MostrarTareas ()
		{
			InitializeComponent ();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#0E3042");
        }
	}
}
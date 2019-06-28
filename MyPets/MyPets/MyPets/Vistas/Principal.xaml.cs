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
	public partial class Principal : ContentPage
	{
		public Principal ()
		{
			InitializeComponent ();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await MainProgressBar.ProgressTo(1.0, 4000, Easing.Linear);
            await MainProgressBar.ScaleTo(0.9, 1500, Easing.Linear);
            await MainProgressBar.ScaleTo(150, 1200, Easing.Linear);

            Application.Current.MainPage = new NavigationPage(new Vistas.MasterPage());
        }
    }

}
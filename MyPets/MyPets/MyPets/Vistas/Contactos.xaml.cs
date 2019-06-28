using Plugin.Messaging;
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
	public partial class Contactos : ContentPage
	{
		public Contactos ()
		{
			InitializeComponent ();
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#0E3042");
        }

        private void EnviarEmail(object sender, EventArgs e)
        {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                // Send simple e-mail to single receiver without attachments, bcc, cc etc.
                emailMessenger.SendEmail("karinadiazmartinez06@gmail.com",
                    "Consulta o Sugerencia!",
                    "");

                // Alternatively use EmailBuilder fluent interface to construct more complex e-mail with multiple recipients, bcc, attachments etc.
                var email = new EmailMessageBuilder()
                  .To("Example@gmail.com")
                  .Cc("Example@gmail.com")
                  .Bcc(new[] { "Example@gmail.com", "Example@gmail.com" })
                  .Subject("Prueba")
                  .Body("Esta es una prueba para xamarin")
                  .Build();

                emailMessenger.SendEmail(email);
            }
        }
    }
}
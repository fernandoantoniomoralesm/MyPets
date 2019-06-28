using GalaSoft.MvvmLight.Command;
using MyPets.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyPets.VistaModelo
{
    class InicioVistaModelo
    {
        #region Commands
        public ICommand AgregarCommand
        {
            get
            {
                return new RelayCommand(agregar);
            }

        }
        public ICommand AgendaCommand
        {
            get
            {
                return new RelayCommand(agenda);
            }
        }
             public ICommand ConsultaCommand
        {
            get
            {
                return new RelayCommand(consulta);
            }

        }
        public ICommand VeterinarioCommand
        {
            get
            {
                return new RelayCommand(veterinario);
            }

        }
        public ICommand GraficoCommand
        {
            get
            {
                return new RelayCommand(grafico);
            }

        }
        public ICommand PerfilMascotaCommand
        {
            get
            {
                return new RelayCommand(perfilMascota);
            }

        }

        private async void perfilMascota()
        {
            MainVistaModelo.GetInstance().PerfilPet = new PerfilPetVistaModelo();
            await Application.Current.MainPage.Navigation.PushAsync(new PerfilPet());
        }

        private async void grafico()
        {
            MainVistaModelo.GetInstance().Grafico = new GraficoVistaModelo();
            await Application.Current.MainPage.Navigation.PushAsync(new Grafica());
        }

        private async void veterinario()
        {
            MainVistaModelo.GetInstance().veterinario = new VeterinarioVistaModelo();
            await Application.Current.MainPage.Navigation.PushAsync(new Veterinario());
        }

        private async void consulta()
        {
            MainVistaModelo.GetInstance().Citas = new CitasVistaModelo();
            await Application.Current.MainPage.Navigation.PushAsync(new Citas());
        }

        private async void agenda()
        {
            MainVistaModelo.GetInstance().Agenda = new AgendaVistaModelo();
            await Application.Current.MainPage.Navigation.PushAsync(new Agenda());
        }

        private async void agregar()
        {
            MainVistaModelo.GetInstance().AggMascota = new AggMascotaVistaModelo();
            Application.Current.MainPage.Navigation.PushAsync(new AggMascota());
        }
        #endregion
    }
}

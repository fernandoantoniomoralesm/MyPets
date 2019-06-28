using System;
using System.Collections.Generic;
using System.Text;

namespace MyPets.VistaModelo
{
    class MainVistaModelo
    {
        #region VistaModelo
       
        public RegistrarseVistaModelo Registrarse
        {
            get;
            set;
        } 

        public InicioVistaModelo Inicio
        {
            get;
            set;
        }

        public AggMascotaVistaModelo AggMascota
        {
            get;
            set;
        }
        public AgendaVistaModelo Agenda
        {
            get;
            set;
        }
        public CitasVistaModelo Citas
        {
            get;
            set;
        }
        public GraficoVistaModelo Grafico
        {
            get;
            set;
        }
        public VeterinarioVistaModelo veterinario
        {
            get;
            set;
        }
        public PerfilPetVistaModelo PerfilPet
        {
            get;
            set;
        }
        public MasterDetailVistaModelo MasterPage
        {
            get;
            set;
        }


        #endregion
        #region constructor
        public MainVistaModelo()
        {
            this.Registrarse = new RegistrarseVistaModelo();
            this.Inicio = new InicioVistaModelo();
            this.AggMascota = new AggMascotaVistaModelo();
            this.Agenda = new AgendaVistaModelo();
            this.Citas = new CitasVistaModelo();
            this.veterinario = new VeterinarioVistaModelo();
            this.Grafico = new GraficoVistaModelo();
            this.PerfilPet = new PerfilPetVistaModelo();
            this.MasterPage = new MasterDetailVistaModelo();
        }
        
        #endregion
        #region Singleton
        private static MainVistaModelo instance;

        public static MainVistaModelo GetInstance()
        {
            if (instance==null)
            {
                return new MainVistaModelo();
            }
            return instance;
        }
        #endregion

      
    }
}

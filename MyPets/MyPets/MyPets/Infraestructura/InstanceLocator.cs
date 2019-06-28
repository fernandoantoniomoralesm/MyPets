using System;
using System.Collections.Generic;
using System.Text;


namespace MyPets.Infraestructura
{
    using VistaModelo;
    class InstanceLocator
    {
        #region Propiedades
        public MainVistaModelo Main
        {
            get;
            set;
        }
        #endregion

        #region Constructor
        public InstanceLocator()
        {
            this.Main = new MainVistaModelo();
        }
        #endregion
    }
}

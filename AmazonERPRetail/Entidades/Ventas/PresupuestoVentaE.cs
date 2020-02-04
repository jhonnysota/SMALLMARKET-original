using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class PresupuestoVentaE
    {

        public PresupuestoVentaE()
        {
            ListaPresupuestoVentaDet = new List<PresupuestoVentaDetE>();
        }

        [DataMember]









        [DataMember]
        public String Vendedor { get; set; }

        [DataMember]
        public String DesTipoArticulo { get; set; }

        [DataMember]
        public String DesMoneda { get; set; }


        [DataMember]
        public List<PresupuestoVentaDetE> ListaPresupuestoVentaDet { get; set; }
    }   
}
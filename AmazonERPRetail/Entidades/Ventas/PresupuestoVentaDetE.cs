using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public partial class PresupuestoVentaDetE
    {

        [DataMember]





       	[DataMember]


        [DataMember]
        public String NombreMes { get; set; }        

        [DataMember]







        //Extensiones
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String Vendedor { get; set; }

        [DataMember]
        public String DesTipoArticulo { get; set; }

        [DataMember]
        public String DesEstablecimiento { get; set; }

        [DataMember]
        public String codArticulo { get; set; }

    }   
}
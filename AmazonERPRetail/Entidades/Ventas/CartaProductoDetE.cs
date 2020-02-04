using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class CartaProductoDetE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }
            
        [DataMember]


        [DataMember]
        public Int32 idTipoArticulo { get; set; }

        [DataMember]
        public String codCategoria { get; set; }














        //Extensiones

        [DataMember]
        public String DesArticulo { get; set; }

        [DataMember]
        public String DesTipoArticulo { get; set; }

        [DataMember]
        public String desCategoria { get; set; }

    }   
}
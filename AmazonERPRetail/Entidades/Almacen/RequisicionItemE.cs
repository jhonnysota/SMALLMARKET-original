using System;
using System.Runtime.Serialization;

namespace Entidades.Almacen
{
    [DataContract]
    [Serializable]
    public partial class RequisicionItemE
    {
            
        [DataMember]





        [DataMember]
        public String Lote { get; set; }

        [DataMember]

        [DataMember]
        public Decimal? MontoTotal { get; set; }

        [DataMember]






        [DataMember]
        public Int32 Opcion { get; set; }

        //extensiones

        [DataMember]
        public String DesArticulo { get; set; }

    }   
}
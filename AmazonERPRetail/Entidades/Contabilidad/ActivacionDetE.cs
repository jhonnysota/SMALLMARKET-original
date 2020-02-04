using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class ActivacionDetE
    {
            
        [DataMember]

        public Int32 Item { get; set; }
        public String numVerPlanCuentas { get; set; }

        [DataMember]



        [DataMember]
        public Decimal MontoDebeDolares { get; set; }

        [DataMember]
        public Decimal MontoHaberDolares { get; set; }

        [DataMember]




        //Extensiones
        [DataMember]
        public Int32 Opcion { get; set; }

        [DataMember]
        public String desCuenta { get; set; }
        
    }   
}
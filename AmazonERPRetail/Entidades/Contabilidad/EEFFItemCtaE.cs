using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class EEFFItemCtaE
    {
            
        [DataMember]










        //Extensiones
        [DataMember]
        public String desCuenta { get; set; }

        [DataMember]
        public String DesNivel { get; set; }

        [DataMember]
        public Decimal totDebeSoles { get; set; }

        [DataMember]
        public Decimal totHaberSoles { get; set; }

        [DataMember]
        public Decimal totDebeDolares { get; set; }

        [DataMember]
        public Decimal totHaberDolares { get; set; }

        [DataMember]
        public Decimal SaldoActualSoles { get; set; }

        [DataMember]
        public Decimal SaldoActualDolares { get; set; }

        [DataMember]
        public Boolean Check { get; set; }

    }   
}
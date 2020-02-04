using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
     public class BalanceComprobacionE
    {
        [DataMember]
        public String CodCostos { get; set; }

        [DataMember]
        public String DesCostos { get; set; }
        
        [DataMember]
        public String CodCuenta { get; set; }

        [DataMember]
        public String DesCuenta { get; set; }

        [DataMember]
        public Decimal MayorDebe { get; set; }

        [DataMember]
        public Decimal MayorHaber { get; set; }

        [DataMember]
        public Decimal SaldoActualDebe { get; set; }

        [DataMember]
        public Decimal SaldoActualHaber { get; set; }

        [DataMember]
        public Decimal InvenActivo { get; set; }

        [DataMember]
        public Decimal InvenPasivo { get; set; }

        [DataMember]
        public Decimal PorFuncionPerdida { get; set; }

        [DataMember]
        public Decimal PorFuncionGanancia { get; set; }

        [DataMember]
        public Decimal PorNaturalezaPerdida { get; set; }

        [DataMember]
        public Decimal PorNaturalezaGanancia { get; set; }

    }
}

using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class ComisionesCalE
    {
        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idPeriodo { get; set; }

        [DataMember]
        public DateTime FechaInicial { get; set; }

        [DataMember]
        public DateTime FechaFinal { get; set; }

        [DataMember]
        public Decimal Comision { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numSerie { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public DateTime FecEmision { get; set; }

        [DataMember]
        public String numRuc { get; set; }

        [DataMember]
        public String RazonSocialDocumento { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Decimal TotTotal { get; set; }

        [DataMember]
        public Decimal ComisionDocumento { get; set; }
    }
}

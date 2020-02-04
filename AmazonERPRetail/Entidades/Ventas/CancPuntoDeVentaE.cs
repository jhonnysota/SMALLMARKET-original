using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class CancPuntoDeVentaE
    {
        [DataMember]
        public Int32 idPersona { get; set; }

        [DataMember]
        public String RazonSocial { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numSerie { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public String idMoneda { get; set; }

        [DataMember]
        public Decimal totTotal { get; set; }

        [DataMember]
        public Int32 idMedioPago { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public String idMonedaRecibida { get; set; }

        [DataMember]
        public Decimal MontoRecibido { get; set; }

        //Extensiones
        [DataMember]
        public Decimal efecsoles { get; set; }

        [DataMember]
        public Decimal efecdolares { get; set; }

        [DataMember]
        public Decimal visasoles { get; set; }

        [DataMember]
        public Decimal visadolares { get; set; }

        [DataMember]
        public Decimal mastersoles { get; set; }

        [DataMember]
        public Decimal masterdolares { get; set; }

        [DataMember]
        public Decimal dinersoles { get; set; }

        [DataMember]
        public Decimal dinerdolares { get; set; }

        [DataMember]
        public Decimal americansoles { get; set; }

        [DataMember]
        public Decimal americandolares { get; set; }

    }
}

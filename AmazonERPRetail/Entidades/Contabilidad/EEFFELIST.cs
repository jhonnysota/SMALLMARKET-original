using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class EEFFELIST
    {
        [DataMember]
        public Int32 Columna1 { get; set; }

        [DataMember]
        public Int32 Columna2 { get; set; }

        [DataMember]
        public string TipoTabla1 { get; set; }

        [DataMember]
        public string TipoTabla2 { get; set; }

        [DataMember]
        public string descripcion1 { get; set; }

        [DataMember]
        public string descripcion2 { get; set; }

        [DataMember]
        public Decimal Deudor1 { get; set; }

        [DataMember]
        public Decimal Deudor2 { get; set; }

        [DataMember]
        public Decimal Acreedor1 { get; set; }

        [DataMember]
        public Decimal Acreedor2 { get; set; }
    }
}
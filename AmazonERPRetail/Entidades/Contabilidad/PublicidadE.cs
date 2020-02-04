using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public partial class PublicidadE
    {

        [DataMember]
        public String RUC { get; set; }
        
        [DataMember]
        public String Glosa { get; set; }

        [DataMember]
        public String TipoCuenta { get; set; }

        [DataMember]
        public DateTime? Fecha { get; set; }

        [DataMember]
        public String Documento { get; set; }

        [DataMember]
        public Decimal Dolar { get; set; }

        [DataMember]
        public Decimal Soles { get; set; }  

    }
}

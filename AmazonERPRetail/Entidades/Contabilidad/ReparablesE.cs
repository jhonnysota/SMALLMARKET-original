using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{

    [DataContract]
    [Serializable]
    public partial class ReparablesE
    {
        [DataMember]
        public String codCuenta { get; set; }

        [DataMember]
        public DateTime fecOperacion { get; set; }

        [DataMember]
        public String idCCostos { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public String idComprobante { get; set; }

        [DataMember]
        public String numVoucher { get; set; }

        [DataMember]
        public String numFile { get; set; }

        [DataMember]
        public DateTime fecDocumento { get; set; }

        [DataMember]
        public String idDOCUMENTO { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public String GlosaGeneral { get; set; }

        [DataMember]
        public Int32 idConceptoRep { get; set; }

        [DataMember]
        public String nomConcepto { get; set; }

        [DataMember]
        public String DESGlosa { get; set; }

        [DataMember]
        public String indDebeHaber { get; set; }

        [DataMember]
        public Decimal impDolares { get; set; }

        [DataMember]
        public Decimal impSoles { get; set; }

    

    }
}

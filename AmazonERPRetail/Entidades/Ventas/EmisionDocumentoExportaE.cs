using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class EmisionDocumentoExportaE
    {

        [DataMember]
        public Int32 idEmpresa { get; set; }

        [DataMember]
        public Int32 idLocal { get; set; }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String numSerie { get; set; }

        [DataMember]
        public String numDocumento { get; set; }

        [DataMember]
        public String Item { get; set; }

        [DataMember]
        public String Concepto { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public Decimal? Importe { get; set; }

    }   
}
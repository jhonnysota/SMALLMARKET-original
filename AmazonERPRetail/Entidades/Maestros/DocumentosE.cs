using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Entidades.Generales;

namespace Entidades.Maestros
{
    [DataContract]
    [Serializable]
    public partial class DocumentosE
    {

        public DocumentosE()
        {
            ListaImpuestosDocumentos = new List<ImpuestosDocumentosE>();
        }

        [DataMember]
        public String idDocumento { get; set; }

        [DataMember]
        public String desDocumento { get; set; }

        [DataMember]
        public String desCorta { get; set; }

        [DataMember]
        public String indDebeHaber { get; set; }

        [DataMember]
        public String CodigoSunat { get; set; }

        [DataMember]
        public Boolean indBaja { get; set; }

        [DataMember]
        public DateTime? fecBaja { get; set; }

        [DataMember]
        public Int32? codMedioPago { get; set; }

        [DataMember]
        public Boolean indFecVencimiento { get; set; }

        [DataMember]
        public Boolean indReferencia { get; set; }

        [DataMember]
        public Boolean EsReferencia { get; set; }

        [DataMember]
        public Boolean indDocumentoVentas { get; set; }

        [DataMember]
        public Boolean indRecepcionDcmto { get; set; }

        [DataMember]
        public Boolean indDocumentoCompras { get; set; }

        [DataMember]
        public Boolean indAduanera { get; set; }

        [DataMember]
        public Int32? depAduanera { get; set; }

        [DataMember]
        public Boolean indDocNoDom { get; set; }

        [DataMember]
        public Boolean indCreditoFiscal { get; set; }

        [DataMember]
        public Boolean indTesoreria { get; set; }

        [DataMember]
        public Boolean indViaticos { get; set; }

        [DataMember]
        public Boolean indAlmacen { get; set; }

        [DataMember]  
		public String UsuarioRegistro { get; set; }  
		
        [DataMember]  
		public DateTime? FechaRegistro { get; set; }  
		
        [DataMember]  
		public String UsuarioModificacion { get; set; }  
		
        [DataMember]  
		public DateTime? FechaModificacion { get; set; }  

        //Extensiones
        [DataMember]
        public List<ImpuestosDocumentosE> ListaImpuestosDocumentos { get; set; }

        [DataMember]
        public String desDocTemporal { get; set; }

    }   
}
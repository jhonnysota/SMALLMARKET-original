using System;
using System.Runtime.Serialization;

namespace Entidades.Generales
{
    [DataContract]
    [Serializable]
    public class ImpuestosDocumentosE
    {
            
        [DataMember]
		public String idDocumento { get; set; }

		[DataMember]
		public Int32 idImpuesto { get; set; }
       
		//Extensiones
        [DataMember]
        public String desImpuesto { get; set; }

        [DataMember]
        public String desAbreviatura { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

         [DataMember]
        public String desDocumento { get; set; }


    }   
}
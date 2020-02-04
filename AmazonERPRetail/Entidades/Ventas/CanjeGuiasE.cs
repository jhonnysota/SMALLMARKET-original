using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class CanjeGuiasE
    {
            
        [DataMember]
		public Int32 idEmpresa { get; set; }

		[DataMember]
		public Int32 idLocal { get; set; }

		[DataMember]
		public String idDocumentoFact { get; set; }

		[DataMember]
		public String numSerieFact { get; set; }

		[DataMember]
		public String numDocumentoFact { get; set; }

		[DataMember]
		public String idDocumentoGuia { get; set; }

		[DataMember]
		public String numSerieGuia { get; set; }

		[DataMember]
		public String numDocumentoGuia { get; set; }

        //Extensiones

    }   
}
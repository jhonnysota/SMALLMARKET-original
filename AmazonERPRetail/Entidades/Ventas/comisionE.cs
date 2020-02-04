using System;
using System.Runtime.Serialization;

namespace Entidades.Ventas
{
    [DataContract]
    [Serializable]
    public class comisionE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idPeriodo { get; set; }
		[DataMember]		public Int32 idVendedor { get; set; }
		[DataMember]		public Decimal Categoria { get; set; }
		[DataMember]		public Decimal Categoria1 { get; set; }
		[DataMember]		public Decimal Categoria2 { get; set; }
		[DataMember]		public Decimal Subjetivo { get; set; }
		//EXTENSIONES

        [DataMember]
        public String Nombres { get; set; }

        [DataMember]
        public String ApeMaterno { get; set; }

        [DataMember]
        public String ApePaterno { get; set; }

        [DataMember]
        public String NroDocumento { get; set; }
    }   
}
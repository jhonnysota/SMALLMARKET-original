using System;
using System.Runtime.Serialization;

namespace Entidades.CtasPorPagar
{
    [DataContract]
    [Serializable]
    public class NumControlCompraDetE
    {
            
        [DataMember]		public Int32 idEmpresa { get; set; }
		[DataMember]		public Int32 idLocal { get; set; }
		[DataMember]		public Int32 idControl { get; set; }
		[DataMember]		public Int32 item { get; set; }
		[DataMember]		public String idDocumento { get; set; }
		[DataMember]		public String Serie { get; set; }
		[DataMember]		public Int32? cantDigSerie { get; set; }
		[DataMember]		public String numInicial { get; set; }
		[DataMember]		public String numFinal { get; set; }
		[DataMember]		public String numCorrelativo { get; set; }
		[DataMember]		public Int32? cantDigNumero { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }

        [DataMember]
        public Int32 Opcion { get; set; }

    }   
}
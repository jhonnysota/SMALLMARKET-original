using System;
using System.Runtime.Serialization;

namespace Entidades.Contabilidad
{
    [DataContract]
    [Serializable]
    public class EEFFItemXlsE
    {  
        [DataMember]		public Int32 idEMPRESA { get; set; }
		[DataMember]		public Int32 idEEFF { get; set; }
		[DataMember]		public Int32 idEEFFItem { get; set; }
		[DataMember]		public Int32 idEEFFItemXls { get; set; }
		[DataMember]		public String codcCostos { get; set; }
        
        [DataMember]
        public String descCostos { get; set; }
		[DataMember]		public Int32? fila { get; set; }
		[DataMember]		public Int32? columna { get; set; }
		[DataMember]		public String UsuarioRegistro { get; set; }
		[DataMember]		public DateTime? FechaRegistro { get; set; }
		[DataMember]		public String UsuarioModificacion { get; set; }
		[DataMember]		public DateTime? FechaModificacion { get; set; }		
        
    }   
}